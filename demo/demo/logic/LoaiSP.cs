using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.logic
{
    public class LoaiSP
    {
        public LoaiSP(string maLoai, string tenLoai, string motaLoaiSP) 
        { 
            MaLoai = maLoai;
            TenLoai = tenLoai;
            MotaLoaiSP = motaLoaiSP;
        }
        public string MaLoai { get; set; }
        public string TenLoai { get; set;}
        public string MotaLoaiSP { get; set;}
    }
}
