using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POS點餐系統.促銷活動
{
    internal class 咖哩飯滿兩個就送5個可頌 : ADisCount
    {
        public 咖哩飯滿兩個就送5個可頌(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.Name == "咖哩飯" && x.Number / 2 > 0);
            if (item == null)
            {
                return;
            }
            int set = item.Number / 2;
            string freeName = "(贈送)" + "可頌";
            Item free = new Item(freeName, 0, set * 5);
            items.Add(free);
        }
    }
}
