using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
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
        ExcelProcess ExcelPro = new ExcelProcess();
        Autgenkey genkey = new Autgenkey();

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
            if (db.HangBans.OrderByDescending(m => m.MaHang).Count() == 0)
            {
                var newID = "SP01";
                ViewBag.newproID = newID;
            }
            else
            {
                var PdID = db.HangBans.OrderByDescending(m => m.MaHang).FirstOrDefault().MaHang;
                var newID = genkey.generatekey(PdID, 2);
                ViewBag.newproID = newID;
            }            
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
        private DataTable CopyDataFromExcelFile(HttpPostedFileBase file)
        {
            string fileExtention = file.FileName.Substring(file.FileName.IndexOf("."));
            string _FileName = "Ten_File_Muon_Luu" + fileExtention;
            string _path = Path.Combine(Server.MapPath("~/Upload/Excels"), _FileName);
            file.SaveAs(_path);
            DataTable dt = ExcelPro.ReadDataFromExcelFile(_path, false);
            return dt;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HANGHOADBContext"].ConnectionString);
        private void OverwriteFastData(int? ArticleID)
        {
            //dt là databasecos chứa dữ liệu để import vào database
            DataTable dt = new DataTable();

            //mapping các column trong database vào các column trong table ở CSDL
            SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
            bulkcopy.DestinationTableName = "HangBan";
            bulkcopy.ColumnMappings.Add(0, "MaHang");
            bulkcopy.ColumnMappings.Add(1, "ViTri");
            bulkcopy.ColumnMappings.Add(2, "SoLuong");
            bulkcopy.ColumnMappings.Add(2, "DonGia");
            bulkcopy.ColumnMappings.Add(2, "ThanhTien");
            bulkcopy.ColumnMappings.Add(2, "HanSD");
            con.Open();
            bulkcopy.WriteToServer(dt);
            con.Close();
        }
    }
}
