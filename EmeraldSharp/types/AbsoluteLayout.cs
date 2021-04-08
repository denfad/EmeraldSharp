using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmeraldSharp
{
    class AbsoluteLayout : IType
    {
        public string StrType => "AbsoluteLayout";

        public void ChangeValue(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void FillPropertiesPanel(StackPanel panel)
        {
            throw new NotImplementedException();
        }

        public Control GetControl()
        {
            return new Button();
        }

        public string GetSwift(IComponent component)
        {
            throw new NotImplementedException();
        }

        public string GetXML(IComponent component)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"<{component.Type.StrType} \n" +
                "xmlns:android=\"http://schemas.android.com/apk/res/android\"\n" +
              "xmlns:tools=\"http://schemas.android.com/tools\"\n" +
              "android:layout_width=\"match_parent\" android:layout_height=\"match_parent\""+
              $"android:id=\"@+id/{component.GetProperty().Id}\"> \n");
            return builder.ToString();
        }
    }
}
