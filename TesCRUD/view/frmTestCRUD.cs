using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesCRUD.controller;
using TesCRUD.model;

namespace TesCRUD.view
{
    public partial class frmTestCRUD: Form
    {
        Koneksi knk = new Koneksi();
        Pasien_m swa = new Pasien_m();
        int id;

        public void dgvSet()
        {
            dgvPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPasien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPasien.RowHeadersWidth = 51;
            dgvPasien.RowTemplate.Height = 24;
        }

        public void Tampil()
        {
            dgvPasien.ReadOnly = true;
            dgvPasien.DataSource = knk.ShowData("SELECT * FROM tbldatarumahsakit;");
            dgvPasien.Columns[0].HeaderText = "ID";
            dgvPasien.Columns[0].Width = 60;
            dgvPasien.Columns[1].HeaderText = "Nama";
            dgvPasien.Columns[1].Width = 110;
            dgvPasien.Columns[2].HeaderText = "Tanggal Lahir";
            dgvPasien.Columns[2].Width = 110;
            dgvPasien.Columns[3].HeaderText = "Jenis Kelamin";
            dgvPasien.Columns[4].HeaderText = "Alamat";
            dgvPasien.Columns[4].Width = 110;
            dgvPasien.Columns[5].HeaderText = "No Telepon";
            dgvPasien.Columns[5].Width = 110;
            dgvPasien.Columns[6].HeaderText = "Golongan Darah";
            dgvPasien.Columns[7].HeaderText = "Riwayat Penyakit";
            dgvPasien.Columns[7].Width = 130;
        }

        public void Blankform()
        {
            txtID.Clear();
            txtNama.Clear();
            txtTanggalLahir.Clear();
            cbJenkel.SelectedIndex = -1;
            txtAlamat.Clear();
            txtNo.Clear();
            cbGol.SelectedIndex = -1;
            txtRiwayat.Clear();
        }
        public frmTestCRUD()
        {
            InitializeComponent();
        }
      
      
        private void frmTestCRUD_Load_1(object sender, EventArgs e)
        {
            Tampil();
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {

                if (txtID.Text == "" || txtNama.Text == "" || txtTanggalLahir.Text == "" || cbJenkel.SelectedIndex == -1 || txtAlamat.Text == "" ||
                    txtNo.Text == "" || cbGol.SelectedIndex == -1 || txtRiwayat.Text == "")
                {
                    MessageBox.Show("Data tidak boleh kosong!", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Pasien sw = new Pasien();
                    swa.Id = Convert.ToInt32(txtID.Text);
                    swa.Nama = txtNama.Text;
                    swa.TanggalLahir = txtTanggalLahir.Text;
                    swa.JenisKelamin = cbJenkel.Text;
                    swa.Alamat = txtAlamat.Text;
                    swa.NoTelepon = txtNo.Text;
                    swa.GolonganDarah = cbGol.Text;
                    swa.RiwayatPenyakit = txtRiwayat.Text;

                    sw.Insert(swa);
                    Blankform();

                    Tampil();
                }

        }

        private void btnUbah_Click_1(object sender, EventArgs e)
        {

                if (txtID.Text == "" || txtNama.Text == "" || txtTanggalLahir.Text == "" || cbJenkel.SelectedIndex == -1 || txtAlamat.Text == "" ||
                    txtNo.Text == "" || cbGol.SelectedIndex == -1 || txtRiwayat.Text == "")
                {
                    MessageBox.Show("Data tidak boleh kosong!", "Perhatian",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Pasien sw = new Pasien();
                    swa.Id = Convert.ToInt32(txtID.Text);
                    swa.Nama = txtNama.Text;
                    swa.TanggalLahir = txtTanggalLahir.Text;
                    swa.JenisKelamin = cbJenkel.Text;
                    swa.Alamat = txtAlamat.Text;
                    swa.NoTelepon = txtNo.Text;
                    swa.GolonganDarah = cbGol.Text;
                    swa.RiwayatPenyakit = txtRiwayat.Text;

                    sw.Update(swa, id);
                    Blankform();

                    Tampil();
                }
                btnSimpan.Enabled = true;
                txtID.ReadOnly = false;

        }

        private void btnHapus_Click_1(object sender, EventArgs e)
        {

                DialogResult pesan = MessageBox.Show("Yakin mau menghapus data ini ?", "Informasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pesan == DialogResult.Yes)
                {
                    Pasien sw = new Pasien();
                    sw.Delete(id);
                    Tampil();
                }
                else
                    MessageBox.Show("Data Batal dihapus",
                        "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Blankform();
                btnSimpan.Enabled = true;
                txtID.ReadOnly = false;

        }

        private void btnBatal_Click_1(object sender, EventArgs e)
        {
            btnSimpan.Enabled = true;
            Blankform();
            txtID.ReadOnly = false;
        }

        private void txtCariID_TextChanged_1(object sender, EventArgs e)
        {
            dgvPasien.DataSource = knk.ShowData("SELECT * FROM tbldatarumahsakit WHERE id_pasien LIKE '%' '" +
               txtCariID.Text + "' '%' OR nama_pasien LIKE '%' '" + txtCariID.Text + "' '%';");
        }

        private void dgvPasien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtID.Text = dgvPasien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtID.ReadOnly = true;
            id = Convert.ToInt32(txtID.Text);
            txtNama.Text = dgvPasien.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTanggalLahir.Text = dgvPasien.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbJenkel.Text = dgvPasien.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtAlamat.Text = dgvPasien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNo.Text = dgvPasien.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbGol.Text = dgvPasien.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtRiwayat.Text = dgvPasien.Rows[e.RowIndex].Cells[7].Value.ToString();
            btnSimpan.Enabled = false;

        }
    }
}
