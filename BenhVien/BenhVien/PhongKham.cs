using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class PhongKham
    {
        //tên phòng khám, mã phòng khám, địa chỉ phòng khám
        string tenPhongKham, maPhongKham, diaChiPhongKham;

        public string TenPhongKham { get => tenPhongKham; set => tenPhongKham = value; }
        public string MaPhongKham { get => maPhongKham; set => maPhongKham = value; }
        public string DiaChiPhongKham { get => diaChiPhongKham; set => diaChiPhongKham = value; }

        public PhongKham()
        {
            maPhongKham = tenPhongKham = diaChiPhongKham = string.Empty;
        }
        public PhongKham(string tenPhongKham, string maPhongKham, string diaChiPhongKham)
        {
            this.tenPhongKham = tenPhongKham;
            this.maPhongKham = maPhongKham;
            this.diaChiPhongKham = diaChiPhongKham;
        }

        public void nhapPhongKham()
        {
            Console.WriteLine("Nhap ma phong kham: ");
            MaPhongKham = Console.ReadLine();
            Console.WriteLine("Nhap ten phong kham: ");
            TenPhongKham = Console.ReadLine();
            Console.WriteLine("Nhap dia chi phong kham: ");
            DiaChiPhongKham = Console.ReadLine();

        }

        public void xuatPhongKham()
        {
            Console.WriteLine("Ma phong kham : {0} Ten phong kham : {1} \t Dia chi: {2}", maPhongKham, tenPhongKham, diaChiPhongKham);
        }
    }
}
