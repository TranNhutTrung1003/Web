using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63135935.Models;

namespace Project_63135935.Areas.Admin.Controllers
{
    public class AdminChiTietGioHangs_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminChiTietGioHangs_63135935
        public ActionResult Index()
        {
            var chiTietGioHangs = db.ChiTietGioHangs.Include(c => c.Sach).Include(c => c.GioHang);
            return View(chiTietGioHangs.ToList());
        }

        // GET: Admin/AdminChiTietGioHangs_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietGioHang chiTietGioHang = db.ChiTietGioHangs.Find(id);
            if (chiTietGioHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietGioHang);
        }

        // GET: Admin/AdminChiTietGioHangs_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach");
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH");
            return View();
        }

        // POST: Admin/AdminChiTietGioHangs_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,MaSach,SoLuong,ThanhTien,GiaBan")] ChiTietGioHang chiTietGioHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietGioHangs.Add(chiTietGioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach", chiTietGioHang.MaSach);
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH", chiTietGioHang.MaDH);
            return View(chiTietGioHang);
        }

        // GET: Admin/AdminChiTietGioHangs_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietGioHang chiTietGioHang = db.ChiTietGioHangs.Find(id);
            if (chiTietGioHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach", chiTietGioHang.MaSach);
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH", chiTietGioHang.MaDH);
            return View(chiTietGioHang);
        }

        // POST: Admin/AdminChiTietGioHangs_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,MaSach,SoLuong,ThanhTien,GiaBan")] ChiTietGioHang chiTietGioHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietGioHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach", chiTietGioHang.MaSach);
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH", chiTietGioHang.MaDH);
            return View(chiTietGioHang);
        }

        // GET: Admin/AdminChiTietGioHangs_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietGioHang chiTietGioHang = db.ChiTietGioHangs.Find(id);
            if (chiTietGioHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietGioHang);
        }

        // POST: Admin/AdminChiTietGioHangs_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietGioHang chiTietGioHang = db.ChiTietGioHangs.Find(id);
            db.ChiTietGioHangs.Remove(chiTietGioHang);
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
