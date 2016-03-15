using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface_commande
{
    public partial class Boite_modale : Form
    {
        private Form parent;
        private string code;
        private int quantite;


        public Boite_modale()
        {
            InitializeComponent();
            this.code = "";
            this.quantite = 0;            
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (Reference.Text != "" && Quantite.Text != "")
            {
                this.code = Reference.Text;
                this.quantite = Convert.ToInt32(Quantite.Text);
                this.DialogResult = DialogResult.OK;
            }
        }

        public string Code
        {
            get { return code; }
        }

        public int NumberToCommand
        {
            get { return quantite; }
        }
    }
}
