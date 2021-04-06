using Core.Entities;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.DTOs
{
    public class CarDetailDto :IDto
    {
        public int Id { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
        public int ColorId  { get; set; }
        public string[] ImagePath { get; set; }
        public int ModelYear { get; set; }

        public bool Available { get; set; }

    }
}
