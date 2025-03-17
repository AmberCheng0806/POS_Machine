using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    internal class DisCount
    {

        public static void DisCountOrder(string discountType, List<Item> items)
        {

            items.RemoveAll(x => x.Name.Contains("贈送") || x.Name.Contains("折抵"));
            items.ForEach(x => x.Discount = 0);
            //雞腿飯買二送一
            //排骨飯三個200元
            //咖哩飯搭紅茶80元
            //啤酒三瓶60
            //滷肉飯搭布丁100元
            //炒飯搭配紅茶就送千層
            //咖哩飯滿兩個就送5個可頌
            //排骨飯滿三個打85折
            //雞腿飯搭配巴斯克打九折
            //全場消費滿300元折扣50元
            //全場消費滿400元打8折
            switch (discountType)
            {
                case "雞腿飯買二送一":
                    GetFreeForSingleItem("雞腿飯", "雞腿飯", items, 2, 1);
                    break;
                case "排骨飯三個200元":
                    SalePriceForSingleItem("排骨飯", items, 3, 200);
                    break;
                case "咖哩飯搭紅茶80元":
                    SalePriceForPairingItems("咖哩飯", "紅茶", items, 80);
                    break;
                case "啤酒三瓶60":
                    SalePriceForSingleItem("啤酒", items, 3, 60);
                    break;
                case "滷肉飯搭布丁100元":
                    SalePriceForPairingItems("滷肉飯", "布丁", items, 100);
                    break;
                case "炒飯搭配紅茶就送千層":
                    GetFreeForPairingItems("炒飯", "紅茶", "千層", items);
                    break;
                case "咖哩飯滿兩個就送5個可頌":
                    GetFreeForSingleItem("咖哩飯", "可頌", items, 2, 5);
                    break;
                case "排骨飯滿三個打85折":
                    PercentageSalePriceForSingleItem("排骨飯", items, 3, 0.85);
                    break;
                case "雞腿飯搭配巴斯克打九折":
                    PercentageSalePriceForPairingItems("雞腿飯", "巴斯克", items, 0.9);
                    break;
                case "全場消費滿300元折扣50元":
                    DiscountForTotalPrice(items, 300, 50);
                    break;
                case "全場消費滿400元打8折":
                    PercentageDiscountForTotalPrice(items, 400, 0.8);
                    break;
            }

            ShowPanel showPanel = new ShowPanel();
            showPanel.CreateTXPanel(items);

        }

        private static Item FindItemInList(string name, List<Item> items)
        {
            return items.FirstOrDefault(x => x.Name == name);
        }

        /// <summary>
        /// 單品項滿幾個就免費送某品項
        /// </summary>
        /// <param name="name"></param>
        /// <param name="freeItem"></param>
        /// <param name="items"></param>
        /// <param name="mixNum"></param>
        /// <param name="freeNum"></param>
        private static void GetFreeForSingleItem(string name, string freeItem, List<Item> items, int mixNum, int freeNum)
        {

            Item item = FindItemInList(name, items);
            if (item == null)
            {
                return;
            }
            int set = item.Number / mixNum;
            if (set == 0)
            {
                return;
            }
            string freeName = "(贈送)" + freeItem;
            Item free = new Item(freeName, 0, set * freeNum);
            items.Add(free);




            //Item free = FindItemInList(freeItem, items);
            //if (item != null)
            //{
            //    int set = item.Number / mixNum;
            //    if (set == 0)
            //    {
            //        return;
            //    }
            //    if (free == null)
            //    {
            //        free = new Item(freeItem, 0, 0);
            //        items.Add(free);
            //    }
            //    int TotalFreeNum = set * freeNum;
            //    free.Number += TotalFreeNum;
            //    free.Discount = TotalFreeNum * free.Price;
            //}
        }

        /// <summary>
        /// 單品項滿幾個就有優惠價
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        /// <param name="number"></param>
        /// <param name="salePrice"></param>
        private static void SalePriceForSingleItem(string name, List<Item> items, int number, int salePrice)
        {
            Item item = FindItemInList(name, items);
            if (item != null)
            {
                int set = item.Number / number;
                if (set == 0)
                {
                    return;
                }
                string discountName = "折抵";
                int discount = (item.Price * number - salePrice) * (-1);
                items.Add(new Item(discountName, discount, set));

                //item.Discount = set * (item.Price * number - salePrice);
            }
        }

        /// <summary>
        /// 單品項滿幾個就打折
        /// </summary>
        /// <param name="name"></param>
        /// <param name="items"></param>
        /// <param name="number"></param>
        /// <param name="percentage"></param>
        private static void PercentageSalePriceForSingleItem(string name, List<Item> items, int number, double percentage)
        {
            Item item = FindItemInList(name, items);
            if (item != null)
            {
                int set = item.Number / number;
                item.Discount = (int)(item.Price * (1.0 - percentage) * set * number);
            }
        }

        /// <summary>
        /// 組合品項有打折
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="items"></param>
        /// <param name="percentage"></param>
        private static void PercentageSalePriceForPairingItems(string name1, string name2, List<Item> items, double percentage)
        {
            Item item1 = FindItemInList(name1, items);
            Item item2 = FindItemInList(name2, items);
            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                item1.Discount = (int)(item1.Price * (1 - percentage) * set);
                item2.Discount = (int)(item2.Price * (1 - percentage) * set);
            }
        }


        /// <summary>
        /// 組合品項有優惠價
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="items"></param>
        /// <param name="salePrice"></param>
        private static void SalePriceForPairingItems(string name1, string name2, List<Item> items, int salePrice)
        {
            Item item1 = FindItemInList(name1, items);
            Item item2 = FindItemInList(name2, items);
            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                string discountName = "折抵";
                int discount = (item1.Price + item2.Price - salePrice) * (-1);
                items.Add(new Item(discountName, discount, set));


                //item2.Discount = set * (item1.Price + item2.Price - salePrice);
            }
        }

        /// <summary>
        /// 組合品項有送東西
        /// </summary>
        /// <param name="name1"></param>
        /// <param name="name2"></param>
        /// <param name="freeItem"></param>
        /// <param name="items"></param>
        private static void GetFreeForPairingItems(string name1, string name2, string freeItem, List<Item> items)
        {
            Item item1 = FindItemInList(name1, items);
            Item item2 = FindItemInList(name2, items);

            if (item1 != null && item2 != null)
            {
                int set = Math.Min(item1.Number, item2.Number);
                string freeName = "(贈送)" + freeItem;
                Item free = new Item(freeName, 0, set);
                items.Add(free);


                //if (free == null)
                //{
                //    free = new Item(freeItem, 0, 0);
                //    items.Add(free);
                //}

                //free.Number += set;
                //free.Discount = set * free.Price;
            }
        }

        /// <summary>
        /// 滿額有折扣
        /// </summary>
        /// <param name="items"></param>
        /// <param name="threshold"></param>
        /// <param name="discount"></param>
        private static void DiscountForTotalPrice(List<Item> items, int threshold, int discountPrice)
        {
            int total = GetTotalMoney(items);
            int set = total / threshold;
            if (set == 0)
            {
                return;
            }
            string discountName = "折抵";
            int discount = discountPrice * (-1);
            items.Add(new Item(discountName, discount, set));


            //items.Last().Discount = set * discountPrice;
        }

        /// <summary>
        /// 滿額有打折
        /// </summary>
        /// <param name="items"></param>
        /// <param name="threshold"></param>
        /// <param name="percentage"></param>
        private static void PercentageDiscountForTotalPrice(List<Item> items, int threshold, double percentage)
        {
            int total = GetTotalMoney(items);
            if (total > threshold)
            {
                items.ForEach(x => x.Discount = (int)(x.Price * (1.0 - percentage)));
            }
        }

        public static int GetTotalMoney(List<Item> items)
        {
            int sum = 0;
            foreach (Item item in items)
            {
                sum += item.TotalPrice;
            }
            return sum;
        }
    }
}
