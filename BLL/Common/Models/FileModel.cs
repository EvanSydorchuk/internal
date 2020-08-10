using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Common.Models
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public IFormFile File { get; set; }
    }
}
