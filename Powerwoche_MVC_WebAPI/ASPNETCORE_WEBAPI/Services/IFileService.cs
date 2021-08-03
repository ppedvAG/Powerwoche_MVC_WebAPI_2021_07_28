using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI.Services
{
    public interface IFileService
    {
        void UploadFile(List<IFormFile> files, string subDirectory);

        (string fileType, byte[] archiveData, string achriveName) DownloadFiles(string subDirectory);

        string SizeConverter(long bytes);
    }
}
