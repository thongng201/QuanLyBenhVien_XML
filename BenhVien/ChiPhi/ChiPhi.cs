using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public abstract class ChiPhi
    {
        //mã chi phí, ngày phát sinh, loại chi phí, số tiền,...
        string maChiPhi, loaiChiPhi;
        double soTien;
        DateTime ngayPhatSinh;

        public string MaChiPhi { get => maChiPhi; set => maChiPhi = value; }
        public string LoaiChiPhi { get => loaiChiPhi; set => loaiChiPhi = value; }
        public double SoTien { get => soTien; set => soTien = value; }
        public DateTime NgayPhatSinh { get => ngayPhatSinh; set => ngayPhatSinh = value; }

        public ChiPhi()
        {
            maChiPhi = string.Empty;
            loaiChiPhi = "1";
            soTien = 0;
            ngayPhatSinh = DateTime.Now;
        }

        public ChiPhi(string maChiPhi, string loaiChiPhi, double soTien, DateTime ngayPhatSinh)
        {
            this.maChiPhi = maChiPhi;
            this.loaiChiPhi = loaiChiPhi;
            this.soTien = soTien;
            this.ngayPhatSinh = ngayPhatSinh;
        }
        public abstract void nhap();
        public abstract void xuat();
    }
}
