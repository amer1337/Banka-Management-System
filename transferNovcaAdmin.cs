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
    public partial class transferNovcaAdmin : Form
    {
        public transferNovcaAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                cnn.Open();
                string s1 = "UPDATE ade.korisnici SET stanjeRacuna = stanjeRacuna - '" + textBox2.Text + "' WHERE username = '" + txtIme.Text + "'";
                string s2 = "UPDATE ade.korisnici SET stanjeRacuna = stanjeRacuna + '" + textBox2.Text + "' WHERE username = '" + textBox4.Text + "'";
                MySqlTransaction t = cnn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand(s1, cnn, t);
                int a = cmd.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand(s2, cnn, t);
                int b = cmd2.ExecuteNonQuery();

                if (a == 0 || b == 0)
                {
                    t.Rollback();
                    MessageBox.Show("Nije moguće!");
                }
                else
                {
                    t.Commit();
                    MessageBox.Show("Uspješno ste izvršili prebacivanje " + textBox2.Text + " na račun " + textBox4.Text + ".");
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_forma f2 = new main_forma();
            f2.ShowDialog();
        }
    }
    }

