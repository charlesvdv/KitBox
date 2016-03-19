using System;

namespace ProjetKitBox
{
    public struct StructElemCommand
    {
        public string codeElement;
        public int numOrdered;
        public int stock;
        public double price;

        public StructElemCommand(string c, int n, int s, double p)
        {
            this.codeElement = c;
            this.numOrdered = n;
            this.stock = s;
            this.price = p;
        }
    }


    public struct StructInfoOrder
    {
        public double price;
        public int IDClient;
        public int coupeSup;
        public bool retire;

        public StructInfoOrder(int IDC, double price, int coupeSup, bool retire)
        {
            IDClient = IDC;
            this.price = price;
            this.coupeSup = coupeSup;
            this.retire = retire;
        }
    }

}

