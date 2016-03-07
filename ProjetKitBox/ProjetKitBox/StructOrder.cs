using System;

namespace ProjetKitBox
{
	//the element and the number of element ordered in the 6 months
	public struct StructOrder
	{
		public Element element;
		public int numberOrdered;

        public StructOrder(Element element, int numberOrdered)
        {
            this.element = element;
            if (numberOrdered >= 0)
            {
                this.numberOrdered = numberOrdered;
            } else
            {
                throw new Exception("Can't have a negative number for the number of elements ordered.");
            }
        }
	}
}

