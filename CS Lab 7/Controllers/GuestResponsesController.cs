using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CS_Lab_7.DAO;
using CS_Lab_7.Models;

namespace CS_Lab_7.Controllers
{
    public class GuestResponsesController : Controller
    {
        private GuestResponseContext db = new GuestResponseContext();

        // GET: GuestResponses
        public ActionResult Index()
        {
            return View(db.GuestResponses.ToList());
        }

        // GET: GuestResponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestResponse guestResponse = db.GuestResponses.Find(id);
            if (guestResponse == null)
            {
                return HttpNotFound();
            }
            return View(guestResponse);
        }

        // GET: GuestResponses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GuestResponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestResponseID,Name,Email,Phone,WillAttend")] GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                db.GuestResponses.Add(guestResponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestResponse);
        }

        // GET: GuestResponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestResponse guestResponse = db.GuestResponses.Find(id);
            if (guestResponse == null)
            {
                return HttpNotFound();
            }
            return View(guestResponse);
        }

        // POST: GuestResponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestResponseID,Name,Email,Phone,WillAttend")] GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestResponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestResponse);
        }

        // GET: GuestResponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GuestResponse guestResponse = db.GuestResponses.Find(id);
            if (guestResponse == null)
            {
                return HttpNotFound();
            }
            return View(guestResponse);
        }

        // POST: GuestResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestResponse guestResponse = db.GuestResponses.Find(id);
            db.GuestResponses.Remove(guestResponse);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
