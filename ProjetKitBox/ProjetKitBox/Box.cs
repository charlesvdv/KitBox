using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    public class Box
    {
        private StructSize size;
        private List<Element> elements;
        private string color;

        public Box(StructSize size, string color)
        {
            this.size = size;
            this.color = color;
        }

        public StructSize Size
        {
            get { return this.size; }
        }

        public List<Element> Elements
        {
            get { return this.elements; }
        }

        public string Color
        {
            get { return this.color; }
        }

        public bool IsComplete()
        {
            return true; 
        }

		public void AddElement(Element element)
        {

        }
    }
}
