using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AukcijaKlijent
{
    public partial class Form1 : Form
    {
        //ServiceReferenceAukcija.IAukcijaClient proxy = new ServiceReferenceAukcija.IAukcijaClient();
        ServiceReference1.AukcijaClient proxy = new ServiceReference1.AukcijaClient();
        string klijent;
        string idEksponata;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv.DataSource = proxy.vratiSveEksponate();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dgv.SelectedCells.Count>0)
            {
                int izabran = dgv.SelectedCells[0].RowIndex;
                DataGridViewRow red = dgv.Rows[izabran];
                String id = Convert.ToString(red.Cells[1].Value);

                //MessageBox.Show("Id je " + id);
                List<Object> lEks = new List<Object>();
                lEks.Add(proxy.vratiEksponat(id));
                dgv2.DataSource = lEks;

                //klijent = proxy.vratiIdKlijenta(id, textBox1.Text, textBox2.Text);
                idEksponata = id;
                proxy.prijaviLicitaciju(id, textBox1.Text, textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            proxy.odustaniOdLicitacije(idEksponata, klijent);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            proxy.povecajCenu(idEksponata, textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));

            List<Object> lEks = new List<Object>();
            lEks.Add(proxy.vratiEksponat(idEksponata));
            dgv2.DataSource = lEks;
        }
    }
}
