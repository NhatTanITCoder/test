using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLTN_QuanLyLuuTruHoSo.Models;

namespace KLTN_QuanLyLuuTruHoSo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QLLuuTruHoSoDataContext data = new QLLuuTruHoSoDataContext();
        public ActionResult Index()
        {
            return View();
        }
        //Load danh mục menu
        public ActionResult GetMenuList()
        {
            //USER us = Session["user"] as USER;
            //try
            //{
            //    if (us.ID_CHUCVU == 1)
            //    {
            //        List<GROUPMENU> gm = data.GROUPMENUs.ToList();
            //        List<MENU> mn = data.MENUs.ToList();
            //        var obj = (from g in gm
            //                   join m in mn on g.ID equals m.ID_GROUP
            //                   select new Menu_List
            //                   {
            //                       id_group = g.ID,
            //                       id_groupmenu = m.ID_GROUP,
            //                       groupname = g.GROUPNAME,
            //                       idmenu = m.ID,
            //                       linkaction = m.LINKACTION,
            //                       menuname = m.MENUNAME
            //                   }).ToList();
            //        return PartialView(obj);
            //    }
            //    else
            //    {
            //        List<GROUPMENU> gm = data.GROUPMENUs.ToList();
            //        List<MENU> mn = data.MENUs.ToList();
            //        var obj = (from g in gm
            //                   join m in mn on g.ID equals m.ID_GROUP
            //                   where g.ID != 5
            //                   select new Menu_List
            //                   {
            //                       id_group = g.ID,
            //                       id_groupmenu = m.ID_GROUP,
            //                       groupname = g.GROUPNAME,
            //                       idmenu = m.ID,
            //                       linkaction = m.LINKACTION,
            //                       menuname = m.MENUNAME
            //                   }).ToList();
            //        return PartialView(obj);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    var error = ex.Message.ToString();
            //    return Content(error);
            //}

            List<GROUPMENU> gm = data.GROUPMENUs.ToList();
            List<MENU> mn = data.MENUs.ToList();
            var obj = (from g in gm
                       join m in mn on g.ID equals m.ID_GROUP
                       select new Menu_List
                       {
                           id_group = g.ID,
                           id_groupmenu = m.ID_GROUP,
                           groupname = g.GROUPNAME,
                           idmenu = m.ID,
                           linkaction = m.LINKACTION,
                           menuname = m.MENUNAME
                       }).ToList();
            return PartialView(obj);
        }
        public ActionResult HienThiDanhMuc(int id)
        {
            
            return PartialView();
        }

        //Đăng xuất
        public ActionResult DangXuat()
        {
            Session["NhanVien"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}
