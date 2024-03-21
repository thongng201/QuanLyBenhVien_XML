using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class HoaDon
    {
        //mã hóa đơn, ngày xuất hóa đơn, tổng chi phí,...
        string maHoaDon;
        DateTime ngayHoaDon;
        string maBenhNhan;
        List<ChiPhi> dsChiPhi= new List<ChiPhi>();


        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public double TongChiPhi() 
        {
            return dsChiPhi.Sum(t => t.SoTien);
           
        }
        public DateTime NgayHoaDon { get => ngayHoaDon; set => ngayHoaDon = value; }
        public List<ChiPhi> DsChiPhi { get => dsChiPhi; set => dsChiPhi = value; }
        public string MaBenhNhan { get => maBenhNhan; set => maBenhNhan = value; }

        public HoaDon()
        {

        }

        public HoaDon(string maHoaDon, DateTime ngayHoaDon)
        {
            this.maHoaDon = maHoaDon;       
            this.ngayHoaDon = ngayHoaDon;
        }
        public void Sua(ChiPhi chiPhi)
        {
            foreach (ChiPhi temp in dsChiPhi)
                if (temp.MaChiPhi == chiPhi.MaChiPhi)
                    dsChiPhi.Remove(temp);
            dsChiPhi.Add(chiPhi);
        }
        public void Xoa(ChiPhi chiPhi)
        {
            foreach (ChiPhi temp in dsChiPhi)
                if (temp.MaChiPhi == chiPhi.MaChiPhi)
                    dsChiPhi.Remove(temp);
        }

        public bool kiemTraChiPhiTonTai(string maChiPhi)
        {
            foreach (ChiPhi cp in dsChiPhi)
                if (cp.MaChiPhi == maChiPhi)
                    return true;
            return false;
        }

        public void ThemChiPhi(ChiPhi chiPhi)
        {
            dsChiPhi.Add(chiPhi);
        }


        public void nhap()
        {
            
            NgayHoaDon = DateTime.Now;
            bool thoat = false;
            int chon = 0;
            while (thoat == false)
            {
                Console.Write("Chon chi phi : 1. Kham benh \t 2. Dieu tri");
                chon =int.Parse(Console.ReadLine());
                if (chon == 1)
                {
                    ChiPhi kb = new KhamBenh();
                    Console.Write("Nhap ma kham benh: ");
                    kb.MaChiPhi = Console.ReadLine();
                    while (kiemTraChiPhiTonTai(kb.MaChiPhi) == true)
                    {
                        Console.WriteLine("\nMA KHAM BENH TON TAI\n");
                        Console.Write("Nhap ma kham benh: ");
                        kb.MaChiPhi = Console.ReadLine();
                    }
                    kb.nhap();
                    dsChiPhi.Add(kb);
                }
                 else if (chon == 2)
                {
                    ChiPhi dt = new DieuTri();
                    Console.Write("Nhap ma dieu tri: ");
                    dt.MaChiPhi = Console.ReadLine();
                    while (kiemTraChiPhiTonTai(dt.MaChiPhi) == true)
                    {
                        Console.WriteLine("\nMA DIEU TRI TON TAI\n");
                        Console.Write("Nhap ma dieu tri: ");
                        dt.MaChiPhi = Console.ReadLine();
                    }
                    dt.nhap();
                    dsChiPhi.Add(dt);
                }
                else
                {
                    Console.WriteLine("Ban nhap so khac. Nen khong co chi phi");
                }
                Console.WriteLine("Ban muon tiep tuc nhap chi phi khong? Co hay nhan 0");
                chon = int.Parse(Console.ReadLine()); 
                if (chon != 0)
                {
                    thoat = true;
                }
            }
        }
        public void xuat()
        {
            Console.WriteLine("Ma hoa don :" + maHoaDon);
            Console.WriteLine("Ngay hoa don :" + ngayHoaDon);
            Console.WriteLine("Ma benh nhan :" + maBenhNhan);
            Console.WriteLine("Tong hoa don :" + TongChiPhi());
            foreach (ChiPhi cp in dsChiPhi)
            {

                Console.WriteLine("\n-------------------------------------------------------------------------------------\n");
                cp.xuat();
                
            }
            Console.WriteLine("\n==========================================================================================\n");
        }
    }
}
