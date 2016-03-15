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


            // WORKING => Add managerStock linkCommandeElement (DB) !!!!!
            /*
            Client c = new Client("TEST", "test", "000",comp.ManagerClient);


            comp.ManagerClient.AddClient(c);

            Order o = new Order(c);

            StructSize s = new StructSize(32, 32, 0);
            Shelf s1 = new Shelf(s, comp.ManagerStock);

            s1.AddBox(36, "Blanc");


            o.AddShelf(s1, "Brun");
            Console.WriteLine(s1.Size.heigth);
            Console.WriteLine(s1.Corner.Size.heigth);

            comp.ManagerOrder.Add(o);
            
            */



            /* WORKING 
            List<StructStock> listStru = comp.ManagerStock.GetStateStock();
            
            foreach(StructStock stru in listStru)
            {
                Console.WriteLine(stru.numberOrdered);
            }
            */

            /* WORKING
            List<StructOrderSupplier> listOrder = comp.ManagerStock.GetBestSupplier();

            foreach(StructOrderSupplier struO in listOrder)
            {
                Console.WriteLine(struO.price);
            }
            Console.ReadKey();
            */


            /* WORKING
            StructSize s = new StructSize(0, 0, 100);

            Element e = comp.ManagerStock.SearchElement("Corni", "Brun", s);


            Console.WriteLine(e.Code);
            */


            /* WORKING
            StructSize s = new StructSize(0, 0, 100);

            Element e = comp.ManagerStock.SearchElement("Corni", "Brun", s);

            Element e1 = comp.ManagerStock.SearchElementByCode(e.Code);

            Console.WriteLine(e1.Color);

            Console.ReadKey();
            */

            /* WORKING
            Element e = comp.ManagerStock.SearchElementByCode("COR100BLDEC");

            comp.ManagerStock.SetCommanded(e, 8);
            Console.ReadKey();
            */

            /*
            Element e = comp.ManagerStock.SearchElementByCode("COR100BLDEC");
            Element e1 = comp.ManagerStock.SearchElementByCode("COR100BRDEC");

            StructOrderSupplier s = new StructOrderSupplier(22.00, 13, 1, e, 30);
            StructOrderSupplier s1 = new StructOrderSupplier(22.00, 45, 2, e1, 40);
            List<StructOrderSupplier> list = new List<StructOrderSupplier>() { };
            list.Add(s);
            list.Add(s1);

            comp.ManagerStock.SaveCommand(list);
            Console.ReadKey();
            */
            /* WORKING
            Client e = comp.ManagerClient.Search("John", "010 25");
            Console.WriteLine(e.Name);
            Console.ReadKey();
            */

            /* NOTE WORKING , DON'T CARE 
            Client e = comp.ManagerClient.Search("TEST", "0");
            comp.ManagerClient.DelClient(e);
            */

            /* WORKING
            List<StructOrder> list = comp.ManagerOrder.GetSaleStatistic();
            Console.WriteLine(list[0].element.Code + " " + list [0].numberOrdered);
            Console.ReadKey();
            */

            /* WORKING
            comp.ManagerStock.RemoveFromStock(1);
            */
            /*
            List<StructOrderSupplier> list = comp.CommandStock();
            foreach(StructOrderSupplier tes in list)
            {
                Console.WriteLine(tes.element.Code + " " + tes.numberToCommand + " " + tes.IDSupplier );
            }
            comp.ManagerStock.SaveCommand(list);
            */
            /*
            Client c = comp.ManagerClient.Search("friejgrti", "0000");
            if (c==null)
            {
                Console.WriteLine("ok");

            }
            */



            List<StructOrderSupplier> stu = comp.CommandStock();

            foreach(StructOrderSupplier s in stu)
            {
                Console.WriteLine(s.element.Code);
            }
            Console.ReadKey();
        }
    }
}
