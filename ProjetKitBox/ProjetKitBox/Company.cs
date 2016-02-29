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
    class Company
    {
		private ManagerStock managerStock;
		private ManagerClient managerClient;
		private ManagerOrder managerOrder;
        private MySqlConnection DBCon;

        private MySqlConnection Initialize()
        {
            string server = "localhost";
            string database = "kitbox";
            string uid = "root";
            string password = "kitbox";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "U`enter code here`ID=" + uid + ";" + "PASSWORD=" + password + ";";

            return new MySqlConnection(connectionString);
        }

        public Company() 
		{
            try
            {
                DBCon = Initialize();
            }
            catch (Exception e)
            {
                throw e;
            }
			this.managerStock = new ManagerStock(DBCon);
			this.managerClient = new ManagerClient(DBCon);
			this.managerOrder = new ManagerOrder(DBCon);
		}

        public ManagerStock ManagerStock
        {
            get { return this.managerStock; }
        }

        public ManagerOrder ManagerOrder
        {
            get { return this.managerOrder; }
        }

        public ManagerClient ManagerClient
        {
            get { return this.managerClient; }
        }

        
		public List<StructOrderSupplier> CommandStock()
		{
			//TODO : implementation
		}

		public void SaveCommand(List<StructOrderSupplier> structCommand)
		{
			//TODO : implementation
		}
        
    }
}
