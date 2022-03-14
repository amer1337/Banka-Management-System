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
    public partial class sviKorisniciTabela : Form
    {
        public sviKorisniciTabela()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_forma f2 = new main_forma();
            f2.ShowDialog();
        }

        private void sviKorisniciTabela_Load(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                //kveri za povlacenje podataka
                string Query = "select * from ade.korisnici;";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable sviKorisnici = new DataTable();
                MyAdapter.Fill(sviKorisnici);
                dataGridView1.DataSource = sviKorisnici;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nije moguće!", "BAZA NIJE UCITANA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
