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
        List<StructOrderSupplier> commandToSupplier;
        public Form1()
        {
            InitializeComponent();
            comp = new Company();

        }

        private void ClickHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            commandToSupplier = comp.CommandStock();
            foreach (StructOrderSupplier order in commandToSupplier)
            {
                dataGridView1.Rows.Add(order.element.Type, order.element.Code, order.numberToCommand,
                    order.IDSupplier, order.price);
            }
            panel1.Visible = true;
        }

        private void AddElement_Click(object sender, EventArgs e)
        {
            Element elem = null;
            int quantity = 0;
            using (var modalform = new Boite_modale())
            {
                var result = modalform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        elem = comp.ManagerStock.SearchElementByCode(modalform.Code);
                        quantity = modalform.NumberToCommand;
                    } catch (Exception exp)
                    {
                        MessageBox.Show("An error occured : " + exp.Message);
                    }  
                }
            }
            commandToSupplier.Add(new StructOrderSupplier(0, 0, 0, null));
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
