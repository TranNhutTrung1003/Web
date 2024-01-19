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
    public class ChiTietGioHangs_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: ChiTietGioHangs_63135935

        string LayMaCT()
        {
            var maMax = db.ChiTietGioHangs.Select(n => n.MaCTGH).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maSach = int.Parse(maMax.Substring(3)) + 1;
                string newMaSach = "MCT" + maSach.ToString("000");
                return newMaSach;
            }

            return "MCT001";
        }

        public ActionResult Index()
        {
            var chiTietGioHangs = db.ChiTietGioHangs.Include(c => c.Sach).Include(c => c.GioHang);
            return View(chiTietGioHangs.ToList());
        }

        // GET: ChiTietGioHangs_63135935/Details/5
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

        // GET: ChiTietGioHangs_63135935/Create
        public ActionResult Create(string idsach, string idDH)
        {
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach");
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH");
            return View();
        }

        // POST: ChiTietGioHangs_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTGH,MaDH,MaSach,SoLuong,ThanhTien,GiaBan")] ChiTietGioHang chiTietGioHang, string idsach, string idDH)
        {
            var donGiaQuery = db.Database.SqlQuery<decimal>("select DonGia from Sach where MaSach = @p0", idsach);

            decimal? donGia = donGiaQuery.FirstOrDefault();

            if (ModelState.IsValid)
            {
                chiTietGioHang.MaDH = idDH;
                chiTietGioHang.MaSach = idsach;
                chiTietGioHang.MaCTGH = LayMaCT();
                chiTietGioHang.GiaBan = donGia.Value;
                chiTietGioHang.ThanhTien = Convert.ToDecimal(chiTietGioHang.GiaBan * chiTietGioHang.SoLuong);
                if (!string.IsNullOrEmpty(chiTietGioHang.MaDH))
                {
                    db.ChiTietGioHangs.Add(chiTietGioHang);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Saches_63135935");
                }
            }

            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "MaLoaiSach", chiTietGioHang.MaSach);
            ViewBag.MaDH = new SelectList(db.GioHangs, "MaDH", "MaKH", chiTietGioHang.MaDH);
            return View(chiTietGioHang);
        }

        // GET: ChiTietGioHangs_63135935/Edit/5
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

        // POST: ChiTietGioHangs_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTGH,MaDH,MaSach,SoLuong,ThanhTien,GiaBan")] ChiTietGioHang chiTietGioHang)
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

        // GET: ChiTietGioHangs_63135935/Delete/5
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

        // POST: ChiTietGioHangs_63135935/Delete/5
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
