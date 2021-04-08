using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmeraldSharp
{
    class MyTextBox:TextBox
    {
        Int32 Value;
        IType Type { get; set; }
        string MyName;

        public MyTextBox(Int32 value,IType type,string name)
        {
            Value = value;
            Type = type;
            MyName = name;
            base.Text = Value.ToString();
            base.TextAlignment = System.Windows.TextAlignment.Center;
            base.VerticalContentAlignment = System.Windows.VerticalAlignment.Stretch;
            base.Width = Double.NaN;      
            base.MinWidth = 80;
            
           
          
           
        }
       
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            try {
                Value = Int32.Parse(base.Text);
                this.Type.ChangeValue(MyName,Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }           
        }
    }
}
