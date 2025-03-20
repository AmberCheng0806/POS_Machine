using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    internal class 雞腿飯買二送一 : ADisCount
    {
        public 雞腿飯買二送一(List<Item> items) : base(items)
        {
        }

        public override void Discount()
        {
            Item item = items.FirstOrDefault(x => x.Name == "雞腿飯" && x.Number / 2 > 0);
            if (item != null)
            {
                int set = item.Number / 2;
                string freeName = "(贈送)" + item.Name;
                Item free = new Item(freeName, 0, set * 1);
                items.Add(free);
            }
        }
    }
}
