using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統
{
    public partial class Form1 : Form
    {
        private Order order;
        public Form1()
        {
            InitializeComponent();
            order = new Order();
        }

        string[] mainFoods = { "雞腿飯$80", "排骨飯$75", "咖哩飯$65", "滷肉飯$70", "炒飯$60" };
        string[] sideFoods = { "餐包$20", "吐司$15", "可頌$25" };
        string[] drink = { "雪碧$15", "氣泡水$10", "啤酒$30", "紅茶$20" };
        string[] dessert = { "巴斯克$60", "千層$70", "蛋塔$50", "布丁$40" };

        private void Checkout_Click(object sender, EventArgs e)
        {
            totalLab.Text = order.GetTotalMoney().ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.CreateCheckBoxes(mainFoods, Checkbox_CheckChanged, Numeric_ValueChanged);
            flowLayoutPanel2.CreateCheckBoxes(sideFoods, Checkbox_CheckChanged, Numeric_ValueChanged);
            flowLayoutPanel3.CreateCheckBoxes(drink, Checkbox_CheckChanged, Numeric_ValueChanged);
            flowLayoutPanel4.CreateCheckBoxes(dessert, Checkbox_CheckChanged, Numeric_ValueChanged);
            FlowLayoutPanelEvent.EventHandler += UpdateTXPanel;
            comboBox1.SelectedIndex = 0;
        }

        public void Checkbox_CheckChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown numericUpDown = (NumericUpDown)checkBox.Tag;
            numericUpDown.Value = checkBox.Checked ? 1 : 0;

            string name = checkBox.Text.Split('$')[0];
            int price = int.Parse(checkBox.Text.Split('$')[1]);
            int num = (int)numericUpDown.Value;
            order.AddOrder(comboBox1.Text, new Item(name, price, num));

            //panel2.Controls.Clear();
            //panel2.Controls.Add(order.GetOrderDetail());



        }

        public void UpdateTXPanel(object sender, FlowLayoutPanel flowLayoutPanel)
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(flowLayoutPanel);
        }

        public void Numeric_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)numericUpDown.Tag;
            checkBox.Checked = numericUpDown.Value != 0 ? true : false;

            string name = checkBox.Text.Split('$')[0];
            int price = int.Parse(checkBox.Text.Split('$')[1]);
            int num = (int)numericUpDown.Value;
            order.AddOrder(comboBox1.Text, new Item(name, price, num));

            //panel2.Controls.Clear();
            //panel2.Controls.Add(order.GetOrderDetail());

        }
    }
}
