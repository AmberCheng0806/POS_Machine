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
            //雞腿飯買二送一
            //排骨飯三個200元
            //咖哩飯搭紅茶80元
            //啤酒三瓶60
            //滷肉飯搭布丁100元
            //炒飯搭配紅茶就送千層
            //咖哩飯滿兩個就送5個可頌
            //排骨飯滿三個打85折
            //雞腿飯搭配搭配巴斯克打九折
            //全場消費滿300元折扣50元
            //全場消費滿400元打8折

            ShowPanel showPanel = new ShowPanel();
            showPanel.CreateTXPanel(items);

        }
    }
}
