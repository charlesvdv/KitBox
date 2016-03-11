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
            Client c = new Client("TEST", "test", "000");
            comp.ManagerClient.AddClient(c);

            Order o = new Order(c);

            StructSize s = new StructSize(32, 32, 0);
            Shelf s1 = new Shelf(s, comp.ManagerStock);

            s1.AddBox(42, "blanc");
            s1.AddBox(52, "brun");
            Console.WriteLine(s1.Size.heigth);
            Console.ReadKey();
        }
    }
}
