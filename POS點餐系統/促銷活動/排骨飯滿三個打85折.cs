using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POS點餐系統.促銷活動
{
    internal class 排骨飯滿三個打85折 : ADisCount
    {
        public 排骨飯滿三個打85折(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.Name == "排骨飯" && x.Number / 3 > 0);
            if (item != null)
            {
                int set = item.Number / 3;
                string discountName = "折抵";
                int discount = (int)(item.Price * (1.0 - 0.85) * 3) * (-1);
                items.Add(new Item(discountName, discount, set));
            }
        }
    }
}
