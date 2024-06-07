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
    public partial class FormBilgiDuzenle : Form
    {
        public FormBilgiDuzenle()
        {
            InitializeComponent();
        }

        public string tcNo;
        sqlconn bgl = new sqlconn();

        private void FormBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTCKimlikNo.Text = tcNo;
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Hastalar WHERE HastaTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCKimlikNo.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskNumber.Text = dr[4].ToString();
                txtPassword.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }

            bgl.baglanti().Close();

        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Hastalar SET HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 WHERE HastaTC=@p6",bgl.baglanti());

            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskNumber.Text);
            komut2.Parameters.AddWithValue("@p4", txtPassword.Text);
            komut2.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6", mskTCKimlikNo.Text);
            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);

        }
    }
}
