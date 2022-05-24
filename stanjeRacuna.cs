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
    public partial class stanjeRacuna : Form
    {
        public stanjeRacuna()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                //kveri za povlacenje podataka
                string Query = "SELECT Ime,Prezime,stanjeRacuna FROM ade.korisnici WHERE CVV='"+textBox2.Text+"';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable stanjeRacuna = new DataTable();
                MyAdapter.Fill(stanjeRacuna);
                dataGridView1.DataSource = stanjeRacuna;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Nije moguće!", "BAZA NIJE UCITANA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
