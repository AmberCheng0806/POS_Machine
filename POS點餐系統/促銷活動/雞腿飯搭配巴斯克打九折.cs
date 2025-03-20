using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POS點餐系統.促銷活動
{
    internal class 雞腿飯搭配巴斯克打九折 : ADisCount
    {
        public 雞腿飯搭配巴斯克打九折(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item1 = items.FirstOrDefault(x => x.Name == "雞腿飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "巴斯克");
            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                string discountName = "折抵";
                int discount = (int)((item1.Price + item2.Price) * (1 - 0.9)) * (-1);
                items.Add(new Item(discountName, discount, set));
            }
        }
    }
}
