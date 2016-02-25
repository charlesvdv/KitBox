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

        public Shelf(StructSize size, Element corner)
        {
            this.size = size;
            this.corner = corner; 
			this.supplementCut = false;
			this.price = 0;
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
			foreach (Element e in types) 
			{
				if (types.IndexOf (e.Type) != -1) 
				{
					throw new Exception ("There are more than one element in this box.");
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
		public void SetCorner()
		{
			Element corner = ManagerStock.FindCorner(this.size.heigth);
			if (corner.Type != "Cornières") 
			{
				throw new Exception ("Can't had a element that is not a corner");
			}
			this.corner = corner;
		}

		public void DelBox(Box box)
        {
			boxes.Remove(box);
        }
    }
}
