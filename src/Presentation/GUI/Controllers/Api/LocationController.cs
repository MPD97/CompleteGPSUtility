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
        private CompleteGPSUtilityContext Context { get; set; }
        public UserManager<AppUser> UserManager { get; set; }
        public SignInManager<AppUser> SignInManager { get; set; }

        public LocationController(ILogger<HomeController> logger, CompleteGPSUtilityContext context,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            Logger = logger;
            Context = context;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string imei, int y2kStart = int.MinValue, int y2kEnd = int.MaxValue, int howMany = 1000)
        {
            AppUser currentUser = await UserManager.GetUserAsync(User);

            Device device = await Context.Devices.SingleOrDefaultAsync(dev => dev.IMEI == imei);
            if (device == null)
            {
                Logger.LogWarning($"Imei not found: [{imei}] query by User: [{currentUser.Email}]");
                return BadRequest();
            }

            Access access = await Context.Accesses.SingleOrDefaultAsync(acc => acc.AppUser == currentUser && acc.Device == device);
            if (access == null)
            {
                Logger.LogWarning($"Access not granted for IMEI: [{imei}] to User: [{currentUser.Email}]");
                return BadRequest();
            }

            Location[] locations = await Context.Locations.Where(loc => loc.Device == device && loc.TimeFrom2000 >= y2kStart && loc.TimeFrom2000 <= y2kEnd)
                            .OrderByDescending(loc => loc.TimeFrom2000).Take(howMany).ToArrayAsync();

            return Ok(locations);
        }
    }
}