using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmeraldSharp
{
    interface IType
    {
        String StrType { get;}
     
        String GetXML(IComponent component);
        String GetSwift(IComponent component);

        Control GetControl();


        void FillPropertiesPanel(StackPanel panel);

        void ChangeValue(string name, object value);
    }
}
