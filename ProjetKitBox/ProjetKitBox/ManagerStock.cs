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
    class ManagerStock
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

		}

		public Element FindCorner(double heigth, string color)
		{

		}
    }
}
