using Microsoft.AspNetCore.Mvc;
using SuperAdminEntity.Models;
using SuperAdminEntity.Repository;
using System.Diagnostics.Contracts;

namespace SuperAdminEntity.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataAccess _dal;
        public AdminController(DataAccess dal)
        {
            _dal = dal;
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            //List<ModDashBoard> dashlist = new List<ModDashBoard>();
            //dashlist = await _contractList.Dashboardvalue();
            //if (dashlist.Count > 0)
            //{
            //    ViewBag.Model = dashlist.AsEnumerable();
            //}
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            List<Tbl_DomainMaster> obj2 = await _dal.GetDomain();
            ViewBag.DomainList = obj2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ModChangePass obj)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(obj.OldPassword) && !string.IsNullOrEmpty(obj.NewPassword) && !string.IsNullOrEmpty(obj.ConfPassword))
            {
                msg = await _dal.ChangeAdminPassword(obj);
            }
            else
            {
                msg = "All Field Required....!";
            }
            ViewBag.Msg = msg;
            List<Tbl_DomainMaster> obj2 = await _dal.GetDomain();
            ViewBag.DomainList = obj2;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddDomain()
        {
            List<Tbl_DomainMaster> obj = new List<Tbl_DomainMaster>();
            obj = await _dal.GetDomain();
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> AddDomain(Tbl_DomainMaster obj)
        {
            if (await _dal.AddDomain(obj))
            {
                ModelState.Clear();
                ViewBag.SuccessMessage = "Domain Added Successfully";
                ViewBag.ErrorMessage = null;
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to Add Domain";
                ViewBag.SuccessMessage = null;
            }
            List<Tbl_DomainMaster> obj1 = new List<Tbl_DomainMaster>();
            obj1 = await _dal.GetDomain();
            return View(obj1);
        }
    }
}
