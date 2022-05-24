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
    public partial class editRacuna : Form
    {
        public editRacuna()
        {
            InitializeComponent();
        }

        private void editRacuna_Load(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            button4.Visible = true;
            id.Visible = true;
            panel2.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            button4.Visible = false;
            id.Visible = false;
            panel2.Visible = false;
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                cnn.Open();
                string Query = "SELECT * FROM ade.korisnici WHERE CVV='" + this.id.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                if (MyReader2.Read())
                {
                    txtIme.Text = (MyReader2["Ime"].ToString());
                    txtPrezime.Text = (MyReader2["Prezime"].ToString());
                    txtJMBG.Text = (MyReader2["JMBG"].ToString());
                    txtZip.Text = (MyReader2["ZIP"].ToString());
                    txtPassword.Text = (MyReader2["password"].ToString());
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                string Query = "update ade.korisnici set password='" + txtPassword.Text + "',Ime='" + txtIme.Text + "',Prezime='" + txtPrezime.Text + "',JMBG='" + txtJMBG.Text + "',ZIP='" + txtZip.Text + "' where username='" + this.id.Text + "';";
                string pamćenje = this.txtIme.Text;
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Uspješno ste editovali svoj lični nalog\n           Korisnik :【" + pamćenje+ "】", "【EDITOVANJE RACUNA】",MessageBoxButtons.OK,MessageBoxIcon.Information);
                while (MyReader2.Read())
                {
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

