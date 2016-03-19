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
        int numeroMeuble = 1;
        int numeroCommande = 1;
        Order commande = null;
        Shelf shelf = null;       
        double prix = 0;
        double prixTotal = 0;
        
       

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
            string[] options = {"Pas d'options", "Porte (Blanc)", "Porte (Brun)", "Porte (Verre)"};
            string[] number = { "1", "2", "3", "4", "5", "6", "7" };
            string[] depths = { "32", "42", "52", "62" };
            string[] width = { "32", "42", "52", "62", "80", "100", "120" };
            
            //Parcourir les éléments de step1
            foreach (Control c in this.step1.Controls)
            {
                //Rentrer les données dans les ComboBox + on ne peut pas écrire dedans
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;

                    if (cb.Name.Contains("NumberLockersCh"))
                        cb.Items.AddRange(number);

                    else if (cb.Name.Contains("WidthCh"))
                        cb.Items.AddRange(width);

                    else if (cb.Name.Contains("DepthCh"))
                        cb.Items.AddRange(depths);
                }
            }
            foreach (Control c in this.step2.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (cb.Name.Contains("CornerColor"))
                        cb.Items.AddRange(colors);
                }
            }

            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                    //Parcourir les éléments compris dans les panels 
                    foreach (Control c in p.Controls)
                    {
                        if (c is ComboBox)
                        {
                            ComboBox cb = (ComboBox)c;
                            cb.DropDownStyle = ComboBoxStyle.DropDownList;

                            if (cb.Name.Contains("HeightCh"))
                                cb.Items.AddRange(eights);

                            else if (cb.Name.Contains("ColorCh"))
                                cb.Items.AddRange(colors);

                            else if (cb.Name.Contains("OptionCh"))
                            {
                                cb.Items.AddRange(options);
                                //set default value (not option)
                                cb.SelectedIndex = 0;
                            }
                                
                        }
                    }
            }
        }

        //Lorsqu'on change la valeur d'un ComboBox
        private void HC1_TextChanged(object sender, EventArgs e)
        {
            //Adapter la hauteur du meuble en temps réel
            int hauteurTotale = 0;
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                    foreach (Control c in p.Controls)
                    {
                        try
                        {
                            if (c is ComboBox)
                            {
                                int hauteurCasier = int.Parse(c.Text);
                                hauteurTotale = hauteurTotale + hauteurCasier;
                            }                       
                        }
                        catch { };                      
                    }
            }
            string ht = Convert.ToString(hauteurTotale);
            label9.Text = ht;

            //Code couleur pour la hauteur totale (standard - non standard)
            if (new[] { 36, 46, 72, 92, 108, 112, 138, 144, 168, 180, 184, 216, 224, 230, 252, 276, 280 }.Contains(hauteurTotale))
            {
                label9.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                label9.ForeColor = System.Drawing.Color.Red;
            }
        }
              
        //Lorsqu'on clic sur OK
        private void OK_Click(object sender, EventArgs e)
        {
            //Tester si l'utilisateur à tout completé
            if (LastName.TextLength != 0 && FirstName.TextLength != 0 && PhoneNumber.TextLength !=0 )
            {
                //Changer la visibilité/laccessibilité des panels et tabpages
                panel8.Visible = true;
                panel9.Visible = false;
                step1.Enabled = true;
                welcom.Enabled = false;
                //Changement d'onglet
                tabControl1.SelectedIndex = 1;
                //Coordonnées du client dans l'en-tête
                label49.Text = LastName.Text;
                label12.Text = FirstName.Text;
                //Check numéro meuble/commande
                string m = Convert.ToString(numeroMeuble);
                string c = Convert.ToString(numeroCommande);
                NumMeuble.Text = m;
                NumCommande.Text = c;
                //Création du client et de la commande
                Client cli = new Client(LastName.Text, FirstName.Text, PhoneNumber.Text, comp.ManagerClient);
                comp.ManagerClient.AddClient(cli);
                commande = new Order(cli);
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
                panel9.Visible = true;
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
                    if (p is ComboBox)
                    {
                        ComboBox cb = (ComboBox)p;
                        cb.SelectedIndex = -1;
                    }
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
                //Retour à step1 en remettant tout à 0 (conditions de départ)               
                step1.Enabled = true;
                step2.Enabled = false;
                tabControl1.SelectedIndex = 1;
                foreach (Control c in this.step1.Controls)
                    if (c is ComboBox)
                    {
                        ComboBox cb = (ComboBox)c;
                        cb.SelectedIndex = -1;
                    }
                foreach (Control p in this.step2.Controls)
                {
                    if (p is ComboBox)
                    {
                        ComboBox cb = (ComboBox)p;
                        cb.SelectedIndex = -1;
                    }
                    if (p is Panel)
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
        
        //Lorsqu'on clic sur suivant
        private void Next_Click(object sender, EventArgs e)
        {
            //Véifier si l'utilisateur a bien tout completé 
            if (WidthCh.SelectedItem != null && DepthCh.SelectedItem != null && NumberLockersCh.SelectedItem != null)
            {
                step2.Enabled = true;
                step1.Enabled = false;
                tabControl1.SelectedIndex = 2;
                //Création d'une liste de panels
                List<Panel> listPanel = new List<Panel>();
                listPanel.Add(panel1);
                listPanel.Add(panel2);
                listPanel.Add(panel3);
                listPanel.Add(panel4);
                listPanel.Add(panel5);
                listPanel.Add(panel6);
                listPanel.Add(panel7);
                //Afficher un nombre de boxes correspondant au nombre rentré par l'utilisateur
                int nombreCasiers = int.Parse(NumberLockersCh.Text);
                for (int i = nombreCasiers; i <= 6; i++)
                {
                    listPanel[i].Visible = false;
                }
                for (int j = 0; j < nombreCasiers; j++)
                {
                    listPanel[j].Visible = true;
                }
                int largeur = int.Parse(WidthCh.Text);
                int profondeur = int.Parse(DepthCh.Text);
                //Configuration de l'armoire
                StructSize s = new StructSize(largeur,profondeur,0);
                shelf = new Shelf(s, comp.ManagerStock);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }
        }

        //Lorsqu'on clic sur précédent
        private void Previous_Click(object sender, EventArgs e)
        {
            step1.Enabled = true;
            step2.Enabled = false;
            tabControl1.SelectedIndex = 1;            
            foreach (Control p in this.step2.Controls)
            {
                if (p is Panel)
                    foreach (Control c in p.Controls)

                        if (c is ComboBox)
                        {
                            ComboBox cb = (ComboBox)c;
                            cb.SelectedIndex = -1;
                        }
                if (p is ComboBox)
                {
                    ComboBox cb = (ComboBox)p;
                    cb.SelectedIndex = -1;
                }
            }
        }

        //Lorsqu'on clic sur ajouter au panier
        private void AddToCaddy_Click(object sender, EventArgs e)
        {
            //control if all the combobox are filled
            bool filled = true;
            foreach(Control ctrl in this.step2.Controls)
            {
                if(ctrl.Visible == true)
                {
                    //just for the combobox for the corner color
                    if(ctrl is ComboBox)
                    {
                        ComboBox cb = (ComboBox)ctrl;
                        if (cb.SelectedItem == null){ filled = false; break; }
                    }
                    //check the combobox inside the label
                    else if (ctrl is Panel)
                    {
                        Panel pan = (Panel)ctrl;
                        foreach (Control ctrlLabel in pan.Controls)
                        {
                            
                            if (ctrlLabel is ComboBox)
                            {
                                ComboBox cb = (ComboBox)ctrlLabel;
                                if (cb.SelectedItem == null) { filled = false; break; }
                            }
                        }
                    }
                }
                //we have two foreach loop so we break if the second foreach loop set filled to false
                //increase perf
                if(filled == false) { break; }
            }
            if (filled == false)
            {
                MessageBox.Show("Veuillez remplir toutes les informations !");
                return;
            }
            //create the box and populate them
            int boxNumber = -1;
            foreach(Control ctrl in step2.Controls)
            {
                if(ctrl is Panel && ctrl.Visible == true)
                {
                    Panel panel = (Panel)ctrl;
                    double height = 0;
                    string color = "";
                    string optionStr = "";
                    foreach (Control ctrlLabel in panel.Controls)
                    {
                        if(ctrlLabel is ComboBox)
                        {
                            ComboBox cb = (ComboBox)ctrlLabel;
                            if(cb.Name.Contains("HeightCh"))
                            {
                                height = Convert.ToDouble(cb.SelectedItem);
                            } else if (cb.Name.Contains("ColorCh"))
                            {
                                color = (string)cb.SelectedItem;
                            } else if (cb.Name.Contains("OptionCh"))
                            {
                                optionStr = (string)cb.SelectedItem;
                            }
                        }
                    }
                    shelf.AddBox(height, color);
                    boxNumber++;
                    //parse the option to have the type and the color
                    if (optionStr != "Pas d'options")
                    {
                        int beginBrackets = optionStr.LastIndexOf('(');
                        int endBrackets = optionStr.LastIndexOf(')');
                        int lenghtColor = endBrackets - beginBrackets - 1;
                        string colorOption = optionStr.Substring(beginBrackets + 1, lenghtColor).Trim();
                        string optionType = optionStr.Substring(0, beginBrackets).Trim();
                        try
                        {
                            shelf.Boxes[boxNumber].AddOption(optionType, colorOption);
                        } catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        
                    }
                }
            }

            if(shelf.SupplementCut == true)
            {
                MessageBox.Show("Attention un supplément de 30€ vous sera demandé parce que la hauteur de votre meuble n'est pas standard");
            }

            commande.AddShelf(shelf, (string)CornerColor.SelectedItem);

            prixTotal = commande.GetPrice();
            label10.Text = prixTotal.ToString() + " " + "€";
            step3.Enabled = true;
            step2.Enabled = false;
            tabControl1.SelectedIndex = 3;
            /*
            bool control = true;
            foreach (Control p in this.step2.Controls)
            {
                MessageBox.Show(p.Name);
                //test if we have empty combobox
                if (p is ComboBox)
                {
                    ComboBox cb = (ComboBox)p;
                    if (cb.SelectedItem ==null)
                    {
                        control = false;
                        break;
                    }
                }
                

                if (p is Panel && p.Visible)
                {                  
                    int hauteur = 0;
                    string couleur = "";                  
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
                                hauteur = int.Parse(cb.Text);
                            }
                            if (cb.Name.Contains("ColorCh"))
                            {
                                couleur = cb.Text;
                            }
                            
                            /*if (cb.Name.Contains("OptionCh"))
                            {
                                char idBoxC = cb.Name[cb.Name.Length - 1];
                                int idBox = Convert.ToInt32(idBoxC) - 1 - 48;
                                id[idBox] = idBox;
                                int nm = int.Parse(NumMeuble.Text);

                            }
                                                     
                        }                                           
                    }                                    
                    s1.AddBox(hauteur, couleur);
                }
            }
            //Si control = false -> l'utilisateur n'a pas rempli tous les champs 
            if (control == false)
            {
                MessageBox.Show("Veuillez remplir tous les champs" );
                return;
            }
            //Ajoter la l'armoire à la commande
            commande.AddShelf(s1, CornerColor.Text);

            //Checker si la hauteur totale du meuble est standard ou non 
            bool sup = false;
            sup = commande.Shelfs[commande.Shelfs.Count - 1].SupplementCut;           
            if (control)
            {
                if (sup)
                    if (MessageBox.Show("La hauteur de votre meuble n'est pas standard. Un supplément de 30€ vous sera demandé pour la découpe.", "Supplément découpe", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        listBox1.Items.Add("-> " + "Meuble" + NumMeuble.Text + "* " + "( " + prix + " " + "€" + " )");
                        sup = false;
                    }
                    else { }
                else
                {
                    listBox1.Items.Add("-> " + "Meuble" + NumMeuble.Text + " " + "( " + prix + " " + "€" + " )");
                }
                //Calcul du prix
                foreach (Shelf s in commande.Shelfs)
                {
                    prix = s.Price;
                    bool supplement = s.SupplementCut;
                }                                          
                prixTotal = prixTotal + prix;
                label10.Text = prixTotal.ToString() + " " + "€";
                step3.Enabled = true;
                step2.Enabled = false;
                tabControl1.SelectedIndex = 3;
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs");
            }         
            */
        }


        //Lorsqu'on clic sur nouveau meuble
        private void NewItem_Click(object sender, EventArgs e)
        {
            step1.Enabled = true;
            step3.Enabled = false;
            GoToCaddy.Enabled = true;
            tabControl1.SelectedIndex = 1;                      
            numeroMeuble = numeroMeuble + 1;
            string n = Convert.ToString(numeroMeuble);
            NumMeuble.Text = n;
            foreach (Control c in this.step1.Controls)
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = -1;
                }
            foreach (Control p in this.step2.Controls)
            {
                if (p is ComboBox)
                {
                    ComboBox cb = (ComboBox)p;
                    cb.SelectedIndex = -1;
                }
                if (p is Panel)
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

        //Lorsqu'on clic sur valider le panier
        private void ValidateCaddy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Valider la commande de " + NumMeuble.Text +" meuble(s) pour un prix total de " + label10.Text, "Validation du panier", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                comp.ManagerOrder.Add(commande);
            }
            else { }   
        }
       
        //Lorsqu'on clic sur panier
        private void GoToCaddy_Click(object sender, EventArgs e)
        {
            step3.Enabled = true;
            step2.Enabled = false;
            step1.Enabled = false;
            welcom.Enabled = false;
            tabControl1.SelectedIndex = 3;        
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
