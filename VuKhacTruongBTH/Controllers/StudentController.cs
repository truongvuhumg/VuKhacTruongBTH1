using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VuKhacTruongBTH.Models;

namespace VuKhacTruongBTH.Controllers;

public class StudentController : Controller
{
  

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index (string FullName)
    {
        string strReturn = "HELLO"  + FullName ;
        // gui du lieu ve view 
        ViewBag.abc= strReturn;
        return View();
    }
}