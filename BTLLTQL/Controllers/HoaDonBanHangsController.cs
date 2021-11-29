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
    public class HoaDonBanHangsController : Controller
    {
        private HANGHOADBContext db = new HANGHOADBContext();

        // GET: HoaDonBanHangs
        public ActionResult Index()
        {
            var hoaDonBanhangs = db.HoaDonBanhangs.Include(h => h.HangBan);
            return View(hoaDonBanhangs.ToList());
        }

        // GET: HoaDonBanHangs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanhangs.Find(id);
            if (hoaDonBanHang == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHang = new SelectList(db.HangBans, "MaHang", "TenHang");
            return View();
        }

        // POST: HoaDonBanHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,NgayBan,MaHang,SoLuong,DonGia,ThanhTien")] HoaDonBanHang hoaDonBanHang)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonBanhangs.Add(hoaDonBanHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHang = new SelectList(db.HangBans, "MaHang", "TenHang", hoaDonBanHang.MaHang);
            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHangs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanhangs.Find(id);
            if (hoaDonBanHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHang = new SelectList(db.HangBans, "MaHang", "TenHang", hoaDonBanHang.MaHang);
            return View(hoaDonBanHang);
        }

        // POST: HoaDonBanHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,NgayBan,MaHang,SoLuong,DonGia,ThanhTien")] HoaDonBanHang hoaDonBanHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonBanHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHang = new SelectList(db.HangBans, "MaHang", "TenHang", hoaDonBanHang.MaHang);
            return View(hoaDonBanHang);
        }

        // GET: HoaDonBanHangs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanhangs.Find(id);
            if (hoaDonBanHang == null)
            {
                return HttpNotFound();
            }
            return View(hoaDonBanHang);
        }

        // POST: HoaDonBanHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanhangs.Find(id);
            db.HoaDonBanhangs.Remove(hoaDonBanHang);
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
