using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class XuatKho
    {
        public XuatKho(string maPX, string maLoaiSP, int slXuat, string maNVxuat, DateTime ngayXuat) 
        {
            this.MaPX = maPX;
            this.MaNVXuat = maNVxuat;
            this.MaLoaiSP = maLoaiSP;
            this.SoLuongXuat = slXuat;
            this.NgayXuat = ngayXuat;
        }
        public string MaPX {  get; set; } 
        public string MaLoaiSP { get; set; }
        public int SoLuongXuat { get; set; }
        public string MaNVXuat { get; set; }
        public DateTime NgayXuat { get; set; }
    }
}
