using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetKitBox
{
    class ManagerStock
    {
		private List<Element> elements;

		public ManagerStock()
		{
			elements = new List<Element>(){ };
			//TODO : get the element data from the DB
			//Is elements is useful ? because it could be used by the GetStockMethod()
			//but we don't have the stock information in a element ...
		}

		public List<StructStock> GetStateStock()
		{

		}

		public List<StructOrderSupplier> GetBestSupplier()
		{

		}

		public static Element SearchElement(string type, string color, StructSize size)
		{

		}

		public static Element FindCorner(double heigth)
		{

		}
    }
}
