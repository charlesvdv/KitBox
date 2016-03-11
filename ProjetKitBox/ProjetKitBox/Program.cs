using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetKitBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Company comp = new Company();
            Client c = new Client("TEST", "test", "000");
            comp.ManagerClient.AddClient(c);

            Order o = new Order(c);



            Console.ReadKey();
        }
    }
}
