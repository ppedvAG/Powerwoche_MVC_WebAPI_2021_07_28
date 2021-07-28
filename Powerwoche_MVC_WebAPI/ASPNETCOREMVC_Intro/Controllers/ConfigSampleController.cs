using ASPNETCOREMVC_Intro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC_Intro.Controllers
{
    public class ConfigSampleController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SampleWebSettings _sampleWebSettings;
        public ConfigSampleController(IConfiguration configuration, IOptions<SampleWebSettings> settingOptions)
        {
            _configuration = configuration;
            _sampleWebSettings = settingOptions.Value;
        }

        public IActionResult Index()
        {
            PositionOptions positionOptions = new();
            _configuration.GetSection(PositionOptions.StringPosition).Bind(positionOptions);

            return View(positionOptions);
        }

        public IActionResult OptionsSample()
        {
            return View(_sampleWebSettings);
        }
    }
}
