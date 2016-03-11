using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    public class Shelf
    {
        private StructSize size;
        private List<Box> boxes;
        private Element corner; 
		private bool supplementCut;
		private double price;
        private ManagerStock managerStock; 

        public Shelf(StructSize size, ManagerStock managerStock)
        {
            this.size = size; 
			this.supplementCut = false;
			this.price = 0;
            this.managerStock = managerStock; 
        }

        public bool SupplementCut
        {
            get { return this.supplementCut; }
        }

        public StructSize Size
        {
            get { return this.size; }
        }
        public List<Box> Boxes
        {
            get { return this.boxes; }
        }

        public Element Corner
        {
            get { return this.corner; }
        }

        public void AddBox(Box box)
        {
			//check if the box is complete
			if (!box.IsComplete()) 
			{
				throw new Exception("The box that you tried to create is not complete.");
			}

			//test if we have more than one element
			List<string> types = new List<string>(){};
			foreach(Element e in box.GetElements()) 
			{
				if (types.IndexOf (e.Type) != -1) 
				{
					throw new Exception ("There is more than one element in this box.");
				}
				types.Add(e.Type);
			}

			//calculate the size of the shelf
			this.size.heigth += box.Size.heigth;

			//calculate the price of the shelf
			this.price += box.GetPrice();

			boxes.Add(box);
        }

		//the return boolean say if we need cutting the corner
		public void SetCorner(string color)
		{
			Element corner = managerStock.FindCorner(this.size.heigth, color);

            if (corner.Type != "Cornières") //Don't we need to rename it corni ? 
            {
                throw new Exception("Can't had a element that's not a corner");
            }

            else if(corner.Size.heigth > size.heigth)
            {
                supplementCut = true;
            }

            else if (corner.Size.heigth < size.heigth)
            {
                throw new Exception("The corner is smaller than the shelf.");
            }

			this.corner = corner;
		}

		public void DelBox(Box box)
        {
			boxes.Remove(box);
        }

        //return a list of all of the element in the shelf
        public List<Element> GetElements()
        {
            List<Element> list = new List<Element>();
            foreach (Box b in Boxes)
            {
                List<Element> e = b.GetElements();
                foreach (Element ee in e)
                {
                    list.Add(ee);
                }
            }

            list.Add(corner);
            
            return list; 
        }
    }
}
