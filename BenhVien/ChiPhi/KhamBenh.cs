using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class KhamBenh:ChiPhi
    {
        //mã khám bệnh, ngày khám, bác sĩ khám, y tá khám, kết quả khám,...
        string maKhamBenh, ketQuaKhamBenh;
        DateTime ngayKham;
        BacSi bacSi;
        YTa yta;

        public string MaKhamBenh { get => maKhamBenh; set => maKhamBenh = value; }
        public DateTime NgayKham { get => ngayKham; set => ngayKham = value; }   
        public BacSi BacSi { get => bacSi; set => bacSi = value; }
        public YTa Yta { get => yta; set => yta = value; }
        public string KetQuaKhamBenh { get => ketQuaKhamBenh; set => ketQuaKhamBenh = value; }

        public KhamBenh()
        {

        }

        public KhamBenh(string maKhamBenh, string ketQuaKhamBenh, DateTime ngayKham, BacSi bacSi, YTa yTa) : base()
        {
            this.maKhamBenh = maKhamBenh;
            this.ketQuaKhamBenh = ketQuaKhamBenh;
            this.ngayKham = ngayKham;        
            this.bacSi = bacSi;
            this.yta = yTa;
        }
        public override void nhap()
        {

            maKhamBenh = MaChiPhi;
            LoaiChiPhi = "1";
            Console.Write("Nhap so tien kham benh: ");
            SoTien = double.Parse(Console.ReadLine());

            Console.Write("Nhap ngay phat sinh: VD: 12/14/2023 1:53:52 PM : ");
            NgayPhatSinh = DateTime.Parse(Console.ReadLine());
            while (DateTime.Compare(DateTime.Now, NgayPhatSinh) < 0)
            {
                Console.WriteLine("NGAY PHAT SINH PHAI O TRONG QUA KHU");
                Console.Write("Nhap ngay phat sinh: VD: 12/14/2023 1:53:52 PM : ");
                NgayPhatSinh = DateTime.Parse(Console.ReadLine());
            }

            Console.Write("Nhap ket qua kham benh: ");
            KetQuaKhamBenh = Console.ReadLine();

            Console.Write("Nhap ngay bat dau kham benh: VD: 12/14/2023 1:53:52 PM : ");
            ngayKham = DateTime.Parse(Console.ReadLine());

            DSPeople a = new DSPeople();
            a.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");
            DSPeople bs = new DSPeople(a.layDanhSachBacSi());
            Console.WriteLine("\nDanh sach bac si :\n====================================================================");
            bs.xuat();
            Console.Write(" Nhap ma bac si: ");
            string b = Console.ReadLine();
            while (a.kiemTraBacSiTonTai(b) == false)
            {
                Console.WriteLine("\nMA BAC SI KHONG TON TAI\n");
                Console.Write(" Nhap ma bac si: ");
                b = Console.ReadLine();
            }
            bacSi = a.layBacSi(b);

            bs = new DSPeople(a.layDanhSachYta());
            Console.WriteLine("\nDanh sach y  ta :\n====================================================================");
            bs.xuat();
            Console.Write(" Nhap ma y ta: ");
            b = Console.ReadLine();
            while (a.kiemTraYTaTonTai(b) == false)
            {
                Console.WriteLine("\nMA Y TA KHONG TON TAI\n");
                Console.Write(" Nhap ma y ta: ");
                b = Console.ReadLine();
            }
            yta = a.layYTa(b);
        }

        public override void xuat()
        {
            Console.WriteLine("Ma kham benh: " + maKhamBenh);
            Console.WriteLine("So tien kham benh: " + SoTien);
            Console.WriteLine("Ngay phat sinh: " + NgayPhatSinh);
            Console.WriteLine("Ket qua kham benh: " + ketQuaKhamBenh);
            Console.WriteLine("Ngay Kham: " + ngayKham);
            Console.WriteLine("Bac si: " + BacSi.HoTen + "\t Y ta: " + Yta.HoTen);
        }
    }
}
