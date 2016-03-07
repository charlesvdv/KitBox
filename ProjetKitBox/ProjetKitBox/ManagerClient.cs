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
    public class ManagerClient
    {
        private MySqlConnection DBCon;

        public ManagerClient(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}
        
		public void AddClient(Client client)
		{
            string query = "INSERT INTO `kitbox`.`client` (`PK_client`, `telephone`, `adresse`, `nom`) VALUES (NULL, '" + client.Telephone + "', '" + client.Adress + "', '" +  client.Name+"');";

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

		public void DelClient(Client client)
		{
            string query = "DELETE FROM `client` WHERE `PK_client` = '" + client.NClient +"';";

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

		public Client Search(string name)
		{
            string query = "SELECT * FROM `client` WHERE `nom` LIKE '%" + name + "%';";

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

            Client c = new Client((string)dataReader["nom"], (int)dataReader["NClient"],
                    (string)dataReader["adresse"], (string)dataReader["telephone"]);

            dataReader.Close();
            DBCon.Close();

            return c; 
        }
        
    }
}
