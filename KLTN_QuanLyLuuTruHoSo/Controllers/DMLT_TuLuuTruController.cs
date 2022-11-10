using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KLTN_QuanLyLuuTruHoSo.Models;
namespace KLTN_QuanLyLuuTruHoSo.Controllers
{
    public class DMLT_TuLuuTruController : Controller
    {
        //
        // GET: /DMLT_TuLuuTru/
        QLLuuTruHoSoDataContext data = new QLLuuTruHoSoDataContext();
        public ActionResult Index()
        {
            List<TU> t = data.TUs.ToList();
            return View(t);
        }
        public ActionResult ThemTu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XuLyThemTu(TU tu, FormCollection col)
        {
            tu.NGAYTAO = DateTime.Now;
            tu.NGAYCAPNHAT = DateTime.Now;

            data.TUs.InsertOnSubmit(tu);
            data.SubmitChanges();
            return RedirectToAction("Index", "DMLT_TuLuuTru");
        }
        public ActionResult XoaTu(int id)
        {
            try
            {
                TU del = data.TUs.SingleOrDefault(t => t.ID == id);
                if (del != null)
                {
                    data.TUs.DeleteOnSubmit(del);
                    data.SubmitChanges();
                }
            }
            catch { }
            return RedirectToAction("Index", "DMLT_TuLuuTru");
        }
        // sửa Khách hàng
        public ActionResult SuaTu(int id)
        {
            TU tu = data.TUs.SingleOrDefault(t => t.ID == id);
            return View(tu);
        }
        [HttpPost]
        public ActionResult XuLySuaTu(FormCollection col)
        {
            int id = int.Parse(col["ID"]);
            var tentu = col["TENTU"];
            int songan = int.Parse(col["SONGAN"]);
            int sokedat = int.Parse(col["SLKE_DAT"]);
            DateTime ngaycapnhat = DateTime.Now; 
            var trangthai = col["TRANGTHAI"];

            if (tentu != null)
            {
                TU t = data.TUs.SingleOrDefault(c => c.ID == id);
                t.TENTU = tentu;
                t.SONGAN = songan;
                t.SLKE_DAT = sokedat;
                //số kệ hiện tại               (chưa tính)
                //không cập nhật ngày tạo
                t.NGAYCAPNHAT = ngaycapnhat;
                t.TRANGTHAI = trangthai;

                data.SubmitChanges();
            }
            List<TU> st = data.TUs.Where(t => t.ID != null).ToList();
            return RedirectToAction("Index", "DMLT_TuLuuTru", st);
        }
    }
}
