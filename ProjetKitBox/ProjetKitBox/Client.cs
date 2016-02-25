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

        public Client(String name, int nClient, string adress)
        {
            this.name = name;
            this.nClient = nClient;
            this.adress = adress;
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
