using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_panel
{
    public partial class main_forma_Korisnik : Form
    {
        public main_forma_Korisnik()
        {
            InitializeComponent();

            
        }
        //------------FORMATIRAJ-
        public string pamtiIme = "";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            transferNovcaKorisnik f2 = new transferNovcaKorisnik();
            f2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            produzenjeKarticeKorisnik f2 = new produzenjeKarticeKorisnik();
            f2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            editRacuna f2 = new editRacuna();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stanjeRacuna f2 = new stanjeRacuna();
            f2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.ShowDialog();
        }

        private void main_forma_Korisnik_Load(object sender, EventArgs e)
        {
                    /*  panel2.Visible = true;
                      label6.Visible = true;
                      label7.Visible = true;
                      pictureBox3.Visible = true;
                      txtbox.Visible = true;
                      button6.Visible = true;*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
               // GroupBoxRenderer.IsBackgroundPartiallyTransparent = false;    
               // GroupBoxRenderer.RenderMatchingApplicationState.Equals TO groupBox2;
        }
    }
}
