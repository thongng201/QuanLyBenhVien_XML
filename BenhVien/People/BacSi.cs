using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class BacSi : People, nhanVienYTe
    {
        //họ tên, tuổi, giới tính, chuyên khoa
        string chuyenKhoa;

        public string ChuyenKhoa { get => chuyenKhoa; set => chuyenKhoa = value; }

        public BacSi():base()
        {
            
        }
        

        public BacSi(string chuyenKhoa) : base()
        {
            this.chuyenKhoa = chuyenKhoa;
        }
        public double tinhLuong()
        {
            return 20000000;
        }

        public override void nhap()
        {
            Console.Write("Nhap ma bac si: ");
            Ma = Console.ReadLine();
            Console.Write("Nhap ho ten bac si: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhap gioi tinh: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhap chuyen khoa: ");
            ChuyenKhoa = Console.ReadLine();
        }

        public override void xuat()
        {
            Console.WriteLine("Bac si - Ma: {4}\tTen: {0}\t Tuoi: {1}\t Gioi tinh: {2}\tChuyen khoa: {3}",HoTen,Tuoi,GioiTinh,chuyenKhoa,Ma);
        }
    }
}
