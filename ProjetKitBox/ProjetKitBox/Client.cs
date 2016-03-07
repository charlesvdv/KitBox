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
        private int nClient;
        private string adress;
        private string telephone;

        public Client(String name, int nClient, string adress, string telephone)
        {
            this.name = name;
            this.nClient = nClient;
            this.adress = adress;
            this.telephone = telephone; 
        }

        public string Telephone
        {
            get { return this.telephone; }
        }

        public string Name
        {
            get { return this.name; }
        }
        
        public int NClient
        {
            get { return this.nClient; }
        }

        public string Adress
        {
            get { return this.adress; }
        }

    }
}
