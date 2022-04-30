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
    public partial class krediti : Form
    {
        public krediti()
        {
            InitializeComponent();
        }

        private void krediti_Load(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.textBox2.Enabled = false;
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                //kveri za povlacenje podataka
                string Query = "SELECT * FROM ade.kredit WHERE validanKredit LIKE 'Ne';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand2;
                DataTable krediti = new DataTable();
                MyAdapter.Fill(krediti);
                dataGridView1.DataSource = krediti;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Nije moguće!", "BAZA NIJE UCITANA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                string pamćenje = "";
                string cifra = "";
                string Query = "update ade.kredit set validanKredit='" + "Da" + "' where username='" + this.textBox1.Text + "';";
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                pamćenje = this.textBox1.Text;
                cifra = this.textBox2.Text;
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Odobrili ste kredit korisniku <<"+pamćenje+">> u iznosu od<<"+cifra+">>, te mu je ta cifra uplaćena na račun");
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                string Query = "DELETE FROM ade.kredit WHERE username='" + textBox1.Text + "';";
                MySqlCommand com = new MySqlCommand();
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                MySqlDataReader MyReader2;
                cnn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Zahtjev za kredit je odbijen i obrisan iz baze!","ODBIJEN",MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
    }
    }
  
