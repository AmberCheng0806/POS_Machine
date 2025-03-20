using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    internal class 咖哩飯搭紅茶80元 : ADisCount
    {
        public 咖哩飯搭紅茶80元(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item1 = items.FirstOrDefault(x => x.Name == "咖哩飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "紅茶");
            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                string discountName = "折抵";
                int discount = (item1.Price + item2.Price - 80) * (-1);
                items.Add(new Item(discountName, discount, set));
            }
        }
    }
}
