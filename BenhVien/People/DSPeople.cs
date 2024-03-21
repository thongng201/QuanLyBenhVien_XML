using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BenhVien
{
    public class DSPeople
    {
        public List<People> listPeople = new List<People>();
        public DSPeople(List<People> list)
        {
            listPeople = list;
        }

        public DSPeople()
        {
            
        }
        public void nhapXML(string file)
        {
            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodelist = read.SelectNodes("/DS/People");
            foreach (XmlNode node in nodelist)
            {
                int loai = int.Parse(node["loai"].InnerText);
                People people;
                if (loai == 1) // Bác sĩ
                {
                    string chuyenKhoa = node["CK"].InnerText;
                    people = new BacSi(chuyenKhoa);
                    people.HoTen = node["Ten"].InnerText;
                    people.GioiTinh = node["GT"].InnerText;
                    people.Tuoi = int.Parse(node["tuoi"].InnerText);
                    people.Ma = node["Ma"].InnerText;
                  
                    listPeople.Add(people);
                }
                else if (loai == 2) // Y tá
                {
                    string chuyenKhoa = node["CK"].InnerText;
                    people = new YTa(chuyenKhoa);
                    people.HoTen = node["Ten"].InnerText;
                    people.GioiTinh = node["GT"].InnerText;
                    people.Tuoi = int.Parse(node["tuoi"].InnerText);
                    people.Ma = node["Ma"].InnerText;
                    listPeople.Add(people);
                }
                else  // Bệnh nhân
                {
                    string diaChi = node["Address"].InnerText;
                    string benhLy = node["BenhLy"].InnerText;
                    people = new BenhNhan(diaChi,benhLy);
                    people.HoTen = node["Ten"].InnerText;
                    people.GioiTinh = node["GT"].InnerText;
                    people.Tuoi = int.Parse(node["tuoi"].InnerText);
                    people.Ma = node["Ma"].InnerText;
                    listPeople.Add(people);
                }
            }
            
        }

        public void xuat()
        {
            
            for( int i=0;i<listPeople.Count;i++)
            {
                Console.Write(i+1 + ". ");
                listPeople[i].xuat();
            }
               
        }

        public void ghiXML(string file)
        {
            XmlWriter w = XmlWriter.Create(file);
            w.WriteStartElement("DS");
            
            foreach (People p in listPeople)
            {
                w.WriteStartElement("People");
                if (p is BacSi)
                {
                    BacSi bs = (BacSi)p;
                    w.WriteElementString("loai", "1");
                    w.WriteElementString("Ma", bs.Ma);
                    w.WriteElementString("Ten", bs.HoTen);
                    w.WriteElementString("GT", bs.GioiTinh);
                    w.WriteElementString("tuoi", bs.Tuoi.ToString());
                    w.WriteElementString("CK", bs.ChuyenKhoa);

                }
                else if(p is YTa)
                {
                    YTa bs = (YTa)p;
                    w.WriteElementString("loai", "2");
                    w.WriteElementString("Ma", bs.Ma);
                    w.WriteElementString("Ten", bs.HoTen);
                    w.WriteElementString("GT", bs.GioiTinh);
                    w.WriteElementString("tuoi", bs.Tuoi.ToString());
                    w.WriteElementString("CK", bs.ChuyenKhoa);
                }
                else
                {
                    BenhNhan bs = (BenhNhan)p;
                    w.WriteElementString("loai", "3");
                    w.WriteElementString("Ma", bs.Ma);
                    w.WriteElementString("Ten", bs.HoTen);
                    w.WriteElementString("GT", bs.GioiTinh);
                    w.WriteElementString("tuoi", bs.Tuoi.ToString());
                    w.WriteElementString("Address", bs.DiaChi);
                    w.WriteElementString("BenhLy", bs.BenhLy);
                }
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.Close();
        }

        //public void XML(string file)
        //{
        //    // Tạo một đối tượng XmlWriter
        //    XmlWriter w = XmlWriter.Create(file);

        //    // Ghi dữ liệu vào file
        //    w.WriteStartDocument();
        //    w.WriteStartElement("DS");
        //    w.WriteStartElement("People");
        //    w.WriteElementString("loai", "1");
        //    w.WriteElementString("CK", "Mat");
        //    w.WriteElementString("Ten", "Khoa");
        //    w.WriteElementString("tuoi", "32");
        //    w.WriteElementString("GT", "Nam");
        //    w.WriteEndElement();
        //    w.WriteEndElement();
        //    w.Close();
        //}

        public bool kiemTraBacSiTonTai(string mabacSi)
        {
            foreach(People p in listPeople)
            {
                if (p is BacSi && p.Ma == mabacSi)
                    return true;
            }
            return false;
        }
        public bool kiemTraYTaTonTai(string maYTa)
        {
            foreach (People p in listPeople)
            {
                if (p is YTa && p.Ma == maYTa)
                    return true;
            }
            return false;
        }
        public bool kiemTraBenhNhanTonTai(string  maBenhNhan)
        {
            foreach (People p in listPeople)
            {
                if (p is BenhNhan && p.Ma == maBenhNhan)
                    return true;
            }
            return false;
        }
        public BacSi layBacSi(string maBacSi)
        {
            foreach(People p in listPeople)
            {
                if (p is BacSi && maBacSi == p.Ma)
                    return (BacSi)p;
            }
            return null;
        }

        public YTa layYTa(string maYTa)
        {
            foreach (People p in listPeople)
            {
                if (p is YTa && maYTa == p.Ma)
                    return (YTa)p;
            }
            return null;
        }

        public double tinhTongLuongNhanVienBenhVien()
        {
            double tong = 0;
           foreach(People p in listPeople)
            {
                if(p is BacSi)
                {
                    BacSi b = (BacSi)p;
                    tong += b.tinhLuong();
                }
                if (p is YTa)
                {
                    YTa b = (YTa)p;
                    tong += b.tinhLuong();
                }
            }
            return tong;
        }

        public List<People> layDanhSachBacSi()
        {
            List<People> bs = new List<People>();
            foreach (People p in listPeople)
                if (p is BacSi)
                    bs.Add(p);
            return bs;
        }
        public List<People> layDanhSachYta()
        {
            List<People> bs = new List<People>();
            foreach (People p in listPeople)
                if (p is YTa)
                    bs.Add(p);
            return bs;
        }
    }
}
