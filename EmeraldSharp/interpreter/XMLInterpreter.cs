using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldSharp
{
    class XMLInterpreter : IInterpreter
    {
        public string GetInterpreter(IComponent component)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(component.Type.GetXML(component));
            foreach(IComponent c in component.Childes)
            {
                builder.Append(this.GetInterpreter(c));
            }
            builder.Append("</" + component.Type.StrType + ">\n");
            return builder.ToString();
        }
    }
}
