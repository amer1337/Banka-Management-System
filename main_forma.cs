using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_panel
{
    public partial class main_forma : Form
    {
        public main_forma()
        {
            InitializeComponent();
        }

        private void main_forma_Load(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("datasource= localhost; database=ade;port=3306; username = root; password= Amerdelic1.");
            cnn.Open();
            if (cnn.State == ConnectionState.Open){
                lblCon.ForeColor = Color.ForestGreen;
                lblCon.Text = "KONEKTOVANO";
            }
            else
            {
                lblCon.ForeColor = Color.Red;
                lblCon.Text = "NIJE MOGUĆE";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            sviKorisniciTabela f2 = new sviKorisniciTabela();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            brisanjeKorisnika f2 = new brisanjeKorisnika();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            editKorisnika f2 = new editKorisnika();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            krediti f2 = new krediti();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            transferNovcaAdmin f2 = new transferNovcaAdmin();
            f2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            dodavanjeNovca f2 = new dodavanjeNovca();
            f2.ShowDialog();
        }
    }
}
