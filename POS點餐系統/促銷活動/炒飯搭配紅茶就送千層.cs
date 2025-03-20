using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    internal class 炒飯搭配紅茶就送千層 : ADisCount
    {
        public 炒飯搭配紅茶就送千層(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item1 = items.FirstOrDefault(x => x.Name == "炒飯");
            Item item2 = items.FirstOrDefault(x => x.Name == "紅茶");
            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                string freeName = "(贈送)" + "千層";
                Item free = new Item(freeName, 0, set);
                items.Add(free);
            }
        }
    }
}
