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
    public class ManagerStock
    {
        private MySqlConnection DBCon;

        public ManagerStock(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}
        
        //Give us a list of the state of stock? How many commanded, reserved and in stock for each element
		public List<StructStock> GetStateStock()
		{
            string query = "SELECT PK_code, typeElement, couleur, hauteur, largeur, profondeur, prix, stockmin," +
                " nbrpieces, typeElement, stock, commande, reserve from element";

            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<StructStock> stu = new List<StructStock>() { }; 

            while(dataReader.Read())
            {
                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);
                Element e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                    (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                StructStock stru = new StructStock(e, (int)dataReader["commande"], (int)dataReader["stock"], (int)dataReader["reserve"], (int)dataReader["stockmin"]);

                stu.Add(stru); 
            }

            dataReader.Close();

            DBCon.Close();

            return stu; 
        }

        //Give us the best supplier, but only for one element(Used in the front when we want to add an element on the commande. 
        public StructOrderSupplier GetTheBestSupplier(Element e)
        {
            string query = "select min(prix), delai, FK_element, FK_fournisseur from linkelementfournisseur where FK_element='"+e.Code+"';";
            
            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex; 
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader reader = cmd.ExecuteReader();


            StructOrderSupplier stu = new StructOrderSupplier(0, 0, 0, null);

            while (reader.Read())
            {
                Element ee = new Element((string)reader["FK_element"], this);

                stu = new StructOrderSupplier(Convert.ToDouble(reader["min(prix)"]), (int)reader["delai"], (int)reader["FK_fournisseur"], ee);

                break;
            }

            reader.Close();

            DBCon.Close();

            return stu;
        }

        //The returned list tell us which is the best suppplier, then give us price and delay for each element
        public List<StructOrderSupplier> GetBestSupplier()
		{
            string query = "select prix, delai, FK_element, FK_fournisseur from linkelementfournisseur l1 " +
                "where( " +
                "prix = (select min(prix) from linkelementfournisseur l2 " +
                "where l2.FK_element = l1.FK_element order by delai)) " +
                "group by FK_element; ";
            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<StructOrderSupplier> stu = new List<StructOrderSupplier>(){ };

            while (reader.Read())
            {
                Element e = new Element((string)reader["FK_element"], this);

                StructOrderSupplier stru = new StructOrderSupplier(Convert.ToDouble(reader["prix"]), (int)reader["delai"], (int)reader["FK_fournisseur"], e);

                stu.Add(stru);
            }

            reader.Close();

            DBCon.Close();

            return stu; 
        }

        //Search an element in the database and give us all the information about it 
		public Element SearchElement(string type, string color, StructSize size)
		{
            string query = "SELECT * FROM " +
                "`element` WHERE `typeElement` LIKE '" + type + "' AND `couleur` LIKE '" + color + "' AND `hauteur` "+
                "LIKE "+ size.heigth +" AND `largeur` LIKE "+size.length+" AND `profondeur` LIKE "+size.depth;

            try
            {
                DBCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            Element e = null;
            
            int i = 0;
            while(dataReader.Read()) 
            {
                if (i > 0)
                {
                    throw new Exception("We can't have more thant one element matching this value");
                }

                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);

                e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize, 
                    (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                i++;
            }

            dataReader.Close();
            DBCon.Close();

            return e;
		}

        //Search a element in the database, only using is own code, adn give us all information about it
        public Element SearchElementByCode(string code)
        {
            string query = "SELECT PK_code,couleur,hauteur,largeur,profondeur,prix,typeElement,nbrpieces  FROM " +
                "`element` WHERE `PK_code` LIKE '" + code +"';";
            string server = "localhost";
            string database = "kitbox";
            string uid = "root";
            string password = "kitbox";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            MySqlConnection DBCon1 = new MySqlConnection(connectionString);
            try
            {
                DBCon1.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            MySqlCommand cmd = new MySqlCommand(query, DBCon1);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            Element e = null;

            while (dataReader.Read())
            {
                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);
                e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                        (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                break;
            }
            dataReader.Close();
            DBCon1.Close();

            return e;
        }

        //Find the corner in the database 
        public Element FindCorner(double heigth, string color)
		{
            string query = "SELECT * FROM `element` "+
                "WHERE `typeElement` LIKE 'corni' AND `couleur` LIKE '"+color+"' AND `hauteur` >= "+ heigth +"  order by hauteur LIMIT 1";

            try
            {
                DBCon.Open();
            } catch(Exception ex) { throw ex; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader reader = cmd.ExecuteReader();

            Element e = null;

            while(reader.Read())
            {
                StructSize size = new StructSize((int)reader["largeur"], 
                    (int)reader["profondeur"], (int)reader["hauteur"]);
                e = new Element((string)reader["typeElement"], (string)reader["couleur"], size,
                    (string)reader["PK_code"], Convert.ToDouble(reader["prix"]), (int)reader["nbrpieces"]);
                break;
            }

            reader.Close();

            DBCon.Close();

            return e;
        }

        /* USELESS
        //Set a number of comanded element in the database
        public void SetCommanded(Element element, int number)
        {
            string query = "UPDATE `kitbox`.`element` SET commande ='" + number +"' WHERE PK_code = '" + element.Code + "';";

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

            DBCon.Close();
        }
        */

        // Permit to save the number of commanded element for each element. 
        public void SaveCommand(List<StructOrderSupplier> structCommand)
        {
            //save in database
            string query = "START TRANSACTION; ";

            foreach (StructOrderSupplier orderSup in structCommand)
            {

                query += "update element set commande = commande + " + orderSup.numberToCommand + " where PK_code= '" + orderSup.element.Code + "'; ";
            }

            query += "COMMIT; ";
            try
            {
                DBCon.Open();
            }
            catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            cmd.ExecuteNonQuery();
            DBCon.Close();
            //sort the list by supplier
            List<StructOrderSupplier> sortedList = structCommand.OrderBy(x => x.IDSupplier).ToList();
            //create string that will be written in the file
            string text = "Commande Fournisseur \n\n";
            int idSupplier = -1;
            foreach (StructOrderSupplier stru in sortedList)
            {
                if(idSupplier != stru.IDSupplier)
                {
                    text += "\t Fournisseur " + stru.IDSupplier + "\n";
                    text += "\t\tCode Element | Delai | Prix \n";
                    idSupplier = stru.IDSupplier;
                }
                text += "\t\t" + stru.element.Code + "\t\t" + stru.delay +
                    "\t\t" + stru.price + "€ \n";
            }
            //write the string text in the file
            string user = Environment.UserName;
            using (StreamWriter sw = new StreamWriter("C:\\Users\\"+user+"\\Desktop\\commmandefournisseur.txt"))
            {
                sw.WriteLine(text);
            }

        }

        private struct StructElemCommand
        {
            public string codeElement;
            public int numOrdered;
            public int stock;

            public StructElemCommand(string c, int n, int s)
            {
                this.codeElement = c;
                this.numOrdered = n;
                this.stock = s;
            }
        }


        public void RemoveFromStock(int refCommand)
        {
            string queryCommand = "select e.PK_code, e.stock, l.quantiteTotale from linkcommandeelement l inner join "+
                "element e on e.PK_code = l.FK_element where FK_commande = "+ refCommand +";";

            try
            {
                DBCon.Open();
            } catch (Exception e)
            {
                throw e;
            }
            MySqlCommand cmd = new MySqlCommand(queryCommand, DBCon);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<StructElemCommand> codeElem = new List<StructElemCommand>() { };

            while (reader.Read())
            {
                codeElem.Add(new StructElemCommand(reader["PK_code"].ToString(), (int)reader["quantiteTotale"], (int)reader["stock"]));
            }

            reader.Close();

            //check if the stock is enough for the command
            foreach (StructElemCommand stru in codeElem)
            {
                if (stru.stock < stru.numOrdered)
                {
                    throw new Exception("We don't have enough stock right now for "+ stru.codeElement);
                }
            }

            string queryUpdate = "START TRANSACTION;";
            foreach(StructElemCommand stru in codeElem)
            {
                queryUpdate += "update element set reserve=reserve-" + stru.numOrdered + ", stock=stock-" + stru.numOrdered +
                    " where PK_code = '" + stru.codeElement + "'; ";
            }
            queryUpdate += "COMMIT; ";

            cmd = new MySqlCommand(queryUpdate, DBCon);

            cmd.ExecuteNonQuery();

            string queryUpdateCom = "update commande set retire=true where PK_refCommande = " + refCommand + " ;";

            cmd = new MySqlCommand(queryUpdateCom, DBCon);

            cmd.ExecuteNonQuery();
                                       
            DBCon.Close();
        }

        public List<StructOrderSupplier> GetInfoSupplier()
        {
            try
            {
                DBCon.Open();
            } catch (Exception e)
            {
                throw e;
            }

            string query = "select * from linkelementfournisseur order by FK_element";

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<StructOrderSupplier> list = new List<StructOrderSupplier>() { };
            while (reader.Read())
            {
                Element elem = SearchElementByCode((string)reader["FK_element"]);
                list.Add(new StructOrderSupplier(Convert.ToDouble(reader["prix"]), (int)reader["delai"], 
                    (int)reader["FK_fournisseur"], elem));
            }

            reader.Close();
            DBCon.Close();
            return list;
        }

        public void UpdateStock(List<StructStock> listElem)
        {
            try
            {
                DBCon.Open();
            } catch (Exception e)
            {
                throw e;
            }

            string query = "START TRANSACTION; ";
            foreach (StructStock stock in listElem)
            {
                query += "update element set stock=" + stock.numberInStock + ", commande=" + stock.numberOrdered +
                    ", reserve=" + stock.numberReserved + "where PK_code=" + stock.element.Code+"; ";
            }
            query += "COMMIT; ";

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            cmd.ExecuteNonQuery();

            DBCon.Close();
        }

        public void UpdateSuppliers(List<StructOrderSupplier> infoSup)
        {
            string query = "START TRANSACTION; ";
            foreach (StructOrderSupplier sup in infoSup)
            {
                query += "update linkelementfournisseur set prix="+sup.price+", delai="+sup.delay+
                    "where FK_element="+sup.element.Code + "and FK_fournisseur="+sup.IDSupplier+"; ";
            }
            query += "COMMIT; ";

            try
            {
                DBCon.Open();
            } catch(Exception e)
            {
                throw e;
            }
            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            cmd.ExecuteNonQuery();

            DBCon.Close();
        }
    }
}
