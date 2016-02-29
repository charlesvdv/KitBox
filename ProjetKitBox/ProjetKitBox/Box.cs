using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    //Fini
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
            int nTotal = 0; 
            List<string> typeConstituant = new List<string>() {
                "Tasseau", "Traverse Av", "Traverse Ar", "Traverse GD", "Panneau Ar", "Panneau GD", "Panneau HB",  
            };
            foreach(string type in typeConstituant)
            {
                foreach(Element e in elements)
                {
                    if(e.Type == type)
                    {
                        nTotal++;
                    }
                }         
            }

            if(nTotal == 7)
            {
                return true; 
            }

            else
            {
                return false; 
            }
            
        }

        public double GetPrice()
        {
            double ad = 0;
            foreach(Element e in elements)
            {
                ad += e.Price; 
            }
            return ad; 
        }

		public void AddElement(Element elem)
        {
			elements.Add(elem);
        }

        public List<Element> GetElements()
        {
            List<Element> list = new List<Element>();

            foreach(Element e in elements)
            {
                list.Add(e);
            }

            return list; 
        }
    }
}
