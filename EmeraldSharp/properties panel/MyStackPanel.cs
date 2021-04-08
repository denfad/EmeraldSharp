using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmeraldSharp
{
    public class MyStackPanel:StackPanel
    {
        Control Control;
        public MyStackPanel(Control control, String label, Orientation orientation )
        {
            base.Orientation = orientation;
            Control = control;
            Label labelC = new Label();
            labelC.Content = label;
            labelC.FontSize = 14;
            base.Children.Add(labelC);
            base.Children.Add(control);
        }
    }
}
