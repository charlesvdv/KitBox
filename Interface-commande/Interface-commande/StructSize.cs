using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    public struct StructSize
    {
        public double length;
        public double depth;
		public double heigth;

        public StructSize(double length, double depth, double heigth)
        {
            this.length = length;
            this.depth = depth;
            this.heigth = heigth;
        }
    }

}
