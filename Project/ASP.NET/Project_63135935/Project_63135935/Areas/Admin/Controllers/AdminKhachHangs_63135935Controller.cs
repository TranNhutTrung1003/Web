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
    public class AdminKhachHangs_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminKhachHangs_63135935

        string LayMaKh()
        {
            var maMax = db.KhachHangs.Select(n => n.MaKH).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maSach = int.Parse(maMax.Substring(3)) + 1;
                string newMaSach = "MKH" + maSach.ToString("000");
                return newMaSach;
            }

            return "MKH001";
        }

        public ActionResult Index()
        {
            return View(db.KhachHangs.ToList());
        }

        [HttpPost]
        public ActionResult Index(string tenKH)
        {
            var tenkh = db.KhachHangs.Where(s => s.TenKH.Contains(tenKH)).ToList();
            return View(tenkh);
        }

        // GET: Admin/AdminKhachHangs_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs_63135935/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminKhachHangs_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKH,HoKH,TenKH,DiaChi,SoDT,NgaySinh,GioiTinh,Email,Matkhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.MaKH = LayMaKh();
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index", "Login_63135935");
            }

            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/AdminKhachHangs_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKH,HoKH,TenKH,DiaChi,SoDT,NgaySinh,GioiTinh,Email,Matkhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: Admin/AdminKhachHangs_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: Admin/AdminKhachHangs_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
