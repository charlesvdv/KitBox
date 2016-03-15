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
        private DataGridView dgv;
        public Boite_modale(Form parent, DataGridView dgv)
        {
            InitializeComponent();
            this.parent = parent;
            this.dgv = dgv;
            string[] suppliers = { "A", "B", "BEST"};
            foreach (Control c in this.Controls)
            {
                if (c is ComboBox)
                {
                    (c as ComboBox).Items.AddRange(suppliers);
                }
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (SupplierChoice.SelectedItem != null && Reference.Text != null)
            {
                dgv.Rows.Add(' ', Reference.Text, ' ', SupplierChoice.Text, ' ');
                parent.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
            
        }
    }
}
