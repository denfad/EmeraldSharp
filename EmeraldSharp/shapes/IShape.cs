using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    interface IShape
    {
        void Resize(double width, double height);
        void Select();

        void UnSelect();

        bool IsSelected();

        Shape GetShape();
    }
}
