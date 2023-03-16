using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pristinerealty.Entity;
using Pristinerealty.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Pristinerealty.Web.Pages
{
    public class LoginModel : PageModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        private readonly ILoginRepository loginRepository;


        public LoginModel(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;


        }

        public void OnGet()
        {
        }




        public async Task<ActionResult> OnPost([Bind] Login userdetails)
        {



            if ((!string.IsNullOrEmpty(userdetails.UserName)) && (!string.IsNullOrEmpty(userdetails.Password)))
            {
                var userLoginFind = await loginRepository.FindLogin(userdetails);

                if (userLoginFind == 1)
                {
                    var getsessionid = await loginRepository.getSessionRank(userdetails);

                    foreach (var sessionVal in getsessionid)
                    {

                        HttpContext.Session.SetString("username", sessionVal.UserName);
                        HttpContext.Session.SetString("password", sessionVal.Password);

                    }
                }


                if ((userdetails.UserName.Equals(HttpContext.Session.GetString("username")) && userdetails.Password.Equals(HttpContext.Session.GetString("password"))))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userdetails.UserName),
                    new Claim(ClaimTypes.Role, "Admin"),
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);


                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(10),
                    };

                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                    //  return RedirectToPage("~/Admin/Index");
                    return Redirect("~/Admin/Index");

                }

            }
            return RedirectToPage("/Index");
        }



        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }



    }

}

