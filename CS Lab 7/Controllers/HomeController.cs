using CS_Lab_7.DAO;
using CS_Lab_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                GuestResponse guestResponse1 = dataBase.GuestResponses.SingleOrDefault(g => g.Email == guestResponse.Email);
                if (guestResponse == null)
                {
                    dataBase.GuestResponses.Add(guestResponse);
                    dataBase.SaveChanges();


                }
                else
                {
                    dataBase.GuestResponses.Where(g => g.Email == guestResponse.Email).SingleOrDefault().WillAttend = guestResponse.WillAttend;
                    dataBase.SaveChanges();                                   
                }
                

                return View("Thanks", guestResponse);
            }
                

            else return View();
        }
    }
}