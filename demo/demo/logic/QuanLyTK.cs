using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class QuanLyTK
    {
        public QuanLyTK(string maNV, string phanQuyen)
        {
            MaNV = maNV;
            PhanQuyen = phanQuyen;
        }

        public QuanLyTK(string maNV, string tenDN, string mk, string phanQuyen) 
        { 
            MaNV = maNV;
            TenDN = tenDN;
            MK = mk;
            PhanQuyen = phanQuyen;
        }



        public string MaNV {  get; set; }
        public string PhanQuyen { get; set; }
        public string TenDN { get; set;}
        public string MK { get; set;}
    }
}
