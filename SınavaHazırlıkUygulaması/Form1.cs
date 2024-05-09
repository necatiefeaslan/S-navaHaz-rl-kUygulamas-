using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SınavaHazırlıkUygulaması
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=tsomtal.com;Initial Catalog=uyeler148;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sqlCum = "INSERT INTO Uyeler148 (KAdi,AdiSoyadi,EPosta,Sifre) VALUES('" + textBoxKAdi.Text + "','" + textBoxAdiSoyadi.Text + "','" + textBoxEposta.Text + "','" + textBoxSifre.Text + "');";
                SqlCommand cmd = new SqlCommand(sqlCum, baglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler başarı ile kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası\n" + ex.Message);
            }
            finally
            {
                if (baglanti != null) baglanti.Close();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'uyeler148DataSet.Uyeler148' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyeler148TableAdapter.Fill(this.uyeler148DataSet.Uyeler148);

        }
    }
}
