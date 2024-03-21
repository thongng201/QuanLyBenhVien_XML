using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
     public class BenhVien
    {
        //tên bệnh viện, địa chỉ, số điện thoại, loại hình bệnh viện
        string tenBenhVien, diaChi, sdt, loaiBenhVien;

        public string TenBenhVien { get => tenBenhVien; set => tenBenhVien = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string LoaiBenhVien { get => loaiBenhVien; set => loaiBenhVien = value; }

        public BenhVien()
        {
            tenBenhVien=diaChi=sdt=loaiBenhVien = string.Empty;

        }

        public BenhVien(string tenBenhVien,string diaChi, string sdt, string loaiBenhVien)
        {
            this.tenBenhVien = tenBenhVien;
            this.diaChi = diaChi;
            this.sdt = sdt;
            this.loaiBenhVien = loaiBenhVien;
        }
        public void nhapBenhVien()
        {
            Console.WriteLine("Nhap ten benh vien: ");
            TenBenhVien = Console.ReadLine();
            Console.WriteLine("Nhap dia chi benh vien: ");
            DiaChi = Console.ReadLine();
            Console.WriteLine("Nhap so dien thoai benh vien: ");
            Sdt = Console.ReadLine();
            Console.WriteLine("Nhap loai benh vien: ");
            LoaiBenhVien = Console.ReadLine();

        }

        public void xuatBenhVien()
        {
            Console.WriteLine("Ten benh vien : {0} \t Dia chi: {1}\t SDT : {2}\t Loai benh vien :{3}", tenBenhVien, diaChi, sdt, loaiBenhVien);
        }
    }
}
