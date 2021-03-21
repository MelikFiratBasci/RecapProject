using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpPost("add")]
        public IActionResult Add([FromForm(Name ="Image")]IFormFile formFile,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(formFile,carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
            

        }
        [HttpPost("update")]
        public IActionResult Update([FromForm]IFormFile formFile,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(formFile,carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _carImageService.Get(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int id)
        {
            var result = _carImageService.GetAllByCarId(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
