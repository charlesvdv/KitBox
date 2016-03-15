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
        public int stockMin;

        public StructStock(Element e, int numberOrdered, int numberInStock, int numberReserved, int stockMin)
        {
            this.stockMin = stockMin;
            this.element = e;
            this.numberInStock = numberInStock;
            this.numberOrdered = numberOrdered;
            this.numberReserved = numberReserved;
        }
	}
}

