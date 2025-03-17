using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統
{
    internal class Order
    {
        public List<Item> items { get; set; } = new List<Item>();
        public void AddOrder(string discountType, Item item)
        {
            Item product = items.FirstOrDefault(x => x.Name == item.Name);
            if (product == null)
            {
                if (item.Number != 0)
                {
                    items.Add(item);
                }
                CalculateDiscount(discountType);
                return;
            }

            if (item.Number == 0)
            {
                items.Remove(product);
                CalculateDiscount(discountType);
                return;
            }

            product.Number = item.Number;
            CalculateDiscount(discountType);
        }

        public void CalculateDiscount(string discountType)
        {
            DisCount.DisCountOrder(discountType, items);
        }

        public int GetTotalMoney()
        {
            //int sum = 0;
            //foreach (Item item in items)
            //{
            //    sum += item.TotalPrice;
            //}
            //return sum;

            return DisCount.GetTotalMoney(items);
        }

        //public FlowLayoutPanel GetOrderDetail()
        //{
        //    return showPanel.CreateTXPanel(items);
        //}

        private (bool, Item) isContainItem(Item item)
        {
            foreach (Item item2 in items)
            {
                if (item2.Name == item.Name)
                {
                    return (true, item2);
                }
            }
            return (false, null);
        }


    }
}
