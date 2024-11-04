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
    public class Saches_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Saches_63135935

        public ActionResult ShowBooksByCategory(string idcategory)
        {
            var bookincategory = db.Saches.SqlQuery("SELECT * FROM Sach WHERE MaLoaiSach='" + idcategory + "'");
            return View(bookincategory.ToList());
        }

        public ActionResult Aboutus()
        {
            var nhanviens = db.NhanViens.Include(n => n.Chucvu);
            return View(nhanviens);
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Index()
        {
            var saches = db.Saches.Include(s => s.LoaiSach);
            return View(saches.ToList());
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var saches = db.Saches.Where(s => s.TenSach.Contains(search)).ToList();
            return View(saches);
        }

        // GET: Saches_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Saches_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach");
            return View();
        }

        // POST: Saches_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaLoaiSach,TenSach,AnhSach,DonGia,TacGia,NhaXuatBan,Mota,NgayXuatBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            return View(sach);
        }

        // GET: Saches_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            return View(sach);
        }

        // POST: Saches_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaLoaiSach,TenSach,AnhSach,DonGia,TacGia,NhaXuatBan,Mota,NgayXuatBan")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            return View(sach);
        }

        // GET: Saches_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Saches_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
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
