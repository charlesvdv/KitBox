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

namespace Interface_Client
{
    public partial class Form1 : Form
    {
        Company comp = new Company();
        Shelf s1 = null;
        Order o = null;
        int numeromeuble = 1;
        int numerocommande = 1;
        public Form1()
        {
            InitializeComponent();
            //Désactivation des onglets non nécessaires 
            step1.Enabled = false;
            step2.Enabled = false;
            step3.Enabled = false;
            //Introduction des variables à ajouter dans les ComboBox
            string[] eights = {"36", "46", "56" };
            string[] colors = { "Blanc", "Brun" };
            string[] options = { "Porte (blanc)", "Porte (brun)", "Porte (verre)", "Tiroir" };
            string[] number = { "1", "2", "3", "4", "5", "6", "7" };
            string[] depths = { "32", "42", "52", "62" };
            string[] width = { "32", "42", "52", "62", "80", "100", "120" };
            //Désactiver la possibilité d'écrire dans les ComboBox
            foreach (Control c in this.step1.Controls)
            {
                if (c is ComboBox)
                {
                    (c as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
            //Remplir les ComboBox de step1
            foreach (Control c in this.step1.Controls)
            {
                if (c is ComboBox)
                {
                    if ((c as ComboBox).Name.Contains("NumberLockersCh"))
                        (c as ComboBox).Items.AddRange(number);
                }
                if (c is ComboBox)
                {
                    if ((c as ComboBox).Name.Contains("WidthCh"))
                        (c as ComboBox).Items.AddRange(width);
                }
                if (c is ComboBox)
                {
                    if ((c as ComboBox).Name.Contains("DepthCh"))
                        (c as ComboBox).Items.AddRange(depths);
                }

            }

            //Remplir les ComboBox de step2
            foreach (Control c in this.step2.Controls)
            {
                if (c is ComboBox)
                {
                    (c as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;
                    if ((c as ComboBox).Name.Contains("CornerColor"))
                        (c as ComboBox).Items.AddRange(colors);
                }
            }
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                    foreach (Control c in p.Controls)
                    {

                        if (c is ComboBox)
                        {
                            (c as ComboBox).DropDownStyle = ComboBoxStyle.DropDownList;

                            if ((c as ComboBox).Name.Contains("HeightCh"))
                                (c as ComboBox).Items.AddRange(eights);

                            else if ((c as ComboBox).Name.Contains("ColorCh"))
                                (c as ComboBox).Items.AddRange(colors);

                            else if ((c as ComboBox).Name.Contains("OptionCh"))
                                (c as ComboBox).Items.AddRange(options);
                        }
                    }
            }
        }
        //Adapter la hauteur du meuble en temps réel
        private void HC1_TextChanged(object sender, EventArgs e)
        {

            int b = 0;
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                    foreach (Control co in p.Controls)
                    {
                        try
                        {
                            if (co is ComboBox)
                            {
                                int a = int.Parse(co.Text);
                                b = b + a;
                            }
                        }
                        catch { };                      
                    }
            }
            string c = Convert.ToString(b);
            label9.Text = c;           
        }      
        //Lorsqu'on clic sur OK
        private void OK_Click(object sender, EventArgs e)
        {
            if (LastName.TextLength != 0 && FirstName.TextLength != 0 && PhoneNumber.TextLength !=0 )
            {
                panel8.Visible = true;
                step1.Enabled = true;
                welcom.Enabled = false;
                tabControl1.SelectedIndex = 1;
                label49.Text = LastName.Text;
                label12.Text = FirstName.Text;
                string m = Convert.ToString(numeromeuble);
                string c = Convert.ToString(numerocommande);
                NumMeuble.Text = m;
                NumCommande.Text = c;
                Client cli = new Client(LastName.Text + " " + FirstName.Text , " ", PhoneNumber.Text);
                comp.ManagerClient.AddClient(cli);
                o = new Order(cli);


            }
            else
            {
                MessageBox.Show("Veuillez compléter vos coordonnées");
            }

        }
        //Lorsqu'on clic sur annuler la commande
        private void CancelOrder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler la commande?", "Annulation de commande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabControl1.SelectedIndex = 0;
                panel8.Visible = false;
                welcom.Enabled = true;
                step1.Enabled = false;
                step2.Enabled = false;
                step3.Enabled = false;
                NumMeuble.Text = "0";
                NumCommande.Visible = false;
                foreach (Control t in this.welcom.Controls)
                {
                    if (t is TextBox)
                    {
                        t.Text = "";
                    }
                }
                foreach (Control c in this.step1.Controls)
                {
                    if (c is ComboBox)
                    {
                        ComboBox cb = (ComboBox)c;
                        cb.SelectedIndex = -1;
                    }
                }
                foreach (Control p in this.step2.Controls)
                {
                    if (p is Panel)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is ComboBox)
                            {
                                ComboBox cb = (ComboBox)c;
                                cb.SelectedIndex = -1;
                            }
                        }

                    }
                }

            }
        }

        //Lorsqu'on clic sur annuler le meuble
        private void CancelItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vraiment annuler le meuble?", "Annulation du meuble", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tabControl1.SelectedIndex = 1;
                step1.Enabled = true;
                step2.Enabled = false;
                foreach (Control c in this.step1.Controls)
                {
                    if (c is ComboBox)
                    {
                        ComboBox cb = (ComboBox)c;
                        cb.SelectedIndex = -1;
                    }
                }
                foreach (Control p in this.step2.Controls)
                {
                    if (p is Panel)
                    {
                        foreach (Control c in p.Controls)
                        {
                            if (c is ComboBox)
                            {
                                ComboBox cb = (ComboBox)c;
                                cb.SelectedIndex = -1;
                            }
                        }

                    }
                }
            }
        }
        
        //Lorsqu'on clic sur suivant
        private void Next_Click(object sender, EventArgs e)
        {
            if (WidthCh.SelectedItem != null && DepthCh.SelectedItem != null && NumberLockersCh.SelectedItem != null)
            {
                step2.Enabled = true;
                step1.Enabled = false;
                tabControl1.SelectedIndex = 2;
                List<Panel> listPanel = new List<Panel>();
                listPanel.Add(panel1);
                listPanel.Add(panel2);
                listPanel.Add(panel3);
                listPanel.Add(panel4);
                listPanel.Add(panel5);
                listPanel.Add(panel6);
                listPanel.Add(panel7);

                int a = int.Parse(NumberLockersCh.Text);
                for (int i = a; i <= 6; i++)
                {
                    listPanel[i].Visible = false;
                }

                for (int j = 0; j < a; j++)
                {
                    listPanel[j].Visible = true;
                }

                int b = int.Parse(WidthCh.Text);
                int c = int.Parse(DepthCh.Text);
                StructSize s = new StructSize(b,c,0);
                s1 = new Shelf(s, comp.ManagerStock);

            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        //Lorsqu'on clic sur précédent
        private void Previous_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            step1.Enabled = true;
            step2.Enabled = false;
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is ComboBox)
                        {
                            ComboBox cb = (ComboBox)c;
                            cb.SelectedIndex = -1;
                        }
                    }

                }
            }
        }

        //Lorsqu'on clic sur ajouter au panier
        private void AddToCaddy_Click(object sender, EventArgs e)
        {
            step3.Enabled = true;
            step2.Enabled = false;
            bool control = true;
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel && p.Visible)
                {
                    
                    int a = 0;
                    string b = "";
                   
                    foreach (Control c in p.Controls)
                    {
                        if (c is ComboBox)
                        {
                            ComboBox cb = (ComboBox)c;
                            if (cb.SelectedItem == null)
                            {
                                control = false;
                                break;
                            }
                            if (cb.Name.Contains("HeightCh"))
                            {
                                a = int.Parse(cb.Text);
                            }
                            if (cb.Name.Contains("ColorCh"))
                            {
                                b = cb.Text;
                            }
                        }                                           
                    }
                    o.AddShelf(s1, CornerColor.Text);
                    s1.AddBox(a, b);
                }
            }
            
            
                
                if (control)
                {
                    checkedListBox1.Items.Add("Meuble" + NumMeuble.Text);
                    tabControl1.SelectedIndex = 3;
                }
                else
                {
                    MessageBox.Show("Veuillez remplir tous les champs");
                }
        }


        //Lorsqu'on clic sur nouveau meuble
        private void NewItem_Click(object sender, EventArgs e)
        {
            step1.Enabled = true;
            step3.Enabled = false;
            GoToCaddy.Enabled = true;
            tabControl1.SelectedIndex = 1;
            numeromeuble = numeromeuble + 1;
            string n = Convert.ToString(numeromeuble);
            NumMeuble.Text = n;

            foreach (Control c in this.step1.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                }
            }
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                {
                    foreach (Control c in p.Controls)
                    {
                        if (c is ComboBox)
                        {
                            ComboBox cb = (ComboBox)c;
                            cb.SelectedIndex = -1;
                        }
                    }

                }
            }
        }

        //Lorsqu'on clic sur valider le panier
        private void ValidateCaddy_Click(object sender, EventArgs e)
        {
            comp.ManagerOrder.Add(o);
        }
       
        //Lorsqu'on clic sur panier
        private void GoToCaddy_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            step3.Enabled = true;
            step2.Enabled = false;
            step1.Enabled = false;
            welcom.Enabled = false;
        
        }
        //Checker bouton entre et escape
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    AcceptButton = OK;
                    break;
                case 1:
                    AcceptButton = Next;
                    CancelButton = CancelOrder;
                    break;             
                case 2:
                    AcceptButton = AddToCaddy;
                    CancelButton = CancelOrder2;
                    break;
                case 3:
                    AcceptButton = ValidateCaddy;
                    CancelButton = CancelOrder3;
                    break;
            }
        }
    }
}
