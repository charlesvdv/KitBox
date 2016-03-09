using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
	//struct that caracterise all the info for the supplier order : 
	// - the supplier info (delai, price, name)
	// - the element information (the reference code is enough ?)
	public struct StructOrderSupplier
	{
		public double price;
		public int delay;
		public int IDSupplier;
		public string name;
		public Element element;

        public StructOrderSupplier(double price, int delay, int IDSupplier, string name, Element element)
        {
            this.price = price;
            this.delay = delay;
            this.IDSupplier = IDSupplier;
            this.name = name;
            this.element = element; 
        }
	}
}

