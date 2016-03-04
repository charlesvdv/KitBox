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

		}

		public List<StructOrderSupplier> GetBestSupplier()
		{

		}

		public Element SearchElement(string type, string color, StructSize size)
		{
            string query = "SELECT PK_code, prix, nbrpieces,hauteur,largeur,profondeur  FROM" +
                "`element` WHERE `typeElement` LIKE '" + type + "' AND `couleur` LIKE '" + color + "' AND `hauteur`"+
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
                StructSize eSize = new StructSize((double)dataReader["largeur"], (double)dataReader["profondeur"], (double)dataReader["hauteur"]);
                e = new Element((string)dataReader["typeElement"], (string)dataReader["couleur"], eSize, 
                    (string)dataReader["PK_code"], (double)dataReader["prix"], (int)dataReader["nbrpieces"]);

                i++;
            }

            dataReader.Close();
            DBCon.Close();

            return e;
		}

		public Element FindCorner(double heigth, string color)
		{


		}
        
    }
}
