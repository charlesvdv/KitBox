using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    class ManagerOrder
    {
		private List<Order> orders;

		public ManagerOrder()
		{
			orders = new LinkedList<Order>(){ };
			//TODO : charge the DB in the list
			// wait before doing it ... Is it really useful ?
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
