using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace login_panel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
       

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn = new MySqlConnection("datasource= localhost; database=ade;port=3306; username = root; password= Amerdelic1.");
            cnn.Open();
            string Query = "SELECT * FROM korisnici WHERE  username = '" + txtUsername.Text + "' AND password = '" + txtPassword.Text + "'";
            MySqlCommand cmd = new MySqlCommand(Query, cnn);
            MySqlDataReader reader = cmd.ExecuteReader();
            string userRole = string.Empty;
            if (reader.Read())
            {
                userRole = reader["role"].ToString();
                if (comboBox1.SelectedIndex == 0 && userRole == "Administrator")
                {
                        this.Hide();
                        main_forma f2 = new main_forma();
                        f2.ShowDialog();
                 
                }else if(comboBox1.SelectedIndex == 1 && (userRole=="Korisnik" || userRole=="Administrator"))
                {
                    this.Hide();
                    main_forma_Korisnik f2 = new main_forma_Korisnik();
                    f2.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Username i password nisu tačni", "INFORMACIJE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            reader.Close();
            cmd.Dispose();
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            register_korisnik_panel f2 = new register_korisnik_panel();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Administrator");
            comboBox1.Items.Add("Korisnik");
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //MySqlCmdAdapt2
        }
    }
}
