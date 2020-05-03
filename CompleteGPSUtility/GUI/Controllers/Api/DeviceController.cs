using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Entities;
using Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GUI.Controllers.Api
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private  ILogger<HomeController> Logger { get; set; }
        private IConfiguration Configuration { get; set; }
        private CompleteGPSUtilityContext Context { get; set; }
        public UserManager<AppUser> UserManager { get; set; }

        public DeviceController(ILogger<HomeController> logger, IConfiguration configuration, CompleteGPSUtilityContext context, UserManager<AppUser> userManager)
        {
            Logger = logger;
            Configuration = configuration;
            Context = context;
            UserManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            AppUser currentUser = await GetCurrentUserAsync();

            Device[] devices = await Context.Devices.Where(dev => Context.Accesses.Any(acc => acc.AppUser.Id == currentUser.Id && acc.Device.DeviceId == dev.DeviceId) == true).ToArrayAsync();

            return Ok(devices);
        }
        private async Task<AppUser> GetCurrentUserAsync() => await UserManager.GetUserAsync(User);
    }
}