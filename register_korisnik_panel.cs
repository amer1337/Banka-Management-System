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
    public partial class register_korisnik_panel : Form
    {
        public register_korisnik_panel()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtIme.Clear();
            this.txtPrezime.Clear();
            this.txtJMBG.Clear();
            this.txtZip.Clear();
            this.txtUsername.Clear();
            this.txtPassword.Clear();
            this.txtCvv.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //konekcija string 
                string MyConnection2 = "datasource= localhost; database=ade;port=3306; username = root; password= Amerdelic1.";
                //kveri za insert podataka u bazu sqla 
                string Query = "INSERT INTO ade.korisnici(username,password,Ime,Prezime,JMBG,ZIP,CVV,datumRodjenja) VALUES('" + this.txtUsername.Text + "','" + this.txtPassword.Text + "','" + this.txtIme.Text + "','" + this.txtPrezime.Text + "','" + this.txtJMBG.Text + "','" + this.txtZip.Text + "','" + this.txtCvv.Text + "','" + this.dateTimePicker1.Text + "');";
                //ojb. mysql konekcije  
               
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                //mysql komanda za kveri i konekciju 
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                //kveri izvrsavanje i ubacivanje u bazu SQLa
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Korisnik uspjesno registrovan", "REGISTRACIJA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Form1 f2 = new Form1();
                f2.ShowDialog();
                while (MyReader2.Read())
                {
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("Username ili CVV su već uneseni u bazu, promijenite ih!", "[ERROR]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
