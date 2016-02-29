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
    class ManagerClient
    {
        private MySqlConnection DBCon;

        public ManagerClient(MySqlConnection DBCon)
		{
            this.DBCon = DBCon;
		}

		public void AddClient(string name, string adress)
		{
			//TODO : implementation
		}

		public void DelClient(Client client)
		{
			//TODO : implementation
		}

		public Client Search(Client client)
		{
			//TODO : implementation
		}
    }
}
