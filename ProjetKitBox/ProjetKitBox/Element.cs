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
        private int number;
        private int requiredNumber;

        public Element(string color, double price, StructSize size, string type, int number, int requiredNumber)
        {
            this.color = color;
            this.price = price;
            this.size = size;
            this.type = type;
            this.number = number;
            this.requiredNumber = requiredNumber;
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
