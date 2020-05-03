using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Entities;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GUI.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private ILogger<HomeController> Logger { get; set; }
        private IConfiguration Configuration { get; set; }
        private CompleteGPSUtilityContext Context { get; set; }
        public UserManager<AppUser> UserManager { get; set; }
        public SignInManager<AppUser> SignInManager { get; set; }
        public LocationController(ILogger<HomeController> logger, IConfiguration configuration, CompleteGPSUtilityContext context,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            Logger = logger;
            Configuration = configuration;
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string imei, int y2kStart = int.MinValue, int y2kEnd = int.MaxValue, int howMany = 1000)
        {
            AppUser currentUser = await UserManager.GetUserAsync(User);

            Device device = await Context.Devices.FirstOrDefaultAsync(dev => dev.IMEI == imei);
            if (device == null)
            {
                Logger.LogWarning($"Imei not found: [{imei}] query by User: [{currentUser.Email}]");
                return BadRequest();
            }

            Access access = await Context.Accesses.FirstOrDefaultAsync(acc => acc.AppUser == currentUser && acc.Device == device);
            if (access == null)
            {
                Logger.LogWarning($"Access not granted for IMEI: [{imei}] to User: [{currentUser.Email}]");
                return BadRequest();
            }

            Location[] locations = await Context.Locations.Where(loc => loc.Device == device && loc.TimeY2K >= y2kStart && loc.TimeY2K <= y2kEnd)
                            .OrderByDescending(loc => loc.TimeY2K).Take(howMany).ToArrayAsync();

            return Ok(locations);
        }
    }
}