using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using Core.Utilities.Messages;
using Core.Utilities.Responses;
using System.Collections.Generic;

namespace WebAPIWithCoreMvc.Helpers
{
    public class HelperMethods
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HelperMethods(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> FileUpload(IFormFile file)
        {
            string url = String.Empty;
            string uploadsFolder = String.Empty;
            string ImagePath = String.Empty;
            string filePath = String.Empty;

            if (file == null)
            {
                using (var stream = File.OpenRead(Constants.DefaultProfileImageUrl))
                {
                    FormFile _formFile = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name))
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/jpg"
                    };
                    url = _formFile.FileName;
                    uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Upload");
                    ImagePath = Guid.NewGuid().ToString() + "_" + url;
                    filePath = Path.Combine(uploadsFolder, ImagePath);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        await _formFile.CopyToAsync(fs);
                    }
                }
            }
            else
            {
                url = file.FileName;
                uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Upload");
                ImagePath = Guid.NewGuid().ToString() + "_" + url;
                filePath = Path.Combine(uploadsFolder, ImagePath);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
            }


            return filePath;
        }

        public static List<string> ErrorList<T>(ApiDataResponse<T> result)
        {
            string[] errors = result.Message.Split(";");
            List<string> errorList = new List<string>();
            foreach (string error in errors)
            {
                if (!String.IsNullOrEmpty(error))
                    errorList.Add(error);
            }
            return errorList;
        }
    }
}
