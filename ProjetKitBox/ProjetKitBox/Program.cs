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

            StructSize s = new StructSize(32, 32, 0);
            Shelf s1 = new Shelf(s, comp.ManagerStock);

            s1.AddBox(36, "Blanc");
            s1.AddBox(36, "Brun");

            o.AddShelf(s1, "Brun");
            Console.WriteLine(s1.Size.heigth);
            Console.WriteLine(s1.Corner.Size.heigth);
            List<Element> li = o.GetListElement();
            foreach(Element e in li)
            {
                Console.WriteLine(e.Type+" "+e.RequiredNumber);
            }
            Console.ReadKey();
        }
    }
}
