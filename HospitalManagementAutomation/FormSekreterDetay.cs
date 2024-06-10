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

namespace HospitalManagementAutomation
{
    public partial class FormSekreterDetay : Form
    {
        public FormSekreterDetay()
        {
            InitializeComponent();
        }

        public string tcNo;
        sqlconn bgl = new sqlconn();

        private void FormSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tcNo;

            // ad soyad çekme işlemleri
            SqlCommand komut1 = new SqlCommand("SELECT SekreterAdSoyad FROM Tbl_Sekreter WHERE SekreterTC=@p1",bgl.baglanti());
            komut1.Parameters.AddWithValue("@p1", lblTC.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();

            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            //branşları datagrid'e aktarma işlemi
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Tbl_Branslar",bgl.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //doktorları listeye aktarma işlemi
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT (DoktorAd+' '+DoktorSoyad) as 'Doktorlar',DoktorBrans FROM Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //combobox'a branş aktarma işlemi
            SqlCommand komut2 = new SqlCommand("SELECT BransAd FROM Tbl_Branslar",bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutKaydet = new SqlCommand("INSERT INTO Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",bgl.baglanti());
            komutKaydet.Parameters.AddWithValue("@r1", mskTarih.Text);
            komutKaydet.Parameters.AddWithValue("@r2", mskSaat.Text);
            komutKaydet.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komutKaydet.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komutKaydet.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            cmbDoktor.Text="";

            SqlCommand komut = new SqlCommand("SELECT DoktorAd,DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorBrans=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0]+" "+dr[1]);
            }
            bgl.baglanti().Close();
        
        }
    }
}
