using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login_panel
{
    public partial class produzenjeKarticeKorisnik : Form
    {
        public produzenjeKarticeKorisnik()
        {
            InitializeComponent();
        }



        private void produzenjeKarticeKorisnik_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("▶Unesite validno ime ziranta\n▶Unesite realnu cifru za podizanje kredita\n▶Potvrdite vas username\n\n\n▶Za ostale informacije obratite se nasem osoblju", "▶PRAVILA",MessageBoxButtons.OK,MessageBoxIcon.Information);
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            button1.Enabled = true;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource= localhost; database=ade;port=3306; username = root; password= Amerdelic1.";
                string Query = "INSERT INTO ade.kredit(username,cifra) VALUES('" + this.textBox1.Text + "','" + this.textBox2.Text + "');";
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Uspjesno ste poslali zahtjev za podizanje kredita pod imenom " + textBox1.Text + "!", "[KREDIT]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                while (MyReader2.Read())
                {
                }
                this.Hide();
                main_forma_Korisnik f2 = new main_forma_Korisnik();
                f2.ShowDialog();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
