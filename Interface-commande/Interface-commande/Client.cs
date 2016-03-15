 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    //Fini
    public class Client 
    {
        private string name;
        private string adress;
        private string telephone;
        private int nClient;


        public Client(String name, string adress, string telephone,ManagerClient managerClient)
        {
            //check if the client already exist or not !
            Client c = managerClient.Search(name, telephone);
            if (c == null)
            {
                this.name = name;
                this.adress = adress;
                this.telephone = telephone;
                this.nClient = 0;
            } else
            {
                this.name = c.Name;
                this.adress = c.Adress;
                this.telephone = c.Telephone;
                this.nClient = c.NClient;
            }
        }

        public string Telephone
        {
            get { return this.telephone; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public string Adress
        {
            get { return this.adress; }
        }

        public int NClient
        {
            get { return this.nClient; }
            set { this.nClient = value;  }
        }

    }
}
