using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class NhapKho
    {
        public NhapKho(string maPN, string maLoai, string maNVNhap, string nhaCC, int slNhap, DateTime ngayNhap) 
        { 
            this.MaPN = maPN;
            this.MaLoai = maLoai;
            this.MaNVNhap = maNVNhap;
            this.NhaCC = nhaCC;
            this.SoLuongNhap = slNhap;
            this.NgayNhap = ngayNhap;
        }
        public string MaPN { get; set; }
        public string MaLoai { get; set; }
        public string MaNVNhap { get; set; }
        public string NhaCC { get; set; }
        public int SoLuongNhap { get; set; }
        public DateTime NgayNhap { get; set; }
       

    }
}
