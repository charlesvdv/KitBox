using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql; 

namespace ProjetKitBox
{
    class Company
    {
		private ManagerStock managerStock;
		private ManagerClient managerClient;
		private ManagerOrder managerOrder;

		public Company() 
		{
			this.managerStock = new ManagerStock();
			this.managerClient = new ManagerClient();
			this.managerOrder = new ManagerOrder();
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
