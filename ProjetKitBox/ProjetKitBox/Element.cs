using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    public class Element
    {
        private string color;
        private double price;
        private StructSize size;
        private string type;
        private int code;
        private int requiredNumber;

		public Element(string type, string color, StructSize size, int code ,double price, int requiredNumber)
        {
            this.color = color;
            this.price = price;
            this.size = size;
            this.type = type;
            this.code = code;
            this.requiredNumber = requiredNumber;
        }

		public Element(string type, StructSize size, string color)
		{
			this.type = type;
			this.size = size;
			this.color = color;

			//get data from the database 
			Element elem;
			try 
			{
				elem = ManagerStock.SearchElement(type, color, size);
			}
			catch {
				//TODO
			}
			this.price = elem.price;
			this.code = elem.code;
			this.requiredNumber = elem.requiredNumber;
		}

        public string Color
        {
            get { return this.color; }
        }

        public double Price 
        {
            get { return this.price; }
        }

        public StructSize Size
        {
            get { return this.size; }
        }

        public string Type
        {
            get { return this.type; }
        }

        public int Number
        {
            get { return this.number; }
        }

        public int RequiredNumber
        {
            get { return this.requiredNumber; }
        }
    }
}
