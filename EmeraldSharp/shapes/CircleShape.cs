using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EmeraldSharp.shapes
{
    internal class CircleShape : Shape, IShape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                EllipseGeometry g = new EllipseGeometry();
             
                
                Path myPath = new Path();
                myPath.Fill = Brushes.LemonChiffon;
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = Int32.MaxValue;
                myPath.Data = g;
                return g;
            }
        }


        public Shape GetShape()
        {
            throw new NotImplementedException();
        }

        public bool IsSelected()
        {
            throw new NotImplementedException();
        }

        public void Resize(double width, double height)
        {
            throw new NotImplementedException();
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public void UnSelect()
        {
            throw new NotImplementedException();
        }
    }
}
