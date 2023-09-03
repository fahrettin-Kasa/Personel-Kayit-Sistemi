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

namespace ffffffffffff
{
    public partial class frmyonetici : Form
    {
        public frmyonetici()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-CQKIIC2\\SQLEXPRESS01; Initial Catalog =  personelveritabani; Integrated Security = True");

        private void frmyonetici_Load(object sender, EventArgs e)
        {

        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where kullaniciad=@k1 and sifre=@k2", baglanti);
            komut.Parameters.AddWithValue("@k1", txtad.Text);
            komut.Parameters.AddWithValue("@k2", txtsifre.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            if (dr1.Read())
            {
                Form1 frm= new Form1();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı kullanıcı adı ya da sifre");
            }
            baglanti.Close();
        }
    }
}
