using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiThucHanh2003.Models;

namespace BaiThucHanh2003.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Student std)
        {
            string kq = std.StudentCode + "-" + std.FullName +"-" + std.Address;
            ViewBag.mess = kq;
            return View();
        }
    }
} 