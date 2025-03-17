using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    internal class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Number { get; set; }
        public int Discount { get; set; }
        public int TotalPrice { get { return Price * Number - Discount; } }

        public Item(string name, int price, int num)
        {
            Name = name;
            Price = price;
            Number = num;
        }
    }
}
