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
    public class AdminLoaiSaches_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminLoaiSaches_63135935

        string LayMaLS()
        {
            var maMax = db.LoaiSaches.Select(n => n.MaLoaiSach).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maNV = int.Parse(maMax.Substring(3)) + 1;
                string newMaNV = "MLS" + maNV.ToString("000");
                return newMaNV;
            }

            return "MLS001";
        }

        public ActionResult Index()
        {
            return View(db.LoaiSaches.ToList());
        }

        // GET: Admin/AdminLoaiSaches_63135935/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // GET: Admin/AdminLoaiSaches_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaLS = LayMaLS();
            return View();
        }

        // POST: Admin/AdminLoaiSaches_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                loaiSach.MaLoaiSach = LayMaLS();
                db.LoaiSaches.Add(loaiSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loaiSach);
        }

        // GET: Admin/AdminLoaiSaches_63135935/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: Admin/AdminLoaiSaches_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSach,TenLoaiSach")] LoaiSach loaiSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loaiSach);
        }

        // GET: Admin/AdminLoaiSaches_63135935/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            if (loaiSach == null)
            {
                return HttpNotFound();
            }
            return View(loaiSach);
        }

        // POST: Admin/AdminLoaiSaches_63135935/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoaiSach loaiSach = db.LoaiSaches.Find(id);
            db.LoaiSaches.Remove(loaiSach);
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
