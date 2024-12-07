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


namespace video76sql
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Bilgisayar\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True"); //sql adresimiz


        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //grafik 1:
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select PerSehir, count(*) from Tbl_Personel group by PerSehir", baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]); //sehir x ekseni, sayısı y ekseni
            }
            baglanti.Close();

            //grafik 2:
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek, avg(permaas) from tbl_personel group by permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]); //meslek x ekseni, maaşı y ekseni
            }
            baglanti.Close();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
