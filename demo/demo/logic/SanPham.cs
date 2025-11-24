using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class SanPham
    {
        public SanPham(string maSP, string tenSP, string maLoai, int soLuong, DateTime ngaySX, DateTime hanSD, string nhaCC, int gia, string motaSP) 
        {
            MaLoai = maLoai;
            MaSP = maSP;
            TenSP = tenSP;
            SoLuong = soLuong;
            NgaySX = ngaySX;
            HanSD = hanSD;
            NhaCC = nhaCC;
            Gia = gia;
            MotaSP = motaSP;    
        }
        public string MaSP { get; set; }
        public string TenSP { get; set;}
        public string MaLoai { get; set; }
        public int SoLuong { get;set; }
        public DateTime NgaySX { get; set;}
        public DateTime HanSD { get; set; }
        public string NhaCC { get; set;}
        public int Gia { get; set;}
        public string MotaSP { get; set;}
       
    }
}
