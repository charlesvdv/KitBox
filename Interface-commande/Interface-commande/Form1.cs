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
            commandToSupplier = new List<StructOrderSupplier>() { };
        }

        public void RefreshDataGridViewCommandSupplier()
        {
            //empty the datagridviews
            for(int i = dataGridView1.Rows.Count -1; i > -1 ; i--)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            //populate the datagridview with newer data
            foreach (StructOrderSupplier order in commandToSupplier)
            {
                dataGridView1.Rows.Add(order.element.Type, order.element.Code, order.numberToCommand,
                    order.IDSupplier, order.price);
            }
        }

        private void ClickHere_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            commandToSupplier = comp.CommandStock();
            RefreshDataGridViewCommandSupplier();
            panel1.Visible = true;
        }

        private void AddElement_Click(object sender, EventArgs e)
        {
            StructOrderSupplier orderElem = new StructOrderSupplier(0, 0, 0, null);
            using (var modalform = new Boite_modale())
            {
                var result = modalform.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        Element elem = comp.ManagerStock.SearchElementByCode(modalform.Code);
                        orderElem = comp.ManagerStock.GetTheBestSupplier(elem);
                        orderElem.numberToCommand = modalform.NumberToCommand;
                    } catch (Exception exp)
                    {
                        MessageBox.Show("An error occured : " + exp.Message);
                    }  
                }
            }
            if(orderElem.element != null)
            {
                commandToSupplier.Add(orderElem);
            }
            RefreshDataGridViewCommandSupplier();
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

        //get the change from the datagridview
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int quantity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (quantity == 0)
                {
                    commandToSupplier.RemoveAt(e.RowIndex);
                } else
                {
                    var elemToCommand = commandToSupplier[e.RowIndex];
                    elemToCommand.numberToCommand = quantity;
                    commandToSupplier[e.RowIndex] = elemToCommand;
                }
            } else
            {
                MessageBox.Show("You cannot edit this columns");
            }
            RefreshDataGridViewCommandSupplier();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comp.ManagerStock.SaveCommand(commandToSupplier);
            panel1.Visible = false;
        }

    }
}
