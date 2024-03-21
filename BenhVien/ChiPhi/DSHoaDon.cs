using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BenhVien
{
    public class DSHoaDon
    {
        public List<HoaDon> dsHoaDon = new List<HoaDon>();

        public void ghiXML(string file)
        {
            XmlWriter w = XmlWriter.Create(file);
            w.WriteStartElement("DS");

            foreach (HoaDon hd in dsHoaDon)
            {
                w.WriteStartElement("HoaDon");
                w.WriteElementString("maBenhNhan", hd.MaBenhNhan);
                w.WriteElementString("maHD", hd.MaHoaDon);
                w.WriteElementString("tongCP", hd.TongChiPhi().ToString());
                w.WriteElementString("ngayHD", hd.NgayHoaDon.ToString());
                w.WriteEndElement();
            }
            w.WriteEndElement();
            w.Close();
        }

        public void nhapXML(string file)
        {       
            XmlDocument read = new XmlDocument();
            read.Load(file);
            
            foreach (XmlNode node in read.SelectNodes("/DS/HoaDon"))
            {
                HoaDon hd = new HoaDon();
                hd.MaBenhNhan = node["maBenhNhan"].InnerText;
                hd.MaHoaDon = node["maHD"].InnerText;
                hd.NgayHoaDon = DateTime.Parse(node["ngayHD"].InnerText);
                dsHoaDon.Add(hd);
            }

        }

        public void xuat()
        {
            foreach (HoaDon hd in dsHoaDon)
                hd.xuat();
        }

        public void XoaHoaDon(string maHoaDon)
        {
            for (int i = 0; i < dsHoaDon.Count; i++)
                if (dsHoaDon[i].MaHoaDon == maHoaDon)
                    dsHoaDon.Remove(dsHoaDon[i]);
        }

        public void ThemChiPhiVaoHoaDon(ChiPhi chiPhi, string maHoaDon)
        {
            foreach (HoaDon hd in dsHoaDon)
                if (hd.MaHoaDon == maHoaDon)
                    hd.DsChiPhi.Add(chiPhi);
        }

        public void nhapXMLChiPhi(string file)
        {
            DSPeople a = new DSPeople();
            a.nhapXML("C:\\Users\\ThongDNg\\Desktop\\BenhVien\\BenhVien\\BenhVien\\People\\People.xml");

            XmlDocument read = new XmlDocument();
            read.Load(file);
            XmlNodeList nodeList = read.SelectNodes("/DS/ChiPhi");
            foreach (XmlNode node in nodeList)
            {
                string MaHoaDon = node["maHD"].InnerText;
                int loai = int.Parse(node["loai"].InnerText);

                    if (loai == 1) //Kham benh
                    {
                        string maKhamBenh = node["maKham"].InnerText;
                        string ketQuaKhamBenh = node["KQKham"].InnerText;
                        DateTime ngayKham = DateTime.Parse(node["ngayKham"].InnerText);
                        BacSi bacSi = a.layBacSi(node["BacSi"].InnerText);
                        YTa yta = a.layYTa(node["YTa"].InnerText);

                        ChiPhi kb = new KhamBenh(maKhamBenh, ketQuaKhamBenh, ngayKham, bacSi, yta);
                        kb.MaChiPhi = node["maCP"].InnerText;
                        kb.LoaiChiPhi = node["loaiCP"].InnerText;
                        kb.SoTien = double.Parse(node["soTien"].InnerText);
                        kb.NgayPhatSinh = DateTime.Parse(node["ngayPS"].InnerText);
                        ThemChiPhiVaoHoaDon(kb, MaHoaDon);

                }
                    else if (loai == 2) // Dieu Tri
                    {
                        string maDieuTri = node["maDT"].InnerText;
                        string ketQuaDieuTri = node["KQDT"].InnerText;
                        DateTime ngayBD = DateTime.Parse(node["NgayBD"].InnerText);
                        DateTime ngayKT = DateTime.Parse(node["NgayKT"].InnerText);
                        BacSi bacSi = a.layBacSi(node["BacSi"].InnerText);
                        YTa yta = a.layYTa(node["YTa"].InnerText);

                        ChiPhi dt = new DieuTri(maDieuTri, ketQuaDieuTri, ngayBD, ngayKT, bacSi, yta);
                        dt.MaChiPhi = node["maCP"].InnerText;
                        dt.LoaiChiPhi = node["loaiCP"].InnerText;
                        dt.SoTien = double.Parse(node["soTien"].InnerText);
                        dt.NgayPhatSinh = DateTime.Parse(node["ngayPS"].InnerText);
                        ThemChiPhiVaoHoaDon(dt, MaHoaDon);

                    }                    
                }
                
            }

        public bool kiemTraMaHoaDonTonTai(string maHoaDon)
        {
            foreach(HoaDon t in dsHoaDon)
            { if (t.MaHoaDon == maHoaDon)
                    return true;
            }
            return false;
        }
        public void ghiXMLChiPhi(string file)
        {
            XmlWriter w = XmlWriter.Create(file);
            w.WriteStartElement("DS");

            foreach (HoaDon hd in dsHoaDon)
            {               
                foreach (ChiPhi cp in hd.DsChiPhi)
                {
                    w.WriteStartElement("ChiPhi");
                    w.WriteElementString("maHD", hd.MaHoaDon);
                    if (cp is KhamBenh)
                    {
                        KhamBenh kb = (KhamBenh)cp;
                        w.WriteElementString("loai", "1");
                        w.WriteElementString("loaiCP", kb.LoaiChiPhi);
                        w.WriteElementString("maCP", kb.MaChiPhi);
                        w.WriteElementString("soTien", kb.SoTien.ToString());
                        w.WriteElementString("ngayPS", kb.NgayPhatSinh.ToString());

                        w.WriteElementString("maKham", kb.MaKhamBenh);
                        w.WriteElementString("KQKham", kb.KetQuaKhamBenh);
                        w.WriteElementString("ngayKham", kb.NgayKham.ToString());                    
                        w.WriteElementString("BacSi", kb.BacSi.Ma);
                        w.WriteElementString("YTa", kb.Yta.Ma);


                    }
                    else if (cp is DieuTri)
                    {
                        DieuTri dt = (DieuTri)cp;
                        w.WriteElementString("loai", "2");
                        w.WriteElementString("loaiCP", dt.LoaiChiPhi);
                        w.WriteElementString("maCP", dt.MaChiPhi);
                        w.WriteElementString("soTien", dt.SoTien.ToString());
                        w.WriteElementString("ngayPS", dt.NgayPhatSinh.ToString());

                        w.WriteElementString("maDT", dt.MaDieuTri);
                        w.WriteElementString("KQDT", dt.KetQuaDieuTri);
                        w.WriteElementString("NgayBD", dt.NgayBatDauDieuTri.ToString());
                        w.WriteElementString("NgayKT", dt.NgayKetThucDieuTri.ToString());
                        w.WriteElementString("BacSi", dt.BacSi.Ma);
                        w.WriteElementString("YTa", dt.Yta.Ma);
                    }
                    w.WriteEndElement();
                }
               
            }
            w.WriteEndElement();
            w.Close();
        }

        public List<HoaDon> xuatHoaDonTheoMaBenhNhan(string maBenhNhan)
        {
            List<HoaDon> listBenhNhan = new List<HoaDon>();
            foreach(HoaDon hd in dsHoaDon)
            {
                if (hd.MaBenhNhan == maBenhNhan)
                    listBenhNhan.Add(hd);
                    
            }
            return listBenhNhan;
        }
    }

    
}

