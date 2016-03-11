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
            string query = "INSERT INTO `kitbox`.`commande` (`prix total`, `FK_client`, `date`) " +
                "VALUES ('" + order.GetPrice() + "' , '" + order.Client.NClient + "', 'now()');";

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

        //Retrun a list of comanded number for each element in the past six month 
        public List<StructOrder> GetSaleStatistic()
		{
            string query = "select e.PK_code, e.typeElement, e.couleur, e.hauteur, e.largeur, e.longueur, e.prix, e.nbrpieces " +
                " sum(l.quantiteTotale) as tot from element e " +
                " inner join linkcommandeelement l on e.PK_code = l.FK_element " +
                "inner join commande on l.FK_commande = commande.PK_refCommande where commande.date" + 
                " between now() - interval 6 month and now() group by e.PK_code;";

            try
            {
                DBCon.Open();
            } catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<StructOrder> data = new List<StructOrder>() { };         
            
            while(dataReader.Read())
            {
                StructSize eSize = new StructSize((double)dataReader["largeur"], (double)dataReader["profondeur"], (double)dataReader["hauteur"]);
                Element e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize,
                    (string)dataReader["PK_code"], (double)dataReader["prix"], (int)dataReader["nbrpieces"]);

                StructOrder eOrd = new StructOrder(e, (int)dataReader["tot"]);

                data.Add(eOrd);  
            }

            dataReader.Close();
            DBCon.Close();

            return data; 
		}

        public void SaveCommand(List<StructOrderSupplier> structCommand)
        {
            string query = "UPDATE element SET";

            try
            {
                DBCon.Open();
            }
            catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader dataReader = cmd.ExecuteReader();


            foreach (StructOrderSupplier orderSup in structCommand)
            {

            }
        }


    }
}
