using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    internal class 全場消費滿400元打8折 : ADisCount
    {
        public 全場消費滿400元打8折(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            int total = items.Sum(x => x.TotalPrice);
            if (total < 400)
            {
                return;
            }
            string discountName = "折抵";
            int discount = (int)(total * (1 - 0.8)) * (-1);
            items.Add(new Item(discountName, discount, 1));
        }
    }
}
