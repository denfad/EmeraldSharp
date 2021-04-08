using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldSharp
{
    class Property
    {
        public String Id { get; set; }
        public IType Type { get; set; }
        public int absoluteX { get; set; }
        public int absoluteY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Property()
        {

        }

    }
}
