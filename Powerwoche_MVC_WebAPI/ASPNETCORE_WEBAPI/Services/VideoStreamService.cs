using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNETCORE_WEBAPI.Services
{
    public class VideoStreamService : IVideoStreamService
    {
        private HttpClient _client;

        public VideoStreamService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Stream> GetVideoByName(string name)
        {
            string urlBlob = string.Empty;

            switch (name)
            {
                case "fugees":
                    urlBlob = "http://gartner.gosimian.com/assets/videos/Fugees_ReadyOrNot_278-WIREDRIVE.mp4";
                    break;

                case "ard":
                    urlBlob = "https://www.ardmediathek.de/live/Y3JpZDovL2Rhc2Vyc3RlLmRlL0xpdmVzdHJlYW0tRGFzRXJzdGU/";
                    break;

                default:
                    break;
            }

            return await _client.GetStreamAsync(urlBlob);
        }

        //~VideoStreamService()
        //{
        //    if (_client != null)
        //        _client.Dispose();
        //}
    }
}
