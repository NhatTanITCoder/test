using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLTN_QuanLyLuuTruHoSo.Models;
namespace KLTN_QuanLyLuuTruHoSo.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        QLLuuTruHoSoDataContext data = new QLLuuTruHoSoDataContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginHandling(FormCollection c)
        {
            string tk = c["txtUserName"];
            string mk = c["txtPassWord"];
            // vào csdl trong bảng Khách hàng tìm record có tên và mk trùng thông tin nhập
            USER us = data.USERs.SingleOrDefault(t => t.USERNAME == tk && t.PASSWORD == mk);
            if (us == null)
            {
                ViewBag.errorMassage = "Thông tin tài khoản hoặc mật khẩu không chính xác!";
                return View("Index");
            }
            else
            {
                Session["user"] = us;
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
