using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    class ManagerClient
    {
		private List<Client> clients;

		public ManagerClient()
		{
			clients = new List<Client>(){};
			//TODO : charge the DB in the lists 
			// wait before doing it ... Is it really useful ?
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
