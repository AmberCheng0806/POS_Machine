using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    internal class 全場消費滿300元折扣50元 : ADisCount
    {
        public 全場消費滿300元折扣50元(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            int total = items.Sum(x => x.TotalPrice);
            int set = total / 300;
            if (set == 0)
            {
                return;
            }
            string discountName = "折抵";
            int discount = 50 * (-1);
            items.Add(new Item(discountName, discount, set));
        }
    }
}
