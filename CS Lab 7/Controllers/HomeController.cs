using CS_Lab_7.DAO;
using CS_Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS_Lab_7.Controllers
{
    
    public class HomeController : Controller
    {
        private GuestResponseContext dataBase = new GuestResponseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();

        }
        [HttpGet]
        public ViewResult RsvpForm() { return View(); }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                dataBase.GuestResponses.Add(guestResponse);
                dataBase.SaveChanges();
                return View("Thanks", guestResponse);
            }
                

            else return View();
        }
    }
}