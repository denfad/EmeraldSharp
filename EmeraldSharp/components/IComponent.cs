using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    interface IComponent
    {

        IType Type { get; set; }

        IShape Shape { get;set; }
        List<IComponent> Childes { get; set; }
        void Drag(double x, double y);

        void Translate(double dx, double dy);

        void Resize(double width, double height);

        double GetCompCenterX();

        double GetCompCenterY();

        double GetWidth();

        double GetHeight();

        Shape GetShape();

        Property GetProperty();

        UIElement GetElement();

        void AddType(IType type);
        void Select();

        void UnSelect();

        bool IsSelected();
    }
}
