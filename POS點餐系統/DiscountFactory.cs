using POS點餐系統.促銷活動;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐系統
{
    internal class DiscountFactory
    {
        public static ADisCount SelectDiscount(string discountType, List<Item> items)
        {
            ADisCount aDisCount = null;
            switch (discountType)
            {
                case "雞腿飯買二送一":
                    aDisCount = new 雞腿飯買二送一(items);
                    break;
                case "排骨飯三個200元":
                    aDisCount = new 排骨飯三個200元(items);
                    break;
                case "咖哩飯搭紅茶80元":
                    aDisCount = new 咖哩飯搭紅茶80元(items);
                    break;
                case "啤酒三瓶60":
                    aDisCount = new 啤酒三瓶60(items);
                    break;
                case "滷肉飯搭布丁100元":
                    aDisCount = new 滷肉飯搭布丁100元(items);
                    break;
                case "炒飯搭配紅茶就送千層":
                    aDisCount = new 炒飯搭配紅茶就送千層(items);
                    break;
                case "咖哩飯滿兩個就送5個可頌":
                    aDisCount = new 咖哩飯滿兩個就送5個可頌(items);
                    break;
                case "排骨飯滿三個打85折":
                    aDisCount = new 排骨飯滿三個打85折(items);
                    break;
                case "雞腿飯搭配巴斯克打九折":
                    aDisCount = new 雞腿飯搭配巴斯克打九折(items);
                    break;
                case "全場消費滿300元折扣50元":
                    aDisCount = new 全場消費滿300元折扣50元(items);
                    break;
                case "全場消費滿400元打8折":
                    aDisCount = new 全場消費滿400元打8折(items);
                    break;
            }
            return aDisCount;
        }
    }
}
