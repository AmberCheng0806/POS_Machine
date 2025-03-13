using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐系統
{
    public static class FlowLayoutPanelEvent
    {
        public static EventHandler<FlowLayoutPanel> EventHandler;
        public static void Update(FlowLayoutPanel flowLayoutPanel)
        {
            EventHandler.Invoke(null, flowLayoutPanel);
        }
    }
}
