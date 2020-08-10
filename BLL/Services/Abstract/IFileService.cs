using BLL.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Abstract
{
    public interface IFileService
    {
        Task UplodFileAsync(IFormFile file);
    }
}
