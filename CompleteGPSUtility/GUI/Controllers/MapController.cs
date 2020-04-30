using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GUI.Controllers
{
    [Authorize]
    public class MapController : Controller
    {
        public IConfiguration Configuration { get; set; }
        public  ILogger<MapController> Logger { get; set; }

        public MapController(IConfiguration configuration, ILogger<MapController> logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(Configuration["OSM-Server:URL"]))
            {
                Logger.LogError($"Configuration file has not defined URL of OSM-Server.");
                ViewData["OSM-Server"] = "http://localhost:8080";

            }
            else
            {
                ViewData["OSM-Server"] = Configuration["OSM-Server:URL"];

            }
            return View();
        }
    }
}