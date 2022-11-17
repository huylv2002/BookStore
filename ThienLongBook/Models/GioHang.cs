using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThienLongBook.Models
{
    public class GioHang
    {
        ThienLongBookEntities data = new ThienLongBookEntities();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhToan
        {
            get { return iSoLuong * dDonGia; }
        }

        public GioHang(int ms)
        {
            iMaSach = ms;
            Sach s = data.Saches.Single(n => n.maSach == iMaSach);
            sTenSach = s.tenSach;
            sAnhBia = s.hinhMinhHoa;
            dDonGia = double.Parse(s.donGia.ToString());
            iSoLuong = 1;
        }
    }
}