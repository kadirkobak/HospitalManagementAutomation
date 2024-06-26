﻿using System;
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
    public partial class FormHastaKayit : Form
    {
        public FormHastaKayit()
        {
            InitializeComponent();
        }

        sqlconn bgl = new sqlconn();
        
        private void btnKayitYap_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTCKimlikNo.Text);
            komut.Parameters.AddWithValue("@p4", mskNumber.Text);
            komut.Parameters.AddWithValue("@p5", txtPassword.Text);
            komut.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            
            MessageBox.Show("Kaydınız Tamamlanmıştır Şifreniz: "+txtPassword.Text,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
