using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesCRUD.model
{
    class Pasien_m
    {
        int id;
        string nama, tgllahir, jk, alamat, notelpon, gol, riwayat;

        public Pasien_m() { }

        public Pasien_m(int id, string nama, string tgllahir, string jk, string alamat, string notelpon, string gol, string riwayat)
        {
            this.Id = id;                   
            this.Nama = nama;               
            this.TanggalLahir = tgllahir;  
            this.JenisKelamin = jk;         
            this.Alamat = alamat;          
            this.NoTelepon = notelpon;     
            this.GolonganDarah = gol;      
            this.RiwayatPenyakit = riwayat; 
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nama
        {
            get { return nama; }
            set { nama = value; }
        }

        public string TanggalLahir
        {
            get { return tgllahir; }
            set { tgllahir = value; }
        }

        public string JenisKelamin
        {
            get { return jk; }
            set { jk = value; }
        }

        public string Alamat
        {
            get { return alamat; }
            set { alamat = value; }
        }

        public string NoTelepon
        {
            get { return notelpon; }
            set { notelpon = value; }
        }

        public string GolonganDarah
        {
            get { return gol; }
            set { gol = value; }
        }

        public string RiwayatPenyakit
        {
            get { return riwayat; }
            set { riwayat = value; }
        }
    }
}
