﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    public class Order
    {
        private List<Shelf> shelfs;
        private Client client; 

        public Order(Client client)
        {
            this.client = client;
        }
   
        public List<Shelf> Shelfs
        {
            get { return this.shelfs; }
        }

        public Client Client
        {
            get { return this.client; }
        }

        public List<Element> GetListElement()
        {
            //To implement
        }

        public void AddShelf(Shelf shelf)
        {
            //To implement
        }

        public void DelShelf(Shelf shelf)
        {
            //To implement
        }

    }
}