using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetKitBox;

namespace Interface_commande
{
    public partial class Form1 : Form
    {
        Company comp;
        public Form1()
        {
            InitializeComponent();
            comp = new Company();

        }

        private void ClickHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            List<StructOrderSupplier> list = comp.CommandStock();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
            panel1.Visible = true;

        }
        private void AddElement_Click(object sender, EventArgs e)
        {
            Boite_modale Boite_modale = new Boite_modale(this, dataGridView1);
            Boite_modale.Show();
            this.Hide();
        }

        private void Cancel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler la commande?", "Annulation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                panel1.Visible = false;
            }
        }

        private void GO_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
    }
}
