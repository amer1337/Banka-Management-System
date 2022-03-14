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
    public partial class editKorisnika : Form
    {
        public editKorisnika()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sviKorisniciTabela f2 = new sviKorisniciTabela();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            id.Clear();
            txtIme.Clear();
            txtPrezime.Clear();
            txtUsername.Clear();
            txtCvv.Clear(); 
            txtZip.Clear();
            txtJMBG.Clear();
            txtPassword.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                string pamćenje="";
                string Query = "update ade.korisnici set username='" + txtUsername.Text + "',password='" + txtPassword.Text + "',Ime='" + txtIme.Text + "',Prezime='" + txtPrezime.Text + "',JMBG='" + txtJMBG.Text + "',ZIP='" + txtZip.Text + "',CVV='" + txtCvv.Text + "' where id='" + this.id.Text + "';";
                pamćenje = this.txtIme.Text;
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Uspješno ste editovali INFO o korisniku po imenu << "+pamćenje+" >>");
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("Molimo vas da uneste ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else {
                txtIme.Enabled = true;
                txtPrezime.Enabled = true;
                txtCvv.Enabled = true;
                txtJMBG.Enabled = true;
                txtUsername.Enabled = true;
                txtZip.Enabled = true;
                txtPassword.Enabled = true;
                this.button1.Enabled = true;
                this.button2.Enabled = true;
            }
            /*
             moze i u textbox od ID-a na event textchange, međutim dolazi do errora prilikom rada aplikacije
              ukoliko textbox bude empty ili string vrijednost izlazi iz programa jer mysql ne moze prepoznati
               tip podatka u kojem ne postoji ID, nije moguce zaobici taj error.
             */
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
            MySqlConnection cnn = new MySqlConnection(MyConnection2);
            cnn.Open();
            string Query = "SELECT * FROM ade.korisnici WHERE id=" + int.Parse(id.Text);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            if (MyReader2.Read())
            {
                txtIme.Text = (MyReader2["Ime"].ToString());
                txtPrezime.Text = (MyReader2["Prezime"].ToString());
                txtJMBG.Text = (MyReader2["JMBG"].ToString());
                txtZip.Text = (MyReader2["ZIP"].ToString());
                txtCvv.Text = (MyReader2["CVV"].ToString());
                txtUsername.Text = (MyReader2["username"].ToString());
                txtPassword.Text = (MyReader2["password"].ToString());
            }
            cnn.Close();
        }

        private void editKorisnika_Load(object sender, EventArgs e)
        {
            txtIme.Enabled = false;
            txtPrezime.Enabled = false;
            txtCvv.Enabled = false;
            txtJMBG.Enabled = false;
            txtUsername.Enabled = false;
            txtZip.Enabled = false;
            txtPassword.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = false;
        }
    }
}
