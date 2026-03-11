using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjandaVeTelefonRehberi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Tablo boşsa, sütun başlıklarını biz oluşturalım
            if (dataGridView1.ColumnCount == 0)
            {
                dataGridView1.Columns.Add("ad", "Ad");
                dataGridView1.Columns.Add("soyad", "Soyad");
                dataGridView1.Columns.Add("tel", "Telefon");
                dataGridView1.Columns.Add("eposta", "E-Posta");
                dataGridView1.Columns.Add("grup", "Grup");
                dataGridView1.Columns.Add("not", "Notlar");
            }

            // 2. Kutulardaki (TextBox, ComboBox, RichTextBox) verileri tabloya yeni satır olarak ekleyelim
            dataGridView1.Rows.Add(
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                comboBox1.Text,
                richTextBox1.Text
            );

            // 3. Kullanıcıya işlem tamam mesajı verelim
            MessageBox.Show(textBox1.Text + " " + textBox2.Text + " rehbere başarıyla eklendi!");

            // 4. Yeni kayıt için kutuları temizleyelim (Opsiyonel)
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && !dataGridView1.CurrentRow.IsNewRow)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                MessageBox.Show("Kayıt başarıyla silindi!");
            }
            else
            {
                MessageBox.Show("Lütfen dolu bir satır seçin. En alttaki boş satır silinemez!");
            }




        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Önce metin kutusundaki (RichTextBox) yazıyı alalım
            string not = richTextBox2.Text;

            if (not != "")
            {
                // Notu listeye ekleyelim
                listBox1.Items.Add(not);

                // İşlem bitince kutuyu temizleyelim ki yeni not yazılabilsin
                richTextBox2.Clear();

                MessageBox.Show("Not başarıyla kaydedildi!");
            }
            else
            {
                MessageBox.Show("Lütfen önce bir not yazın!");
            }

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            // Önce listeden bir şey seçilmiş mi kontrol edelim
            if (listBox1.SelectedIndex != -1)
            {
                // Seçili olan notu listeden kaldır
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                MessageBox.Show("Seçili not başarıyla silindi!");
            }
            else
            {
                // Eğer hiçbir şeye tıklamadan silmeye basarsa uyarı ver
                MessageBox.Show("Lütfen önce silmek istediğiniz notun üzerine tıklayın!");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string tarih = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string icerik = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                listBox1.Items.Clear();
                listBox1.Items.Add("--- SEÇİLİ NOT ---");
                listBox1.Items.Add("TARİH: " + tarih);
                listBox1.Items.Add("");
                listBox1.Items.Add("NOTUNUZ:");
                listBox1.Items.Add(icerik);
                listBox1.Items.Add("-----------------");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                label7.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToLongTimeString();
        }
    }
    }

