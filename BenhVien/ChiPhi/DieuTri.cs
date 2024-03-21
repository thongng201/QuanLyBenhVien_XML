using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class DieuTri:ChiPhi
    {
        //mã điều trị, ngày bắt đầu điều trị, ngày kết thúc điều trị, bác sĩ điều trị, y tá điều trị, kết quả điều trị,...
        string maDieuTri, ketQuaDieuTri;
        DateTime ngayBatDauDieuTri, ngayKetThucDieuTri;
        BacSi bacSi;
        YTa yta;

        public string MaDieuTri { get => maDieuTri; set => maDieuTri = value; }
        public DateTime NgayBatDauDieuTri { get => ngayBatDauDieuTri; set => ngayBatDauDieuTri = value; }
        public DateTime NgayKetThucDieuTri { get => ngayKetThucDieuTri; set => ngayKetThucDieuTri = value; }
        public BacSi BacSi { get => bacSi; set => bacSi = value; }
        public YTa Yta { get => yta; set => yta = value; }
        public string KetQuaDieuTri { get => ketQuaDieuTri; set => ketQuaDieuTri = value; }

        public DieuTri()
        {

        }

        public DieuTri(string maDieuTri, string ketQuaDieuTri,DateTime ngayBatDau, DateTime ngayKetThuc, BacSi bacSi, YTa yTa)
        {
            this.maDieuTri = maDieuTri;
            this.ketQuaDieuTri = ketQuaDieuTri;
            this.ngayBatDauDieuTri = ngayBatDau;
            this.ngayKetThucDieuTri = ngayKetThuc;
            this.bacSi = bacSi;
            this.yta = yTa;    
        }

        public override void nhap()
        {

            maDieuTri = MaChiPhi;
            Console.Write("Nhap so tien dieu tri: ");
            SoTien = double.Parse(Console.ReadLine());

            Console.Write("Nhap ngay phat sinh: VD: 12/14/2023 1:53:52 PM : ");
            NgayPhatSinh = DateTime.Parse(Console.ReadLine());
            while (DateTime.Compare(DateTime.Now,NgayPhatSinh)<0)
            {
                Console.WriteLine("NGAY PHAT SINH PHAI O TRONG QUA KHU");
                Console.Write("Nhap ngay phat sinh: VD: 12/14/2023 1:53:52 PM : ");
                NgayPhatSinh = DateTime.Parse(Console.ReadLine());
            }

            Console.Write("Nhap ket qua dieu tri: ");
            KetQuaDieuTri = Console.ReadLine();

            Console.Write("Nhap ngay bat dau dieu tri: VD: 12/14/2023 1:53:52 PM : ");
            ngayBatDauDieuTri = DateTime.Parse(Console.ReadLine());

            Console.Write("Nhap ngay ket thuc dieu tri: VD: 12/14/2023 1:53:52 PM : ");
            ngayKetThucDieuTri = DateTime.Parse(Console.ReadLine());
            while (DateTime.Compare(ngayBatDauDieuTri, ngayKetThucDieuTri) > 0)
            {
                Console.WriteLine("NGAY KET THUC DIEU TRI KHONG DUOC TRUOC NGAY BAT DAU DIEU TRI");
                Console.Write("Nhap ngay Ket thuc dieu tri: VD: 12/14/2023 1:53:52 PM : ");
                ngayKetThucDieuTri = DateTime.Parse(Console.ReadLine());
            }

            DSPeople a = new DSPeople();
            a.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");
            DSPeople bs = new DSPeople(a.layDanhSachBacSi());
            Console.WriteLine("\nDanh sach bac si :\n====================================================================");
            bs.xuat();
            Console.Write(" Nhap ma bac si: ");
            bacSi = a.layBacSi(Console.ReadLine());
            while (a.kiemTraBacSiTonTai(bacSi.Ma) == false)
            {
                Console.WriteLine("\nMA BAC SI KHONG TON TAI\n");
                Console.Write(" Nhap ma bac si: ");
                bacSi = a.layBacSi(Console.ReadLine());
            }
           
            bs = new DSPeople(a.layDanhSachYta());
            Console.WriteLine("\nDanh sach y  ta :\n====================================================================");
            bs.xuat();
            Console.Write(" Nhap ma y ta: ");
            yta = a.layYTa(Console.ReadLine());
            while (a.kiemTraYTaTonTai(yta.Ma) == false)
            {
                Console.WriteLine("\nMA Y TA KHONG TON TAI\n");
                Console.Write(" Nhap ma y ta: ");
                yta = a.layYTa(Console.ReadLine());
            }
        }

        public override void xuat()
        {
            Console.WriteLine("Ma dieu tri: " + maDieuTri);
            Console.WriteLine("So tien dieu tri: " + SoTien);
            Console.WriteLine("Ngay phat sinh: " + NgayPhatSinh);
            Console.WriteLine("Ket qua dieu tri: " + ketQuaDieuTri);
            Console.WriteLine("Ngay Bat Dau: "+ ngayBatDauDieuTri +"\t Ngay Ket Thuc: "+ ngayKetThucDieuTri);
            Console.WriteLine("Bac si: " + BacSi.HoTen + "\t Y ta : " + Yta.HoTen);
        }
    }
}
