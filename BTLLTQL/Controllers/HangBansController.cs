using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLLTQL.Models;

namespace BTLLTQL.Controllers
{
    public class HangBansController : Controller
    {
        private HANGHOADBContext db = new HANGHOADBContext();

        // GET: HangBans
        public ActionResult Index()
        {
            return View(db.HangBans.ToList());
        }

        // GET: HangBans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangBan hangBan = db.HangBans.Find(id);
            if (hangBan == null)
            {
                return HttpNotFound();
            }
            return View(hangBan);
        }

        // GET: HangBans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HangBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHang,TenHang,ViTri,SoLuong,DonGia,ThanhTien,HanSD")] HangBan hangBan)
        {
            if (ModelState.IsValid)
            {
                db.HangBans.Add(hangBan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hangBan);
        }

        // GET: HangBans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangBan hangBan = db.HangBans.Find(id);
            if (hangBan == null)
            {
                return HttpNotFound();
            }
            return View(hangBan);
        }

        // POST: HangBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHang,TenHang,ViTri,SoLuong,DonGia,ThanhTien,HanSD")] HangBan hangBan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangBan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hangBan);
        }

        // GET: HangBans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HangBan hangBan = db.HangBans.Find(id);
            if (hangBan == null)
            {
                return HttpNotFound();
            }
            return View(hangBan);
        }

        // POST: HangBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HangBan hangBan = db.HangBans.Find(id);
            db.HangBans.Remove(hangBan);
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
