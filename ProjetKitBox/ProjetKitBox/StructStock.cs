using System;

namespace ProjetKitBox
{
	//caracterise the element and the number of the element in the stock 
	public struct StructStock
	{
		public Element element;
		public int numberOrdered; 
        public int numberInStock;
        public int numberReserved; 

        public StructStock(Element e, int numberOrdered, int numberInStock, int numberReserved)
        {
            this.element = e;
            this.numberInStock = numberInStock;
            this.numberOrdered = numberOrdered;
            this.numberReserved = numberReserved;
        }
	}
}

