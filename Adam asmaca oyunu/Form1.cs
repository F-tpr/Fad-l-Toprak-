using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Adam_asmaca_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        string buluncakKelime = "";
        int resimSayisi = 0;
        string appPath = Path.GetDirectoryName(Application.ExecutablePath);

        #region Kelimeler

        public string[] kelimeler = new string[10];
        public void kelimeleriAta()
        {
            kelimeler[0] = "GOSB";
            kelimeler[1] = "TADIM";
            kelimeler[2] = "JALE";
            kelimeler[3] = "YÜCEL";
            kelimeler[4] = "MESLEK";
            kelimeler[5] = "LİSE";
            kelimeler[6] = "BİLİŞİM";
            kelimeler[7] = "BERAT";
            kelimeler[8] = "FADIL";
            kelimeler[9] = "ARKADAŞLIK";   
        }
        #endregion
                

        private void Form1_Load(object sender, EventArgs e)
        {
            kelimeleriAta(); // Kayıtlı kelimeler yükleniyor.

            MessageBox.Show("Hoş geldin,İyi oyunlar dileriz! By_Akpunar and By_Toprak");
        }

        

        private void btnYKelime_Click(object sender, EventArgs e)
        {
            lblKelime.Text = "";            
            buluncakKelime = kelimeler[r.Next(10)];
            for (int i = 0; i < buluncakKelime.Length; i++)
            {
                lblKelime.Text += "?";                
            }
            resimSayisi = 0;
            pbAdam.Image = null;
            lbDenemeler.Items.Clear();
        }

        private void btnHarfdene_Click(object sender, EventArgs e)
        {
            char aranacakChar = char.Parse(txtTahminHarf.Text);
            char[] karakterler = buluncakKelime.ToCharArray();
            bool varmi = false;

            for (int i = 0; i <= lbDenemeler.Items.Count - 1; i++)
            {
                if (lbDenemeler.Items[i].ToString() == aranacakChar.ToString())
                {
                    MessageBox.Show("Bu harf daha önce girilmiştir. Başka Harf deneyin.");
                    return;
                }
            }

            lbDenemeler.Items.Add(aranacakChar.ToString());

            for (int i = 0; i < karakterler.Length; i++)
            {
                if (karakterler[i] == aranacakChar)
                {
                    lblKelime.Text = lblKelime.Text.Remove(i, 1);
                    lblKelime.Text = lblKelime.Text.Insert(i, aranacakChar.ToString());
                    varmi = true;
                }                
            }

            if (lblKelime.Text == buluncakKelime)
            {
                MessageBox.Show("Kelime'yi bildiniz. TEBRİKLER.");
                lblKelime.Text = buluncakKelime;
                return;
            }
            txtTahminHarf.Text = "";
          
            if (varmi == false)
            {
                 resimSayisi++;
                 pbAdam.ImageLocation = appPath + "\\Resimler\\" + resimSayisi +".png";
                 if (resimSayisi == 7)
                 {
                     MessageBox.Show("Bütün Haklarınız doldu oyunu kaybettiniz.");
                     lblKelime.Text = buluncakKelime;
                     return;
                 }
            }

            
        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            string tahmin = txtTahmin.Text;
            if (tahmin == buluncakKelime)
            {
                MessageBox.Show("Kelime'yi bildiniz. TEBRİKLER.");
                lblKelime.Text = buluncakKelime;
            }
            else
            {
                MessageBox.Show("YANLIŞ TAHMİN");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lbDenemeler.Items[0].ToString());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Güle Güle! By_Akpunar and By_Toprak");
        }
    }
}
