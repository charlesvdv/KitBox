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

        public Shelf(StructSize size, Element corner)
        {
            this.size = size;
            this.corner = corner; 
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
            //To implement
        }

        public void DelBox(Box box)
        {
            //To implement
        }
    }
}
