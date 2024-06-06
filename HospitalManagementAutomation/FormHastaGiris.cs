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
    public partial class FormHastaGiris : Form
    {
        public FormHastaGiris()
        {
            InitializeComponent();
        }

        private void FormHastaGiris_Load(object sender, EventArgs e)
        {

        }

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormHastaKayit fr = new FormHastaKayit();
            fr.Show();
        }

        sqlconn bgl = new sqlconn();

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Hastalar WHERE HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                FormHastaDetay fr = new FormHastaDetay();
                fr.tc = mskTCKimlikNo.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC Kimlik No ve Şifre Girdiniz");
            }

            bgl.baglanti().Close();
            //
        }
    }
}
