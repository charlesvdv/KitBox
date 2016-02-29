using System;
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
            List<Element> list = new List<Element>();
            foreach (Shelf s in shelfs)
            {
                List<Element> e = s.GetElements();
                foreach (Element ee in e)
                {
                    list.Add(ee);
                }
            }

            return list; 
        }

        public void AddShelf(Shelf shelf)
        {
            Shelf.SetCorner; 
            shelfs.Add(shelf);
        }

		public void DelShelf(Shelf shelf)
        {
			shelfs.Remove(shelf);
        }

    }
}
