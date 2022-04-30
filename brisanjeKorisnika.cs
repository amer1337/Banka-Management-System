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
    public partial class brisanjeKorisnika : Form
    {
        public brisanjeKorisnika()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sviKorisniciTabela f2 = new sviKorisniciTabela();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                string Query = "DELETE FROM ade.korisnici WHERE id='" + id.Text + "';";
                //------------------KOMANDE---------------------

                MySqlCommand com = new MySqlCommand();
                MySqlConnection cnn = new MySqlConnection(MyConnection2);

                //----------------------------------------------

                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Korisnik uspjesno obrisan");
                while (MyReader2.Read())
                {
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije moguce obrisati podatke", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void id_TextChanged(object sender, EventArgs e)
        {
        
            string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
            MySqlConnection cnn = new MySqlConnection(MyConnection2);
            cnn.Open();
            string Query = "SELECT * FROM ade.korisnici WHERE id=" + int.Parse(id.Text);
            MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
            MySqlDataReader MyReader2;
            MyReader2 = MyCommand2.ExecuteReader();
            if (MyReader2.Read()) {
                delUsername.Text = (MyReader2["username"].ToString());
                delPassword.Text = (MyReader2["password"].ToString());
            }
            cnn.Close();
        }

        private void brisanjeKorisnika_Load(object sender, EventArgs e)
        {
            MessageBox.Show("UNESITE TAČAN ID KORISNIKA, AKO NISTE SIGURNI POGLEDAJTE U TABELI!!",
               "BRISANJE KORISNIKA[ADMINISTRATOR]", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
