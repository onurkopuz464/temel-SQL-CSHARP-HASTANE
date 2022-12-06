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

namespace Proje_Hastane
{
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void Giris_Button_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tc.Text);
            komut.Parameters.AddWithValue("@p2", sifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                SekreterDetay fr = new SekreterDetay();
                fr.tc = tc.Text;
                fr.Show();
                this.Hide();
            }
            else { MessageBox.Show("Hatalı Tc ve ya Şifre"); }
        }
    }
}
