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
    public partial class dodavanjeNovca : Form
    {
        public dodavanjeNovca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                try
                {
                    string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                    string Query = "UPDATE ade.korisnici SET stanjeRacuna = stanjeRacuna + '" + cifra.Text + "' WHERE CVV = '" + cvv.Text + "'";
                    MySqlCommand com = new MySqlCommand();
                    MySqlConnection cnn = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, cnn);
                    MySqlDataReader MyReader2;
                    cnn.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Uspješno ste dodali +" + cifra.Text + " KM na korisnički račun !", "DODAVANJE USPJEŠNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    while (MyReader2.Read())
                    {
                    }
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nije moguće prebacivanje novca na računw", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Potvrdite da samovoljno uplaćujete novac na korisnički račun!", "POTVRDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        
        }

        private void dodavanjeNovca_Load(object sender, EventArgs e)
        {
           // cifra.Enabled = false;
        }

       private void checkBox1_Validated(object sender, EventArgs e)
       {
         
       }
    }
    }

