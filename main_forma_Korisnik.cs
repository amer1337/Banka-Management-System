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
    }
}
