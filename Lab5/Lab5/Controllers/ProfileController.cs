using Lab5.Models;
using Lab5.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Lab5.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly OktaApiService _oktaApiService;

        public ProfileController(IConfiguration configuration)
        {
            _oktaApiService = new OktaApiService(configuration["Okta:apiToken"] ?? "00aw1X1acEPxXOq2vxBI-FVZrxUbiNeEAK6lyWQT7X", configuration);
        }

        public async Task<IActionResult> Index()
        {
            var user = await _oktaApiService.GetUserAsync(User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value ?? string.Empty);

            var userClaims = User.Claims ?? new List<Claim>();

            return View(user);
        }
    }
}
