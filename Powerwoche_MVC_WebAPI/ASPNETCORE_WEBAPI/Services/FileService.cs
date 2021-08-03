using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI.Services
{
    public class FileService : IFileService
    {
        private IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public (string fileType, byte[] archiveData, string achriveName) DownloadFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            IList<string> files = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory)).ToList();

            byte[] compressBytes = GetZipArchive(files);


            return ("application/zip", compressBytes, zipName);
        }



       

        public void UploadFile(List<IFormFile> files, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;

            string targetDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, subDirectory);

            Directory.CreateDirectory(targetDirectory);

            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;

                string filePath = Path.Combine(targetDirectory, file.FileName);

                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            });
        }



        private InMemoryFile LoadFromFile(string path)
        {
            using var fs = File.OpenRead(path);

            using var memFile = new MemoryStream();

            fs.CopyTo(memFile);

            memFile.Seek(0, SeekOrigin.Begin);

            return new InMemoryFile() { Content = memFile.ToArray(), FileName = Path.GetFileName(path) };
        }

        private byte[] GetZipArchive(IList<string> filePaths)
        {
            List<InMemoryFile> files = new List<InMemoryFile>();

            foreach (string file in filePaths)
                files.Add(LoadFromFile(file));

            byte[] archiveFile;

            using (MemoryStream archiveStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach(InMemoryFile currentInMemoryFile in files)
                    {
                        ZipArchiveEntry zipArchiveEntry = archive.CreateEntry(currentInMemoryFile.FileName, CompressionLevel.Optimal);

                        using Stream zipStream = zipArchiveEntry.Open();

                        zipStream.Write(currentInMemoryFile.Content, 0, currentInMemoryFile.Content.Length);
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }


        #region Size Converter
        public string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
        #endregion
    }

    class InMemoryFile
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }
}
