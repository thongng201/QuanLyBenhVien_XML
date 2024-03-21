using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public abstract class People
    {
        //họ tên, tuổi, giới tính

        string hoTen, gioiTinh,ma;
        int tuoi;

        public string HoTen { get => HoTen1; set => HoTen1 = value; }
        public string GioiTinh { get => GioiTinh1; set => GioiTinh1 = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }
        public string HoTen1 { get => hoTen; set => hoTen = value; }
        public string GioiTinh1 { get => gioiTinh; set => gioiTinh = value; }
        public string Ma { get => ma; set => ma = value; }

        public People()
        {

            HoTen1 = Ma = string.Empty;
            GioiTinh1 = "Nam";
            tuoi = 0;
        }

        public People(string ma, string hoTen, int tuoi, string gioiTinh)
        {
            this.ma = ma;
            this.HoTen1 = hoTen;
            this.tuoi = tuoi;
            this.GioiTinh1 = gioiTinh;
        }
        public abstract void nhap();

        public abstract void xuat();
    }
}
