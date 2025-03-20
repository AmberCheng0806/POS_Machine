using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統.促銷活動
{
    abstract class ADisCount
    {
        public List<Item> items { get; set; }

        public ADisCount(List<Item> items)
        {
            this.items = items;
        }


        public abstract void Discount();
    }
}
