using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_Project.Data;
using Shop_Project.Models;

namespace Shop_Project.Controllers

{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;
        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Log_Index()
        {
            return View();
        }
        public IActionResult Log(Login r)
        {
            var filtered = from l in _context.Login
                           where l.S_shopcode == r.S_shopcode && l.S_Password == r.S_Password
                           select l;

            foreach (var p in filtered)
            {
                string type = p.S_type;
               
                if (type == "Shop")
                {
                    TempData["S_id"] = p.S_id; // Save S_id to TempData
                    HttpContext.Session.SetInt32("S_id", p.S_id);
                    return new RedirectResult(url: "/Shop/Sh_Index", permanent: true, preserveMethod: true);
                }
                else if (type == "Admin")
                {
                    return new RedirectResult(url: "/Admin/Admin_Index", permanent: true, preserveMethod: true);
                }
            }

            return Ok();
        }



    }
}
