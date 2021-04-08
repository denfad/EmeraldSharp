using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EmeraldSharp.shapes
{
    internal class RectangleShape : Shape, IShape
    {
        private bool IsSelect = false;
        protected override Geometry DefiningGeometry
        {
            get
            {

                RectangleGeometry g = new RectangleGeometry();
                g.Rect = new Rect(new Size(Width, Height));
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
            return this;
        }

        public bool IsSelected()
        {
            return IsSelect;
        }

        public void Resize(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Select()
        {
            IsSelect = true;
            this.Stroke = Brushes.Red;
            this.StrokeThickness = 6;
        }

        public void UnSelect()
        {
            IsSelect = true;
            this.Stroke = null;
        }
    }
}
