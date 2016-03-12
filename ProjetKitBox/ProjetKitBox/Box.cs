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
        private ManagerStock managerStock;

        public Box(StructSize size, string color, ManagerStock managerStock)
        {
            this.size = size;
            this.color = color;
            this.managerStock = managerStock;
            this.elements = new List<Element>() { };
			AsyncPopulate();
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
			
		//populate the box with the element
		private void AsyncPopulate()
		{
			try 
			{
				elements.Add(new Element("Tasseau", new StructSize(0, 0, size.heigth - 4), "", managerStock));
				elements.Add(new Element("Traverse Av", new StructSize(size.length, 0, 0), "", managerStock));
				elements.Add(new Element("Traverse Ar", new StructSize(size.length, 0, 0), "", managerStock));
				elements.Add(new Element("Traverse GD", new StructSize(0, size.depth, 0), "", managerStock));
				elements.Add(new Element("Panneau Ar", new StructSize(size.length, 0, size.heigth-4), color, managerStock));
				elements.Add(new Element("Panneau GD", new StructSize(0, size.depth, size.heigth-4), color, managerStock));
				elements.Add(new Element("Panneau HB", new StructSize(size.length, size.depth, 0), color, managerStock));
			} 
			catch (Exception e)
			{
				throw e;
			}
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
