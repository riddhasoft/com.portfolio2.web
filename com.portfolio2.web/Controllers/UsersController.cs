using com.portfolio2.web.Controllers.ViewModel;
using com.portfolio2.web.Data;
using com.portfolio2.web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace com.portfolio2.web.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private ISession currentSession;
        private comportfolio2webContext _context;

        public UsersController(comportfolio2webContext context)
        {
            //currentSession = HttpContext.Session;//euta tarika
            _context = context;
        }
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                _context.SaveChanges();

                return Redirect("/Users/Login");
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _context.Users
                                    .Where(x => x.Email == model.Username && x.Password == model.Password).FirstOrDefault();
                if (user != null)
                {
                    //login success
                    HttpContext.Session.SetString("email", model.Username);
                    HttpContext.Session.SetString("fullname", user.FullName);

                    addingClaimIdentity(model);

                    return Redirect("/UserProfiles");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid Username or Password");
                    return View();
                }
            }
            return View();
        }
        private void addingClaimIdentity(LoginViewModel user)
        {
            //list of claims
            var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.Username),
                    new Claim(ClaimTypes.Email,user.Username),
                    
                    new Claim(ClaimTypes.Role,"user"),
                    new Claim(ClaimTypes.Role,"admin")
                 };

            //create a identity claims
            var claimsIdentity = new ClaimsIdentity(
            userClaims, CookieAuthenticationDefaults.AuthenticationScheme);


            //httcontext , current user is authentic user
            //sing in user to httpcontext
            HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity)
            );
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
