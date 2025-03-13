using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POS點餐系統
{
    internal class ShowPanel
    {
        public FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
        public ShowPanel()
        {
            flowLayoutPanel.Width = 400;
            flowLayoutPanel.Height = 780;
        }
        public void CreateTXPanel(List<Item> items)
        {
            flowLayoutPanel.Controls.Clear();
            Label title = new Label();
            title.Text = "點餐明細";
            flowLayoutPanel.Controls.Add(title);
            CreateDetailTitle();
            foreach (Item item in items)
            {
                CreateTXDetail(item);
            }
            //return flowLayoutPanel;
            FlowLayoutPanelEvent.Update(flowLayoutPanel);
        }
        private void CreateTXDetail(Item item)
        {
            FlowLayoutPanel details = new FlowLayoutPanel();
            details.Width = flowLayoutPanel.Width;
            details.Height = 30;
            Label label1 = new Label();
            label1.Width = 50;
            label1.Height = 30;
            label1.Text = item.Name;
            details.Controls.Add(label1);
            Label label2 = new Label();
            label2.Width = 50;
            label2.Height = 30;
            label2.Text = item.Price.ToString();
            details.Controls.Add(label2);
            Label label3 = new Label();
            label3.Width = 50;
            label3.Height = 30;
            label3.Text = item.Number.ToString();
            details.Controls.Add(label3);
            Label label4 = new Label();
            label4.Width = 50;
            label4.Height = 30;
            label4.Text = item.TotalPrice.ToString();
            details.Controls.Add(label4);
            flowLayoutPanel.Controls.Add(details);
        }

        private void CreateDetailTitle()
        {
            FlowLayoutPanel details = new FlowLayoutPanel();
            details.Width = flowLayoutPanel.Width;
            details.Height = 30;
            Label label1 = new Label();
            label1.Width = 50;
            label1.Height = 30;
            label1.Text = "品項";
            details.Controls.Add(label1);
            Label label2 = new Label();
            label2.Width = 50;
            label2.Height = 30;
            label2.Text = "單價";
            details.Controls.Add(label2);
            Label label3 = new Label();
            label3.Width = 50;
            label3.Height = 30;
            label3.Text = "數量";
            details.Controls.Add(label3);
            Label label4 = new Label();
            label4.Width = 50;
            label4.Height = 30;
            label4.Text = "小計";
            details.Controls.Add(label4);
            flowLayoutPanel.Controls.Add(details);
        }
    }
}
