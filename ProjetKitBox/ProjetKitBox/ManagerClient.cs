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

        //Add client in the dabase
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

            query = "select PK_client from client where nom = '" + client.Name + "' and telephone='" + client.Telephone +"';";

            cmd = new MySqlCommand(query, DBCon);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            while(dataReader.Read())
            {
                client.NClient = (int)dataReader["PK_client"];
                break;
            }

            dataReader.Close();
            DBCon.Close();

        }

        /* USELESS => if delete on cascade, we're loosing all information about the client, even his element commanded
        //Delete a client from the database
		public void DelClient(Client client)
		{
            string query = "DELETE FROM `client` WHERE `nom` = '" + client.Name +"';";

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

        //Search a client from the database, and give us all the information about him
		public Client Search(string name, string tel)
		{
            string query = "SELECT * FROM `client` WHERE `nom` LIKE '%" + name + "%' AND  `telephone` like '%" + tel+"%';";

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
            Client c = null; 
            while (dataReader.Read())
            {
                c = new Client((string)dataReader["nom"],
                        (string)dataReader["adresse"], (string)dataReader["telephone"]);
            }

            dataReader.Close();
            DBCon.Close();

            return c;  
        }
        
    }
}
