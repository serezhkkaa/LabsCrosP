﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Okta.AspNetCore;

namespace Lab5.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet("Login")]
        public IActionResult Login([FromQuery] string returnUrl)
        {
            var redirectUri = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;

            if (User.Identity.IsAuthenticated)
            {
                return LocalRedirect(redirectUri);
            }

            return Challenge();
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> Logout([FromQuery] string returnUrl)
        {
            var redirectUri = returnUrl is null ? Url.Content("~/") : "/" + returnUrl;

            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect(redirectUri);
            }

            await HttpContext.SignOutAsync();

            return LocalRedirect(redirectUri);
        }
    }
}
