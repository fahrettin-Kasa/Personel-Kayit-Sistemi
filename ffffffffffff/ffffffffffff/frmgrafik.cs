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
    public partial class frmgrafik : Form
    {
        public frmgrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-CQKIIC2\\SQLEXPRESS01; Initial Catalog =  personelveritabani; Integrated Security = True");
        private void frmgrafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();    
            SqlCommand komutg = new SqlCommand("select persehir,count(*) from tbl_personel group by persehir", baglanti);
            SqlDataReader drg = komutg.ExecuteReader();
            while (drg.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(drg[0], drg[1]);
            }
            baglanti.Close();
            MessageBox.Show("grafik olusturuldu");
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaas) from tbl_personel group by permeslek", baglanti);
            SqlDataReader drg2 = komutg2.ExecuteReader();
            while (drg2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drg2[0], drg2[1]);
            }
            baglanti.Close();   
        }
    }
}
