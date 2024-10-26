using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SuperAdminEntity.EF;
using SuperAdminEntity.Models;
using SuperAdminEntity.Repository;

namespace SuperAdminEntity.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataAccess _dal;
        public LoginController(DataAccess dal)
        {
            _dal = dal;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(ControlMst obj)
        {
            if (!string.IsNullOrEmpty(obj.username) || !string.IsNullOrEmpty(obj.password))
            {
                if (await _dal.SignInAsync(obj))
                {
                    HttpContext.Session.SetString("username", obj.username);
                    HttpContext.Session.SetString("Password", obj.password);
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ViewBag.Message = "Login Failed";
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Login");
        }
    }
}
