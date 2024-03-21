using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenhVien
{
    public class BenhNhan : People 
    {
        //, địa chỉ, bệnh lý,
        string diaChi, benhLy;       
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string BenhLy { get => benhLy; set => benhLy = value; }

        public BenhNhan() : base()
        {

        }
        //public BenhNhan(string hoTen, int tuoi, string gioiTinh, string diaChi, string benhLy) : base(hoTen, tuoi, gioiTinh)
        //{
        //    this.diaChi = diaChi;
        //    this.benhLy = benhLy;
        //}

        public BenhNhan(string diaChi, string benhLy) : base()
        {
            this.diaChi = diaChi;
            this.benhLy = benhLy;
        }

        public override void nhap()
        {
            Console.Write("Nhap ma benh nhan: ");
            Ma = Console.ReadLine();
            Console.Write("Nhap ho ten benh nhan: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhap tuoi: ");
            Tuoi = int.Parse(Console.ReadLine());
            Console.Write("Nhap gioi tinh: ");
            GioiTinh = Console.ReadLine();
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine();
            Console.Write("Nhap benh ly: ");
            BenhLy = Console.ReadLine();
        }

        public override void xuat()
        {
            Console.WriteLine("Benh nhan - Ma: {5}\tTen: {0}\t Tuoi: {1}\t Gioi tinh: {2}\tDia chi: {3}\tBenh ly: {4}", HoTen, Tuoi, GioiTinh, diaChi, benhLy,Ma);
        }
    }
}
