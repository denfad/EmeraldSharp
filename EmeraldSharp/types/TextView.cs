using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EmeraldSharp.types
{
    internal class TextView : TextBox, IType
    {
       

        public string StrType => "TextView";


        public TextView() {
            FontSize = 14;
            Text = "Text";
            IsEnabled = false;
        }
        public string GetSwift(IComponent component)
        {
            throw new NotImplementedException();
        }

        public string GetXML(IComponent component)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<{component.Type.StrType} \n" +
               $"android:id=\"@+id/{component.GetProperty().Id}\" \n" +
               $"android:layout_x=\"{(int)component.GetProperty().absoluteX}dp\"\n" +
               $"android:layout_y=\"{(int)component.GetProperty().absoluteY}dp\"\n");
            builder.Append($"android:layout_width =\"{(int)component.GetWidth()}dp\"\n");
            builder.Append($"android:layout_height =\"{(int)component.GetHeight()}dp\"\n");
            builder.Append($"android:text = \"{Text}\"\n");
            builder.Append($"android:textSize = \"{FontSize}sp\">");

            return builder.ToString();
        }

        public void FillPropertiesPanel(StackPanel panel)
        {
            panel.Children.Clear();
            panel.Children.Add(new MyStackPanel(new MyTextBox((Int32)FontSize,this, "FontSize"),"Размер шрифта", Orientation.Horizontal));
           

        }

        public Control GetControl()
        {
            this.Text = "AAAAAAAAAA";
            this.Foreground = Brushes.White;
            this.Background = null;
            TextAlignment = System.Windows.TextAlignment.Center;
            VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            return this;
        }

        public void ChangeValue(string name, object value)

        {
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
       | BindingFlags.Static;
            this.GetType().GetField(name,bindFlags).SetValue(this, value);
        }
    }
}
