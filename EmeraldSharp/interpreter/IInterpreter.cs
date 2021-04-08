using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldSharp
{
    interface IInterpreter
    {
        String GetInterpreter(IComponent component);
    }
}
