using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var sourcePath = Path.GetTempFileName();
            using (var stream = new FileStream(sourcePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }

            var result = newPath(formFile);
                File.Move(sourcePath, result);
                return result;
            
        }
        public static string Update(string sourcePath, IFormFile formFile)
        {
            var path = newPath(formFile);
            using (var stream = new FileStream(path,FileMode.Create))
            {
                formFile.CopyTo(stream);
                stream.Flush();
            }
            File.Delete(sourcePath);
            return path;
            
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }


        public static string newPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + "\\wwwroot" + "\\images";

            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{ path}\{newPath}";
            return result;
        }

    }
}
