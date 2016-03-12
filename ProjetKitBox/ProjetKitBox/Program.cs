﻿using System;
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

            /* WORKING => Add managerStock linkCommandeElement (DB) !!!!!
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

            comp.ManagerOrder.Add(o);
            */


            /* WORKING 
            List<StructStock> listStru = comp.ManagerStock.GetStateStock();
            
            foreach(StructStock stru in listStru)
            {
                Console.WriteLine(stru.numberOrdered);
            }
            */

            /* NOT WORKING => Ouverture DB dans GetBestSupplier , qui appel le contru de element by code , qui tente d'ouvrir la DB encore! 
            List<StructOrderSupplier> listOrder = comp.ManagerStock.GetBestSupplier();

            foreach(StructOrderSupplier struO in listOrder)
            {
                Console.WriteLine(struO.price);
            }
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
        }
    }
}
