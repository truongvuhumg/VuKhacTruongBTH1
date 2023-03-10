using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VuKhacTruongBTH.Models;

namespace VuKhacTruongBTH.Controllers;

public class EmployeeController : Controller
{
   
    

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}