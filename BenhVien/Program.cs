using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            int chon = 0;
            while (chon == 0)
            {
                Menu2();
                Console.WriteLine("\nTiep tuc hay nhan phim 0 \n");
                chon = int.Parse(Console.ReadLine());
            }

            Console.ReadLine();
        }

        public static void Menu1()
        {
            DSPeople nguoi = new DSPeople();
            nguoi.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");

            DSHoaDon hoadon = new DSHoaDon();
            hoadon.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\HoaDon.xml");
            hoadon.nhapXMLChiPhi("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\ChiPhi.xml");

            int Menu;
            Console.WriteLine("Moi ban chon chuc nang: \n1. Them xoa sua bac si, y ta, benh nhan\n2. Them hoa don\n3. Them, xoa, sua chi phi");
            Menu = int.Parse(Console.ReadLine());
            if (Menu == 1)
            {
                int chon;
                Console.WriteLine("Moi ban chon chuc nang: \n1. Them bac si\t2.Them y ta\t3. Them benh nhan\t4. Xem danh sach\t5. Xoa people\t6. Sua people");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            People bs = new BacSi();
                            bs.nhap();
                            while (nguoi.kiemTraBacSiTonTai(bs.Ma) == true)
                            {
                                Console.WriteLine("\nMA BAC SI TON TAI\n");
                                bs.nhap();
                            }
                            nguoi.listPeople.Add(bs);
                        }
                        break;
                    case 2:
                        {
                            People yt = new YTa();
                            yt.nhap();
                            while (nguoi.kiemTraYTaTonTai(yt.Ma) == true)
                            {
                                Console.WriteLine("\nMA Y TA TON TAI\n");
                                yt.nhap();
                            }
                            nguoi.listPeople.Add(yt);
                        }
                        break;
                    case 3:
                        {

                            People bn = new BenhNhan();
                            bn.nhap();
                            while (nguoi.kiemTraBenhNhanTonTai(bn.Ma) == true)
                            {
                                Console.WriteLine("\nMA BENH NHAN TON TAI\n");
                                bn.nhap();
                            }
                            nguoi.listPeople.Add(bn);
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Danh sach bac si, y  ta, benh nhan\n------------------------------------------------------------------------------------------------------------------");
                            nguoi.xuat();
                            Console.WriteLine("Tong luong nhan vien benh vien : " + nguoi.tinhTongLuongNhanVienBenhVien());
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Danh sach bac si, y  ta, benh nhan\n------------------------------------------------------------------------------------------------------------------");
                            nguoi.xuat();
                            Console.WriteLine("Ban muon xoa nguoi thu : ");
                            int thu = int.Parse(Console.ReadLine());
                            if(nguoi.listPeople[thu - 1] is BenhNhan)
                            {
                                List<HoaDon> dsHoaDonBenhNhan = hoadon.xuatHoaDonTheoMaBenhNhan(nguoi.listPeople[thu - 1].Ma);
                                if (dsHoaDonBenhNhan.Count != 0)
                                {
                                    Console.WriteLine("KHONG THE XOA VI CO HOA DON BENH NHAN");
                                    break;
                                }
                            }
                            nguoi.listPeople.Remove(nguoi.listPeople[thu - 1]);
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Danh sach bac si, y  ta, benh nhan\n------------------------------------------------------------------------------------------------------------------");
                            nguoi.xuat();
                            Console.WriteLine("Ban muon sua nguoi thu : ");
                            int thu = int.Parse(Console.ReadLine());
                            nguoi.listPeople[thu - 1].nhap();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Ban nhap khac roi");
                        }
                        break;
                }


            }
            else if (Menu == 2)
            {
                int chon;
                Console.WriteLine("Moi ban chon chuc nang: \n1. Them hoa don\t2. Xem danh sach hoa don\t3. Xoa hoa don\t4. Sua hoa don");
                chon = int.Parse(Console.ReadLine());
                switch (chon)
                {
                    case 1:
                        {
                            HoaDon hd = new HoaDon();
                            Console.Write("Nhap ma benh nhan: ");
                            hd.MaBenhNhan = Console.ReadLine();
                            while (nguoi.kiemTraBenhNhanTonTai(hd.MaBenhNhan) == false)
                            {
                                Console.WriteLine("\nMA BENH NHAN KHONG TON TAI\n");
                                Console.Write("Nhap ma benh nhan: ");
                                hd.MaBenhNhan = Console.ReadLine();
                            }

                            Console.Write("Nhap ma hoa don: ");
                            hd.MaHoaDon = Console.ReadLine();
                            while (hoadon.kiemTraMaHoaDonTonTai(hd.MaHoaDon) == true)
                            {
                                Console.WriteLine("\nMA HOA DON TON TAI\n");
                                Console.Write("Nhap ma hoa don: ");
                                hd.MaHoaDon = Console.ReadLine();
                            }
                            hd.nhap();
                            hoadon.dsHoaDon.Add(hd);
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Danh sach hoa don\n------------------------------------------------------------------------------------------------------------------");
                            hoadon.xuat();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Danh sach hoa don\n------------------------------------------------------------------------------------------------------------------");
                            hoadon.xuat();
                            Console.WriteLine("Nhap ma hoa don muon xoa : ");
                            string maHoaDon = Console.ReadLine();
                            hoadon.XoaHoaDon(maHoaDon);
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Danh sach hoa don\n------------------------------------------------------------------------------------------------------------------");
                            hoadon.xuat();
                            Console.WriteLine("Ban muon sua ma hoa don : ");
                            string thu = Console.ReadLine();
                            HoaDon newHoaDon = new HoaDon();
                            newHoaDon.nhap();

                            foreach (HoaDon t in hoadon.dsHoaDon)
                                if (t.MaHoaDon == thu)
                                    t.DsChiPhi = newHoaDon.DsChiPhi;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Ban nhap khac roi");
                        }
                        break;
                }

            }
            else if (Menu == 3)
            {

                int chon;
                Console.WriteLine("Moi ban chon chuc nang: \n1. Them chi  phi\t2. Xoa chi phi\t3. Sua chi phi");
                chon = int.Parse(Console.ReadLine());
                Console.WriteLine("Danh sach hoa don\n------------------------------------------------------------------------------------------------------------------");
                hoadon.xuat();
                Console.WriteLine("Ban chon ma hoa don : ");
                string thu = Console.ReadLine();

                switch (chon)
                {
                    case 1:
                        {
                            foreach (HoaDon t in hoadon.dsHoaDon)
                                if (t.MaHoaDon == thu)
                                {
                                    Console.Write("Chon chi phi : 1. Kham benh \t 2. Dieu tri");
                                    chon = int.Parse(Console.ReadLine());
                                    if (chon == 1)
                                    {
                                        ChiPhi kb = new KhamBenh();
                                        Console.Write("Nhap ma kham benh: ");
                                        kb.MaChiPhi = Console.ReadLine();
                                        while (t.kiemTraChiPhiTonTai(kb.MaChiPhi) == true)
                                        {
                                            Console.WriteLine("\nMA KHAM BENH TON TAI\n");
                                            Console.Write("Nhap ma kham benh: ");
                                            kb.MaChiPhi = Console.ReadLine();
                                        }
                                        kb.nhap();
                                        t.DsChiPhi.Add(kb);
                                    }
                                    else if (chon == 2)
                                    {
                                        ChiPhi dt = new DieuTri();
                                        Console.Write("Nhap ma dieu tri: ");
                                        dt.MaChiPhi = Console.ReadLine();
                                        while (t.kiemTraChiPhiTonTai(dt.MaChiPhi) == true)
                                        {
                                            Console.WriteLine("\nMA DIEU TRI TON TAI\n");
                                            Console.Write("Nhap ma dieu tri: ");
                                            dt.MaChiPhi = Console.ReadLine();
                                        }
                                        dt.nhap();
                                        t.DsChiPhi.Add(dt);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ban nhap so khac. Nen khong co chi phi");
                                    }

                                }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Nhap ma chi phi muon xoa : ");
                            string maChiPhi = Console.ReadLine();
                            foreach (HoaDon t in hoadon.dsHoaDon)
                                if (t.MaHoaDon == thu)
                                    foreach (ChiPhi cp in t.DsChiPhi)
                                        if (cp.MaChiPhi == maChiPhi)
                                        {
                                            t.DsChiPhi.Remove(cp); break;
                                        }
                        }
                        break;
                    case 3:
                        {

                            Console.WriteLine("Nhap ma chi phi muon sua : ");
                            string maChiPhi = Console.ReadLine();
                            foreach (HoaDon t in hoadon.dsHoaDon)
                                if (t.MaHoaDon == thu)
                                    foreach (ChiPhi cp in t.DsChiPhi)
                                        if (cp.MaChiPhi == maChiPhi)
                                            cp.nhap();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Ban nhap khac roi");
                        }
                        break;
                }
            }
            else Console.WriteLine("Ban nhap khong chinh xac. Ket thuc chuong trinh");
            nguoi.ghiXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");
            hoadon.ghiXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\HoaDon.xml");
            hoadon.ghiXMLChiPhi("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\ChiPhi.xml");
        }

        public static void Menu2()
        {
            
            DSPeople nguoi = new DSPeople();
            nguoi.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");

            DSHoaDon hoadon = new DSHoaDon();
            hoadon.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\HoaDon.xml");
            hoadon.nhapXMLChiPhi("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\ChiPhi\\ChiPhi.xml");

            int Menu;
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("*********************  QUAN LY BENH VIEN  *****************************");
            Console.WriteLine("@@@@ Nhom 6: NGUYEN DAT THONG - TRAN DANG KHOA - DOAN TRUONG THANH @@@@");
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("");
            Console.WriteLine("Moi ban chon chuc nang: ");
            Console.WriteLine("1. Tinh tong luong nhan vien: ");
            Console.WriteLine("2. Tim kiem ");
            Console.WriteLine("3. Danh sach hoa don cua benh nhan");
            Console.WriteLine("4. Tong doanh thu benh vien");
            Console.WriteLine("5. Them xoa sua ");
            Menu = int.Parse(Console.ReadLine());
            switch (Menu)
            {
                case 1:
                    {
                        Console.WriteLine("Tong luong nhan vien benh vien : " + nguoi.tinhTongLuongNhanVienBenhVien());
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("1. Bac si\t2.Y ta\t 3. Benh nhan");
                        int chon = int.Parse(Console.ReadLine());

                        if (chon == 1)
                        {
                            Console.WriteLine("Nhap ma bac si");
                            string maBS = Console.ReadLine();
                            if (nguoi.kiemTraBacSiTonTai(maBS) == true)
                            {
                                BacSi bacSi = nguoi.layBacSi(maBS);
                                bacSi.xuat();
                            }
                            else Console.WriteLine("Khong co bac si");
                        }
                        else if (chon == 2)
                        {
                            Console.WriteLine("Nhap ma y ta");
                            string maYT = Console.ReadLine();
                            if (nguoi.kiemTraYTaTonTai(maYT) == true)
                            {
                                YTa yTa = nguoi.layYTa(maYT);
                                yTa.xuat();
                            }
                            else Console.WriteLine("Khong co y ta");
                        }
                        else if (chon == 3)
                        {
                            Console.WriteLine("Nhap ma benh nhan");
                            string maBN = Console.ReadLine();
                            if (nguoi.kiemTraBenhNhanTonTai(maBN) == true)
                            {
                                foreach (People t in nguoi.listPeople)
                                {
                                    if (t is BenhNhan && t.Ma == maBN)
                                        t.xuat();
                                }
                            }
                            else Console.WriteLine("Khong co benh nhan");
                        }
                        else Console.WriteLine("Dang thoat ");
                    }
                    break;
                case 3:
                    {
                        Console.Write("Nhap ma benh nhan: ");
                        string maBenhNhan = Console.ReadLine();
                        if (nguoi.kiemTraBenhNhanTonTai(maBenhNhan) == false)
                        {
                            Console.WriteLine("\nMA BENH NHAN KHONG TON TAI\n");
                        }
                        else
                        {
                            List<HoaDon> dsHoaDonBenhNhan = hoadon.xuatHoaDonTheoMaBenhNhan(maBenhNhan);
                            foreach (HoaDon hd in dsHoaDonBenhNhan)
                                hd.xuat();
                        }
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Tong doanh thu benh vien : " +hoadon.dsHoaDon.Sum(t => t.TongChiPhi()));
                    }
                    break;
                case 5:
                    {
                        Menu1();
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Ban nhap khac roi");
                    }
                    break;
            }
        }
    }
}
