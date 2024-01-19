using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63135935.Models;

namespace Project_63135935.Controllers
{
    public class GioHangs_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: GioHangs_63135935

        string LayMaDH()
        {
            var maMax = db.GioHangs.Select(n => n.MaDH).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maSach = int.Parse(maMax.Substring(3)) + 1;
                string newMaSach = "MDH" + maSach.ToString("000");
                return newMaSach;
            }

            return "MDH001";
        }

        public ActionResult Index()
        {
            var gioHangs = db.GioHangs.Include(g => g.KhachHang).Include(g => g.NhanVien);
            return View(gioHangs.ToList());
        }

        // GET: GioHangs_63135935/Details/5
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

        // GET: GioHangs_63135935/Create
        public ActionResult Create(string idsach, string tensach)
        {
            // Lấy danh sách khách hàng và nhân viên từ cơ sở dữ liệu
            var khachHangs = db.KhachHangs.ToList();
            var nhanViens = db.NhanViens.ToList();
            ViewBag.idsach = tensach;

            // Tạo danh sách các mục chọn cho MaKH
            ViewBag.MaKH = new SelectList(khachHangs.Select(kh => new SelectListItem
            {
                Text = kh.HoKH + " " + kh.TenKH,
                Value = kh.MaKH.ToString()
            }), "Value", "Text");

            // Tạo danh sách các mục chọn cho MaNV
            ViewBag.MaNV = new SelectList(nhanViens.Select(nv => new SelectListItem
            {
                Text = nv.HoNV + " " + nv.TenNV,
                Value = nv.MaNV.ToString()
            }), "Value", "Text");

            return View();
        }


        // POST: GioHangs_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDH,NgayDat,MaKH,MaNV,Sodt,Diachigiaohang,Email,DuyetDH")] GioHang gioHang, string idsach)
        {
            var id = LayMaDH();

            if (ModelState.IsValid)
            {
                gioHang.MaDH = LayMaDH();
                gioHang.MaNV = "MNV003";
                gioHang.DuyetDH = false;
                gioHang.NgayDat = DateTime.Now;
                db.GioHangs.Add(gioHang);
                db.SaveChanges();
                return RedirectToAction("Create", "ChiTietGioHangs_63135935", new {idsach = idsach, idDH = id});
            }

            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", gioHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", gioHang.MaNV);
            return View(gioHang);
        }

        // GET: GioHangs_63135935/Edit/5
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
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", gioHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", gioHang.MaNV);
            return View(gioHang);
        }

        // POST: GioHangs_63135935/Edit/5
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
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", gioHang.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", gioHang.MaNV);
            return View(gioHang);
        }

        // GET: GioHangs_63135935/Delete/5
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

        // POST: GioHangs_63135935/Delete/5
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
