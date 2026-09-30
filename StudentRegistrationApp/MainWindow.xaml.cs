using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace StudentRegistrationApp
{
    public partial class MainWindow : Window
    {
        private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

        private Mahasiswa? mahasiswaTerpilih = null;

        public MainWindow()
        {
            InitializeComponent();

            TampilkanData();
        }


        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            if (txtNIM.Text == "" ||
                txtNama.Text == "" ||
                cmbJurusan.SelectedItem == null ||
                txtAlamat.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!");

                return;
            }

            string jenisKelamin = "";

            if (rbLakiLaki.IsChecked == true)
            {
                jenisKelamin = "Laki-laki";
            }
            else if (rbPerempuan.IsChecked == true)
            {
                jenisKelamin = "Perempuan";
            }
            else
            {
                MessageBox.Show("Pilih jenis kelamin!");

                return;
            }

            ComboBoxItem item =
                (ComboBoxItem)cmbJurusan.SelectedItem;

            string jurusan = item.Content.ToString() ?? "";


            Mahasiswa mahasiswaBaru = new Mahasiswa
            {
                NIM = txtNIM.Text,
                Nama = txtNama.Text,
                Jurusan = jurusan,
                JenisKelamin = jenisKelamin,
                Alamat = txtAlamat.Text
            };


            daftarMahasiswa.Add(mahasiswaBaru);

            TampilkanData();

            ClearForm();

            MessageBox.Show("Data mahasiswa berhasil ditambahkan!");
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (mahasiswaTerpilih == null)
            {
                MessageBox.Show("Pilih mahasiswa yang ingin diedit!");

                return;
            }


            if (txtNIM.Text == "" ||
                txtNama.Text == "" ||
                cmbJurusan.SelectedItem == null ||
                txtAlamat.Text == "")
            {
                MessageBox.Show("Semua data harus diisi!");

                return;
            }


            string jenisKelamin = "";

            if (rbLakiLaki.IsChecked == true)
            {
                jenisKelamin = "Laki-laki";
            }
            else if (rbPerempuan.IsChecked == true)
            {
                jenisKelamin = "Perempuan";
            }
            else
            {
                MessageBox.Show("Pilih jenis kelamin!");

                return;
            }


            ComboBoxItem item =
                (ComboBoxItem)cmbJurusan.SelectedItem;

            string jurusan = item.Content.ToString() ?? "";


            mahasiswaTerpilih.NIM = txtNIM.Text;
            mahasiswaTerpilih.Nama = txtNama.Text;
            mahasiswaTerpilih.Jurusan = jurusan;
            mahasiswaTerpilih.JenisKelamin = jenisKelamin;
            mahasiswaTerpilih.Alamat = txtAlamat.Text;


            TampilkanData();

            ClearForm();

            MessageBox.Show("Data mahasiswa berhasil diubah!");
        }


        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            if (mahasiswaTerpilih == null)
            {
                MessageBox.Show("Pilih mahasiswa yang ingin dihapus!");

                return;
            }


            MessageBoxResult result = MessageBox.Show(
                "Apakah kamu yakin ingin menghapus data ini?",
                "Konfirmasi",
                MessageBoxButton.YesNo);


            if (result == MessageBoxResult.Yes)
            {
                daftarMahasiswa.Remove(mahasiswaTerpilih);

                TampilkanData();

                ClearForm();

                MessageBox.Show("Data mahasiswa berhasil dihapus!");
            }
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }


        private void lstMahasiswa_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (lstMahasiswa.SelectedItem is Mahasiswa mahasiswa)
            {
                mahasiswaTerpilih = mahasiswa;

                txtNIM.Text = mahasiswa.NIM;

                txtNama.Text = mahasiswa.Nama;

                txtAlamat.Text = mahasiswa.Alamat;


                if (mahasiswa.JenisKelamin == "Laki-laki")
                {
                    rbLakiLaki.IsChecked = true;
                    rbPerempuan.IsChecked = false;
                }
                else
                {
                    rbLakiLaki.IsChecked = false;
                    rbPerempuan.IsChecked = true;
                }


                for (int i = 0; i < cmbJurusan.Items.Count; i++)
                {
                    ComboBoxItem item =
                        (ComboBoxItem)cmbJurusan.Items[i];

                    if (item.Content.ToString() == mahasiswa.Jurusan)
                    {
                        cmbJurusan.SelectedIndex = i;

                        break;
                    }
                }
            }
        }


        private void cmbJurusan_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (cmbJurusan.SelectedItem is ComboBoxItem item)
            {
                string jurusan = item.Content.ToString() ?? "";
            }
        }


        private void TampilkanData()
        {
            lstMahasiswa.Items.Clear();

            foreach (Mahasiswa mahasiswa in daftarMahasiswa)
            {
                lstMahasiswa.Items.Add(mahasiswa);
            }

            txtJumlah.Text =
                "Jumlah mahasiswa: " + daftarMahasiswa.Count;
        }


        private void ClearForm()
        {
            txtNIM.Clear();

            txtNama.Clear();

            txtAlamat.Clear();

            cmbJurusan.SelectedIndex = -1;

            rbLakiLaki.IsChecked = false;

            rbPerempuan.IsChecked = false;

            lstMahasiswa.SelectedItem = null;

            mahasiswaTerpilih = null;
        }
    }
}