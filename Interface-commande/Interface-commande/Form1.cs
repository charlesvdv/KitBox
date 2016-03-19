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
        List<StructStock> stockInfo;
        List<StructOrderSupplier> infoSupplier;
        public Form1()
        {
            InitializeComponent();
            comp = new Company();
            commandToSupplier = new List<StructOrderSupplier>() { };
            stockInfo = comp.ManagerStock.GetStateStock();
            infoSupplier = comp.ManagerStock.GetInfoSupplier();
        }

        public void EmptyDataGridView(DataGridView datagridview)
        {
            for(int i = datagridview.Rows.Count - 1; i > -1; i--)
            {
                datagridview.Rows.RemoveAt(i);
            }
        }

        public void RefreshDataGridViewStock()
        {
            EmptyDataGridView(dataGridView3);
            foreach(StructStock stock in stockInfo)
            {
                dataGridView3.Rows.Add(stock.element.Type, stock.element.Code, stock.numberInStock, 
                    stock.numberOrdered, stock.numberReserved);
            }
        }

        public void RefreshDataGridViewSupplier()
        {
            EmptyDataGridView(dataGridView4);
            foreach(StructOrderSupplier sup in infoSupplier)
            {
                dataGridView4.Rows.Add(sup.element.Type, sup.element.Code, sup.IDSupplier,
                    sup.price, sup.delay);
            }
            
        }

        public void RefreshDataGridViewCommandSupplier()
        {
            //empty the datagridviews
            EmptyDataGridView(dataGridView1);
            //populate the datagridview with newer data
            foreach (StructOrderSupplier order in commandToSupplier)
            {
                dataGridView1.Rows.Add(order.element.Type, order.element.Code, order.numberToCommand,
                    order.IDSupplier, order.price);
            }
        }

        public void RefreshDataGridViewLivraison()
        {
            //empty the datagridview
            EmptyDataGridView(dataGridView2);
            //populate data grid view
            foreach(StructStock stock in stockInfo)
            {
                if (stock.numberOrdered != 0)
                {
                    dataGridView2.Rows.Add(stock.element.Type, stock.element.Color, stock.numberOrdered, 0);
                }
            }
        }

        public void RefreshDataGridViewRemoveOrderClient(List<StructElemCommand> elemOrd)
        {
            EmptyDataGridView(dataGridView5);

            foreach(StructElemCommand elem in elemOrd)
            {
                dataGridView5.Rows.Add(elem.codeElement, elem.numOrdered, elem.price);
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
                RefreshDataGridViewCommandSupplier();
                panel1.Visible = false;
            }
        }

        private void GO_Click(object sender, EventArgs e)
        {
            int refOrder = Convert.ToInt32(textBoxRefCommand.Text);
            StructInfoOrder infoOrder = new StructInfoOrder();
            List<StructElemCommand> elemOrdered = new List<StructElemCommand>() { };
            try
            {
                infoOrder = comp.ManagerOrder.GetInfoOrder(refOrder);
                elemOrdered = comp.ManagerStock.GetElemFromCommand(refOrder);

            } catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue... Avez-vous bien entrée la bonne commande ?\n"+ ex.Message);
            }
            if (infoOrder.retire == false)
                RefreshDataGridViewRemoveOrderClient(elemOrdered);

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

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.ColumnIndex];
            if (e.ColumnIndex == 2)
            {
                int numberBalance = Convert.ToInt32(row.Cells[2]);
                if (numberBalance > 0)
                {
                    StructStock stock = stockInfo[e.ColumnIndex];
                    stock.numberInStock = stock.numberInStock + (stock.numberOrdered - numberBalance);
                    stock.numberOrdered = numberBalance;
                    stockInfo[e.ColumnIndex] = stock;
                } else
                {
                    MessageBox.Show("Vous ne pouvez pas mettre un nombre négatif!");
                    
                }
            } 
            RefreshDataGridViewLivraison();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comp.ManagerStock.SaveCommand(commandToSupplier);
            panel1.Visible = false;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Livraisons")
            {
                RefreshDataGridViewLivraison();   
            } else if (tabControl1.SelectedTab.Text == "Stock")
            {
                RefreshDataGridViewStock();
            } else if (tabControl1.SelectedTab.Text == "Fournisseurs")
            {
                RefreshDataGridViewSupplier();
            } 
        }

        private void StockUpdating_Click(object sender, EventArgs e)
        {
            try
            {
                comp.ManagerStock.UpdateStock(stockInfo);
            } catch (Exception ex)
            {
                MessageBox.Show("Une erreur est arrivée... Veuillez vérifier votre encodage ! \n" + ex.Message);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                comp.ManagerStock.UpdateSuppliers(infoSupplier);
            } catch(Exception ex)
            {
                MessageBox.Show("Une erreur est arrivée... Veuillez vérifier votre encodage ! \n" + ex.Message);
            }
            
        }

        private void dataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
            StructOrderSupplier sup = infoSupplier[e.RowIndex];

            if (e.ColumnIndex == 3)
            {
                double price = Convert.ToDouble(row.Cells[3]);
                if(price > 0)
                {
                    sup.price = price;
                }else
                {
                    MessageBox.Show("Vous ne pouvez pas mettre un nombre négatif");
                }
            } else if (e.ColumnIndex == 4)
            {
                int delai = Convert.ToInt32(row.Cells[4]);
                if (delai > 0)
                {
                    sup.delay = delai;
                } else
                {
                    MessageBox.Show("Vous ne pouvez pas entrer un nombre négatif !");
                }
            }
            infoSupplier[e.RowIndex] = sup;
            RefreshDataGridViewSupplier();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                comp.ManagerStock.RemoveFromStock(Convert.ToInt32(textBoxRefCommand.Text));
            } catch(Exception ex)
            {
                MessageBox.Show("Une erreur est survenue... Avez vous bien rentrer tout ce qu'il fallait ? \n" + ex.Message);
                return;
            }
            RefreshDataGridViewRemoveOrderClient(new List<StructElemCommand>() { });
        }
    }
}
