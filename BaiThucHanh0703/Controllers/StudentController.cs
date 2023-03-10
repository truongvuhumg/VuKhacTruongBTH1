using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaiThucHanh0703.Models;

namespace BaiThucHanh0703.Controllers;

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
    public IActionResult GiaiPhuongTrinhBac2 (string hesoA,string hesob, string hesoc)
    {
        // khai baso bien
        double delta , x1 ,x2, a = 0 ,b = 0,c = 0;
        string ketqua ;
        // giai phuong trinh bac 2 
        if (a == 0)
        {
            ketqua = "khong phai phuong trinh bac 2";
        }
     
            // tinjsnh delta
            delta  = Math.Pow(b,2) - 4*a *c;
            
            if ( delta == 0 )
            {
                x1 = (-b)/2*a;
                ketqua = "phuong trình có nghiệm 1 nghiem  : " + x1;
            }
            

            else if (delta > 0)
            {
                x1 = (-b+Math.Sqrt(delta))/(2*a);
                x2 = (-b-Math.Sqrt(delta))/(2*a);
                ketqua = "phuong trinh co 2 nghiem x1 , x2 : " + x1 + x2 ; 
            
            }
            else
            {
                ketqua = "phuong trinh vo nghiem ";
            }
            ViewBag.RenderKetqua = ketqua ;
            return View();
    }
          
        
}
    
