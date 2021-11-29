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
    public class NVBanHangsController : Controller
    {
        private HANGHOADBContext db = new HANGHOADBContext();

        // GET: NVBanHangs
        public ActionResult Index()
        {
            return View(db.NVBanHangs.ToList());
        }

        // GET: NVBanHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVBanHang nVBanHang = db.NVBanHangs.Find(id);
            if (nVBanHang == null)
            {
                return HttpNotFound();
            }
            return View(nVBanHang);
        }

        // GET: NVBanHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NVBanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,TenNV,DCNV,SoDienThoai")] NVBanHang nVBanHang)
        {
            if (ModelState.IsValid)
            {
                db.NVBanHangs.Add(nVBanHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nVBanHang);
        }

        // GET: NVBanHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVBanHang nVBanHang = db.NVBanHangs.Find(id);
            if (nVBanHang == null)
            {
                return HttpNotFound();
            }
            return View(nVBanHang);
        }

        // POST: NVBanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,TenNV,DCNV,SoDienThoai")] NVBanHang nVBanHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nVBanHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nVBanHang);
        }

        // GET: NVBanHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NVBanHang nVBanHang = db.NVBanHangs.Find(id);
            if (nVBanHang == null)
            {
                return HttpNotFound();
            }
            return View(nVBanHang);
        }

        // POST: NVBanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NVBanHang nVBanHang = db.NVBanHangs.Find(id);
            db.NVBanHangs.Remove(nVBanHang);
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
