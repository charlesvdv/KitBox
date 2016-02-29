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
    class ManagerOrder
    {
        private MySqlConnection DBCon;

        public ManagerOrder(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}

		public void Add(Order order)
		{
			//TODO : implementation
		}

		public List<StructOrder> GetSaleStatistic()
		{
			//TODO : implementation
		}
    }
}
