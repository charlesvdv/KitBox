using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<StructOrderSupplier> stu = null;

            while (dataReader.Read())
            {
                Element e = new Element((string)dataReader["FK_element"], this);

                StructOrderSupplier stru = new StructOrderSupplier(Convert.ToDouble(dataReader["prix"]), (int)dataReader["delai"], (int)dataReader["FK_fournisseur"], e);

                stu.Add(stru);
            }

            dataReader.Close();

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

        public Element SearchElementByCode(string code)
        {
            string query = "SELECT PK_code,couleur,hauteur,largeur,profondeur,prix,typeElement,nbrpieces  FROM " +
                "`element` WHERE `PK_code` LIKE '" + code +"';";

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

            while (dataReader.Read())
            {
                StructSize eSize = new StructSize((int)dataReader["largeur"], (int)dataReader["profondeur"], (int)dataReader["hauteur"]);
                e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                        (string)dataReader["PK_code"], Convert.ToDouble(dataReader["prix"]), (int)dataReader["nbrpieces"]);

                break;
            }
            dataReader.Close();
            DBCon.Close();

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

        public void SaveCommand(List<StructOrderSupplier> structCommand)
        {
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

        }

        private struct StructElemCommand
        {
            public string codeElement;
            public int numOrdered;

            public StructElemCommand(string c, int n)
            {
                this.codeElement = c;
                this.numOrdered = n;
            }
        }


        public void RemoveFromStock(int refCommand)
        {
            string queryCommand = "select * from commandeelement where FK_commande = " + refCommand + ";";

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
                codeElem.Add(new StructElemCommand(reader["FK_element"].ToString(), (int)reader["quantiteTotale"]));
            }
       
            reader.Close();
            

        }

    }
}
