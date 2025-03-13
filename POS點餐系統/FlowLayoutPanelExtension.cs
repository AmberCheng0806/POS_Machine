using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統
{
    /// <summary>
    /// 自動生成checkbox
    /// </summary>
    internal static class FlowLayoutPanelExtension
    {
        public static void CreateCheckBoxes(this FlowLayoutPanel flowLayoutPanel, string[] items, EventHandler checkChanged, EventHandler valueChaged)
        {
            for (int i = 0; i < items.Length; i++)
            {
                FlowLayoutPanel flowLayout = new FlowLayoutPanel();
                flowLayout.Height = 30;
                CheckBox box = new CheckBox();
                box.CheckedChanged += checkChanged;
                NumericUpDown numericUpDown = new NumericUpDown();
                box.Tag = numericUpDown;
                numericUpDown.Tag = box;
                numericUpDown.ValueChanged += valueChaged;
                numericUpDown.Width = 50;
                box.Text = items[i];
                flowLayoutPanel.Controls.Add(flowLayout);
                flowLayout.Controls.Add(box);
                flowLayout.Controls.Add(numericUpDown);
            }
        }


        /// <summary>
        /// 計算單一FlowLayoutPanel中的價錢
        /// </summary>
        /// <returns></returns>
        public static int GetSumPerPanel(this FlowLayoutPanel flowLayoutPanel)
        {
            int sum = 0;
            int number = flowLayoutPanel.Controls.Count;
            for (int i = 0; i < number; i++)
            {
                FlowLayoutPanel panel = (FlowLayoutPanel)flowLayoutPanel.Controls[i];
                CheckBox box = (CheckBox)panel.Controls[0];
                NumericUpDown numericUpDown = (NumericUpDown)panel.Controls[1];
                int value = (int)numericUpDown.Value;
                if (box.Checked)
                {
                    sum += int.Parse(box.Text.Split('$')[1]) * value;
                }
            }
            return sum;
        }
    }
}
