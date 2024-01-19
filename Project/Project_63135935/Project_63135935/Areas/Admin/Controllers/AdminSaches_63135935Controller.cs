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
    public class AdminSaches_63135935Controller : Controller
    {
        private Project_63135935Entities1 db = new Project_63135935Entities1();

        // GET: Admin/AdminSaches_63135935

        string LayMaSach()
        {
            var maMax = db.Saches.Select(n => n.MaSach).OrderByDescending(ma => ma).FirstOrDefault();

            if (maMax != null)
            {
                int maSach = int.Parse(maMax.Substring(3)) + 1;
                string newMaSach = "MSS" + maSach.ToString("000");
                return newMaSach;
            }

            return "MSS001";
        }

        public ActionResult Index()
        {
            var saches = db.Saches.Include(s => s.LoaiSach);
            return View(saches.ToList());
        }

        [HttpPost]
        public ActionResult Index(string tenSach)
        {
            var tensaches = db.Saches.Where(s => s.TenSach.Contains(tenSach)).ToList();
            return View(tensaches);
        }

        // GET: Admin/AdminSaches_63135935/Details/5
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

        // GET: Admin/AdminSaches_63135935/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = LayMaSach();
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach");
            return View();
        }

        // POST: Admin/AdminSaches_63135935/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaLoaiSach,TenSach,AnhSach,DonGia,TacGia,NhaXuatBan,Mota,NgayXuatBan")] Sach sach)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgSach = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSach.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSach.SaveAs(path);

            if (ModelState.IsValid)
            {
                sach.MaSach = LayMaSach();
                sach.AnhSach = postedFileName;
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            return View(sach);
        }

        // GET: Admin/AdminSaches_63135935/Edit/5
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

        // POST: Admin/AdminSaches_63135935/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaLoaiSach,TenSach,AnhSach,DonGia,TacGia,NhaXuatBan,Mota,NgayXuatBan")] Sach sach)
        {
            var imgSach = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgSach.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                imgSach.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LoaiSaches, "MaLoaiSach", "TenLoaiSach", sach.MaLoaiSach);
            return View(sach);
        }

        // GET: Admin/AdminSaches_63135935/Delete/5
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

        // POST: Admin/AdminSaches_63135935/Delete/5
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
