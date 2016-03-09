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

        //Add an order in the database 
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

        public List<StructOrder> GetSaleStatistic()
		{
            string query = "select e.PK_code, sum(l.quantiteTotale) as tot from element e " +
                " inner join linkcommandeelement l on e.PK_code = l.FK_element " +
                "inner join commande on l.FK_commande = commande.PK_refCommande where commande.date" + 
                " between now() - interval 6 month and now() group by e.PK_code;";

            try
            {
                DBCon.Open();
            } catch (Exception e) { throw e; }

            MySqlCommand cmd = new MySqlCommand(query, DBCon);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<StructOrder> data = new List<StructOrder>() { };         
            
            while(reader.Read())
            {

            }   
		}
        
    }
}
