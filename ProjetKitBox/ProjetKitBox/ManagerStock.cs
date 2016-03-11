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
            string query = "SELECT PK_code, typeElement, couleur, hauteur, largeur, longueur, prix, stockmin," +
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

            List<StructStock> stu = null; 

            while(dataReader.Read())
            {
                StructSize eSize = new StructSize((double)dataReader["largeur"], (double)dataReader["profondeur"], (double)dataReader["hauteur"]);
                Element e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                    (string)dataReader["PK_code"], (double)dataReader["prix"], (int)dataReader["nbrpieces"]);

                StructStock stru = new StructStock(e, (int)dataReader["commande"], (int)dataReader["stock"], (int)dataReader["reserve"], (int)dataReader["stockmin"]);

                stu.Add(stru); 
            }

            dataReader.Close();

            DBCon.Close();

            return stu; 
        }

		public List<StructOrderSupplier> GetBestSupplier()
		{
            string query = "select prix, delai, FK_Element, FK_fournisseur from linkelementfournisseur l1 " +
                "where( " +
                "prix = (select min(prix) from linkelementfournisseur l2 " +
                "where l2.FK_Element = l1.FK_Element order by delai)) " +
                "group by FK_Element; ";
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
                Element e = new Element((string)dataReader["PK_code"], this);

                StructOrderSupplier stru = new StructOrderSupplier((double)dataReader["prix"], (int)dataReader["delai"], (int)dataReader["FK_fournisseur"], e);

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
            } catch (Exception ex)
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

            StructSize eSize = new StructSize((double)dataReader["largeur"], (double)dataReader["profondeur"], (double)dataReader["hauteur"]);
            Element e = new Element((string)dataReader["typeElement"],(string)dataReader["couleur"], eSize,
                    (string)dataReader["prix"], (double)dataReader["prix"],(int)dataReader["nbrpieces"]);

            dataReader.Close();
            DBCon.Close();

            return e;
        }

        //Find the corner in the database 
        public Element FindCorner(double heigth, string color)
		{
            string query = "SELECT PK_code, prix, nbrpieces,hauteur FROM `element` "+
                "WHERE `typeElement` LIKE 'corni' AND `couleur` LIKE '"+color+"' AND `hauteur` >= "+ heigth +" LIMIT 1";

            try
            {
                DBCon.Open();
            } catch(Exception ex) { throw ex; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader reader = cmd.ExecuteReader();

            Element e = null;

            while(reader.Read())
            {
                StructSize size = new StructSize((double)reader["largeur"], 
                    (double)reader["profondeur"], (double)reader["hauteur"]);
                e = new Element((string)reader["typeElement"], (string)reader["couleur"], size,
                    (string)reader["PK_code"], (double)reader["prix"], (int)reader["nbrpieces"]);
                break;
            }

            reader.Close();

            DBCon.Close();

            return e;
        }

        //Set a number of comanded element in the database
        public void setCommanded(Element element, int number)
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
    }
}
