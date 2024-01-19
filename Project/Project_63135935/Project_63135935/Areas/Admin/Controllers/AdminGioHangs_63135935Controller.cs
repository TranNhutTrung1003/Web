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
    public class AdminGioHangs_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminGioHangs_63135935
        public ActionResult Index()
        {
            var gioHangs = db.GioHangs.Include(g => g.KhachHang).Include(g => g.NhanVien);
            return View(gioHangs.ToList());
        }

        // GET: Admin/AdminGioHangs_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // GET: Admin/AdminGioHangs_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV");
            return View();
        }

        // POST: Admin/AdminGioHangs_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,NgayDat,MaKH,MaNV,Sodt,Diachigiaohang,Email,DuyetDH")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.GioHangs.Add(gioHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", gioHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", gioHang.MaNV);
            return View(gioHang);
        }

        // GET: Admin/AdminGioHangs_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }

            var khachHangs = db.KhachHangs.ToList();
            var nhanViens = db.NhanViens.ToList();

            ViewBag.MaKH = new SelectList(khachHangs.Select(kh => new SelectListItem
            {
                Text = kh.HoKH + " " + kh.TenKH,
                Value = kh.MaKH.ToString()
            }), "Value", "Text", gioHang.MaKH);

            ViewBag.MaNV = new SelectList(nhanViens.Select(nv => new SelectListItem
            {
                Text = nv.HoNV + " " + nv.TenNV,
                Value = nv.MaNV.ToString()
            }), "Value", "Text", gioHang.MaNV);

            return View(gioHang);
        }

        // POST: Admin/AdminGioHangs_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDH,NgayDat,MaKH,MaNV,Sodt,Diachigiaohang,Email,DuyetDH")] GioHang gioHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gioHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "AdminChiTietGioHangs_63135935");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", gioHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", gioHang.MaNV);

            return View(gioHang);
        }

        // GET: Admin/AdminGioHangs_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GioHang gioHang = db.GioHangs.Find(id);
            if (gioHang == null)
            {
                return HttpNotFound();
            }
            return View(gioHang);
        }

        // POST: Admin/AdminGioHangs_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GioHang gioHang = db.GioHangs.Find(id);
            db.GioHangs.Remove(gioHang);
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
