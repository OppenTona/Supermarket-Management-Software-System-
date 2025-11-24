using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class NhanVien
    {
        public NhanVien(string maNV, string tenNV, string chucVu, string gioiTinh, string sdt, DateTime ngaySinh, string diaChi, string email) 
        {
            MaNV = maNV;
            TenNV = tenNV;
            ChucVu = chucVu;
            GioiTinh = gioiTinh;
            Sdt = sdt;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            Email = email;
        }
        public string MaNV {  get; set; }
        public string TenNV { get; set; }
        public string ChucVu { get; set; }
        public string GioiTinh { get; set; }
        public string Sdt {  get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
    }
}
