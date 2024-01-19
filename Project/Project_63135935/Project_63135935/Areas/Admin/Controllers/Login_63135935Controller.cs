using Project_63135935.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Project_63135935.Areas.Admin.Controllers
{
    public class Login_63135935Controller : Controller
    {
        // GET: Admin/Login_63135935
        private Project_63135935Entities1 db = new Project_63135935Entities1();

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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var loginSingle = db.NhanViens.SqlQuery("SELECT * FROM NhanVien WHERE Email='" + username + "' AND Matkhau = '" + password + "'").SingleOrDefault();
            if (loginSingle == null)
            {
                ViewBag.error = "Email đăng Nhập hoặc mật khẩu của bạn không đúng";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "AdminSaches_63135935");
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.MaKh = LayMaKh();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "MaKH,HoKH,TenKH,DiaChi,SoDT,NgaySinh,GioiTinh,Email,Matkhau")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                khachHang.MaKH = LayMaKh();
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.error = "tài khoản có một số thông tin này đã được sử dụng";
            return View();
        }
    }
}