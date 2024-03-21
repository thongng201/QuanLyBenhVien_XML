using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khoa
{
    public class Khoa
    {
        // tên khoa, mã khoa, địa chỉ khoa
        string tenKhoa, maKhoa, diaChiKhoa;

        public string TenKhoa { get => tenKhoa; set => tenKhoa = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string DiaChiKhoa { get => diaChiKhoa; set => diaChiKhoa = value; }

        public Khoa()
        {
            tenKhoa = maKhoa = diaChiKhoa = string.Empty;
        }
        public Khoa(string tenKhoa, string maKhoa, string diaChiKhoa)
        {
            this.tenKhoa = tenKhoa;
            this.maKhoa = maKhoa;
            this.diaChiKhoa = diaChiKhoa;
        }

        public void nhapKhoa()
        {
            Console.WriteLine("Nhap ma khoa: ");
            MaKhoa = Console.ReadLine();
            Console.WriteLine("Nhap ten khoa: ");
            TenKhoa = Console.ReadLine();
            Console.WriteLine("Nhap dia chi khoa: ");
            DiaChiKhoa = Console.ReadLine();
           
        }

        public void xuatKhoa()
        {
            Console.WriteLine("Ma khoa : {0} Ten khoa : {1} \t Dia chi: {2}",maKhoa, tenKhoa, diaChiKhoa);
        }
    }
}
