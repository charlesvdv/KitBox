using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ProjetKitBox
{
    public class ManagerOrder
    {
        private MySqlConnection DBCon;

        public ManagerOrder(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}

        //Add an order in the database's order list
        public void Add(Order order)
		{
            //save the order in the database

            //calcute the number of supplement cut of the corner required 
            int supCutNumber = 0;
            foreach(Shelf shelf in order.Shelfs)
            {
                if (shelf.SupplementCut == true)
                {
                    supCutNumber += 1;
                } 
            }
            string price = order.GetPrice().ToString();
            price = price.Replace(',', '.');
            string query = "INSERT INTO `kitbox`.`commande` (`prix total`, `FK_client`, `date`, `coupeSup`) " +
                "VALUES ('" + price + "' , '" + order.Client.NClient + "', now(), "+ supCutNumber +");";

            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            cmd.ExecuteNonQuery();
            int PKCommand = Convert.ToInt32(cmd.LastInsertedId);

            //add the linkcommandeelement in the database
            InsertLinkElementCommand(order.GetListElement(), PKCommand);

            //save the state of the element save
            string queryRes = "START TRANSACTION;";
            foreach(Element elem in order.GetListElement())
            {
                queryRes += "update element set reserve = reserve + " +elem.RequiredNumber + " where PK_code = '" +
                    elem.Code + " '; " ;
            }
            queryRes += "COMMIT;";

            cmd = new MySqlCommand(queryRes, DBCon);
            cmd.ExecuteNonQuery();
            DBCon.Close();

            //save the data in a file that could be printed
            string WinUser = Environment.UserName;
            using (StreamWriter sw = new StreamWriter("C:\\Users\\"+WinUser+"\\Desktop\\commandeclient" + PKCommand+".txt"))
            {
                string text = "Commande N. " + PKCommand +"\n";
                text += "Client : " + order.Client.Name + ", numéro de téléphone : " + order.Client.Telephone + "\n";
                text += "\n \n";
                for(int i = 0; i < order.Shelfs.Count(); i++)
                {
                    text += "\t Armoire N. " + (i + 1) + " \n \n";
                    Shelf s = order.Shelfs[i];
                    for(int j = 0; j < s.Boxes.Count(); j++)
                    {
                        text += "\t \t Box N. " + (j + 1) + " \n";
                        Box b = s.Boxes[j];
                        text += "\t \t \t | Code référence\t | Quantité \t | Prix / Unité \n";
                        for (int q = 0; q < b.Elements.Count(); q++)
                        {
                            text += "\t \t \t " + b.Elements[q].Code + " \t\t\t\t\t " + b.Elements[q].RequiredNumber +
                                " \t\t\t\t\t " + b.Elements[q].Price + "\n";
                        }
                    }
                }

                text += "\n \n Prix Total : "+ order.GetPrice() + "€";
                sw.WriteLine(text);
            }

        }

        private struct ElemCount
        {
            public Element elem;
            public int num;

            public ElemCount(Element e, int num)
            {
                this.elem = e;
                this.num = num;
            }

        }

        private void InsertLinkElementCommand(List<Element> elems, int PKCommand)
        {
            //Don't need to open the DB because the connection is already open in Add(Order order)

            //list to save the number of element in a command without the duplicates elements
            List<ElemCount> SortedElem = new List<ElemCount>() { };
            
            //search in the lists elements for duplicates
            foreach(Element e in elems)
            {
                if (SortedElem.Exists(x => x.elem.Code == e.Code))
                {
                    int index = SortedElem.FindIndex(x => x.elem.Code == e.Code);

                    ElemCount elemCount = SortedElem[index];
                    elemCount.num += e.RequiredNumber;
                }
                else
                {
                    SortedElem.Add(new ElemCount(e, e.RequiredNumber));
                }
            }

            string query = "START TRANSACTION; ";
            foreach (ElemCount ec in SortedElem)
            {
                string price = ec.elem.Price.ToString().Replace(',', '.');
                query += "\ninsert into linkcommandeelement (FK_element, FK_commande, quantiteTotale, prix, quantiteRetiree)" +
                    " values ('" + ec.elem.Code +"' , "+ PKCommand+" , "+ ec.num+" , "+price+" , 0); ";
            }
            query += "\nCOMMIT; ";

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            cmd.ExecuteNonQuery();
            //Don't close the DB because the method is called in the Add(Order order) directly so 
            //don't need to close the DB.
        }

        //Retrun a list of comanded number for each element in the past six month 
        public List<StructOrder> GetSaleStatistic()
		{
            string query = "select e.PK_code, e.typeElement, e.couleur, e.hauteur, e.largeur, e.profondeur, e.prix, e.nbrpieces, " +
                "sum(l.quantiteTotale) as tot from element e " +
                "inner join linkcommandeelement l on e.PK_code = l.FK_element " +
                "inner join commande on l.FK_commande = commande.PK_refCommande where commande.date " + 
                "between now() - interval 6 month and now() group by e.PK_code;";

            try
            {
                DBCon.Open();
            } catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            List<StructOrder> data = new List<StructOrder>() { };         
            
            while(dataReader.Read())
            {
                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);
                Element e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                    (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                StructOrder eOrd = new StructOrder(e, Convert.ToInt32(dataReader["tot"]));

                data.Add(eOrd);  
            }

            dataReader.Close();
            DBCon.Close();

            return data; 
		}



        public StructInfoOrder GetInfoOrder(int refOrder)
        {
            string query = "select * from commande where PK_refCommande=" + refOrder + "; ";
            try
            {
                DBCon.Open();
            } catch(Exception e)
            {
                throw e;
            }
            StructInfoOrder s = new StructInfoOrder(0, 0, 0, false);

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            MySqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                s = new StructInfoOrder((int)reader["FK_client"], Convert.ToDouble(reader["prix total"]), (int)reader["coupeSup"], (bool)reader["retire"]);
                break;
            }
            reader.Close();
            DBCon.Close();
            return s;
        }
    }
}
