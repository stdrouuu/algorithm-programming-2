using TesCRUD.model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesCRUD.controller
{
    class Pasien
    {
        Koneksi koneksi = new Koneksi();

        public bool Insert(Pasien_m pasien)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenCon();
                koneksi.ExecuteQuery("INSERT INTO tbldatarumahsakit (id_pasien, nama_pasien, tanggal_lahir, alamat, no_telepon, gol_darah, riwayat_penyakit) VALUES (" +
                    pasien.Id + ", '" + pasien.Nama + "','" + pasien.TanggalLahir + "','" +
                    pasien.JenisKelamin + "','" + pasien.Alamat + "','" + pasien.NoTelepon + "','"+
                    pasien.GolonganDarah + "','"+
                   pasien.RiwayatPenyakit + "');");
                status = true;
                MessageBox.Show("Data Berhasil Ditambahkan",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Update(Pasien_m pasien, int id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenCon();
                koneksi.ExecuteQuery("UPDATE tbldatarumahsakit SET nama_pasien = '" + pasien.Nama + "', " +
                "tanggal_lahir = '" + pasien.TanggalLahir + "', " +
                 "jenis_kelamin = '" + pasien.JenisKelamin + "', " +
                    "alamat = '" + pasien.Alamat + "', " +
                 "no_telepon = '" + pasien.NoTelepon + "', " +
                 "gol_darah = '" + pasien.GolonganDarah + "', " +
                "riwayat_penyakit = '" + pasien.RiwayatPenyakit + "' " +
                "WHERE id_pasien = " + pasien.Id + ";");
                status = true;
                MessageBox.Show("Data Berhasil Diubah",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Delete(int id)
        {
            Boolean status = false;
            try
            {
                koneksi.OpenCon();
                koneksi.ExecuteQuery("DELETE FROM tbldatarumahsakit WHERE id_pasien = " + id + ";");
                status = true;
                MessageBox.Show("Data Berhasil Dihapus",
                    "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                koneksi.CloseCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
