using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KLTN_QuanLyLuuTruHoSo.Models
{
    public class Menu_List
    {
        public int id_group { get; set; }
        public int? id_groupmenu { get; set; }
        public string groupname { get; set; }
        public int idmenu { get; set; }
        public string menuname { get; set; }
        public string linkaction { get; set; }
    }
}