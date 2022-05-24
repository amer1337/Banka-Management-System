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
    public partial class transferNovcaKorisnik : Form
    {
        public transferNovcaKorisnik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // string konekcije za mysql, podaci za putanju baze

                string MyConnection2 = "datasource=localhost;port=3306;username=root;password=Amerdelic1.";
                MySqlConnection cnn = new MySqlConnection(MyConnection2);
                cnn.Open();

                //otvaranje konekcije, pocetak komunikacije

                string s1 = "UPDATE ade.korisnici SET stanjeRacuna = stanjeRacuna - '" + textBox2.Text + "' WHERE username = '" + txtIme.Text + "'"; 
                string s2 = "UPDATE ade.korisnici SET stanjeRacuna = stanjeRacuna + '" + textBox2.Text + "' WHERE username = '" + textBox4.Text+"'";

                /*
                  dva kverija koji sluze da se novac sa jednog racuna skine odnosno da se novac
                  prebaci na drugi racun uz to da se automatski nakon prebacivanja oba korisnička
                  racuna updateuju
                 */

                MySqlTransaction t = cnn.BeginTransaction();

                // mysql funkcija za transakcije

                MySqlCommand cmd = new MySqlCommand(s1, cnn, t);
                int a = cmd.ExecuteNonQuery();

                // storeovanje prvog kverija u int jer ga tako mozemo provjeriti da li je jednak nuli

                MySqlCommand cmd2 = new MySqlCommand(s2, cnn, t);
                int b = cmd2.ExecuteNonQuery();

                // storeovanje drugog kverija u int jer ga tako mozemo provjeriti da li je jednak nuli

                if (a == 0 || b == 0)
                {
                    t.Rollback();
                    MessageBox.Show("Nije moguće!");
                    
                    //ukoliko su oba kverija jednaka nuli transakcija se neće izvršiti nego će vratiti poruku
                    //nije moguće

                }
                else
                {
                    t.Commit();
                    MessageBox.Show("Uspješno ste izvršili prebacivanje "+textBox2.Text+" KM na račun "+textBox4.Text+".");
                
                    //ukoliko se transakcija uspješno izvrši oba korisnička računa će biti
                    //updateovana uz poruku da je transakcija uspješno izvršena

                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //ukoliko dođe do errora(najčešće može biti direktno u MySql-u), ex.Message će nam ispisati grešku 
                //na isti način kako bi to mysql uradio

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main_forma_Korisnik f2 = new main_forma_Korisnik();
            f2.ShowDialog();

            //button za nazad, vraćanje na početnu formu za korisnika

        }
    }
}
