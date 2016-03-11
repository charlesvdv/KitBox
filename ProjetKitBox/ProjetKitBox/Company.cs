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
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

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
            List<StructStock> listStru = managerStock.GetStateStock();
            List<StructOrder> listOrd = managerOrder.GetSaleStatistic();
            List<StructOrderSupplier> listOrdSupp = managerStock.GetBestSupplier();

            List<StructOrder> needTo = new List<StructOrder>() { };
            if(listStru.Count == listOrd.Count)
            {
                foreach(StructStock struS in listStru)
                {
                    foreach(StructOrder struO in listOrd)
                    {
                        if (struS.element.Code == struO.element.Code)
                        {
                            int number = struS.numberInStock - struS.stockMin + struS.numberOrdered - struS.numberReserved;
                            number = number - struO.numberOrdered;
                            if (number < 0)
                            {
                                needTo.Add(new StructOrder(struS.element, -number));
                            }
                            break;
                        }
                    }
                }
            }

            else
            {
                throw new Exception("Les lists ne correspondent pas(il n'y à pas le même nombre d'element)");
            }

            List<StructOrderSupplier> needToWithSupp = new List<StructOrderSupplier>() { };

            foreach(StructOrder struc in needTo)
            {
                foreach(StructOrderSupplier struOr in listOrdSupp)
                {
                    if(struc.element.Code == struOr.element.Code)
                    {
                        needToWithSupp.Add(new StructOrderSupplier(struOr.price, struOr.delay, struOr.IDSupplier, struOr.element, struc.numberOrdered));
                        break;
                    }
                }
            }

            return needToWithSupp; 
        }
    }
}
