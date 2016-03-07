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


        public void Add(Order order)
		{
            string query = "INSERT INTO `kitbox`.`commande` (`prix total`, `FK_client`, `date`) VALUES ('" + order.GetPrice() + "' , '" + order.Client.NClient + "', 'now()');";

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
            string query = "";

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
