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
    public class AdminNhanViens_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminNhanViens_63135935

        string LayMaNV()
        {
            var maMax = db.NhanViens.Select(n => n.MaNV).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maNV = int.Parse(maMax.Substring(3)) + 1;
                string newMaNV = "MNV" + maNV.ToString("000");
                return newMaNV;
            }

            return "MNV001";
        }

        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.Chucvu);
            return View(nhanViens.ToList());
        }

        [HttpPost]
        public ActionResult Index(string tenNV)
        {
            var tennv = db.NhanViens.Where(s => s.TenNV.Contains(tenNV)).ToList();
            return View(tennv);
        }

        // GET: Admin/AdminNhanViens_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: Admin/AdminNhanViens_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = LayMaNV();
            ViewBag.Ma_CV = new SelectList(db.Chucvus, "MaCV", "tenchucvu");
            return View();
        }

        // POST: Admin/AdminNhanViens_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNV,HoNV,TenNV,SoDT,Email,GioiTinh,DiaChi,Matkhau,Ma_CV,ngaysinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.MaNV = LayMaNV();
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_CV = new SelectList(db.Chucvus, "MaCV", "tenchucvu", nhanVien.Ma_CV);
            return View(nhanVien);
        }

        // GET: Admin/AdminNhanViens_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_CV = new SelectList(db.Chucvus, "MaCV", "tenchucvu", nhanVien.Ma_CV);
            return View(nhanVien);
        }

        // POST: Admin/AdminNhanViens_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNV,HoNV,TenNV,SoDT,Email,GioiTinh,DiaChi,Matkhau,Ma_CV,ngaysinh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_CV = new SelectList(db.Chucvus, "MaCV", "tenchucvu", nhanVien.Ma_CV);
            return View(nhanVien);
        }

        // GET: Admin/AdminNhanViens_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: Admin/AdminNhanViens_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
