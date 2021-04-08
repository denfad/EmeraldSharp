using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    internal class RectangleComponent : Shape
    {
        private bool IsSelect = false;

        public string Id { get; set; }
        public IType Type { get; set; }
      
        public List<IComponent> Childes { get; set; } = new List<IComponent>();

        public RectangleComponent()
        {
            

        }

        protected override Geometry DefiningGeometry {
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

        public IShape Shape { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Drag(double x, double y)
        {
            InkCanvas.SetLeft(this, x);
            InkCanvas.SetTop(this, y);
       
        }

        public double GetCompCenterX()
        {
            return InkCanvas.GetLeft(this) + this.Width / 2;
        }

        public double GetCompCenterY()
        {
            return InkCanvas.GetTop(this) + this.Height / 2;
        }

        public double GetHeight()
        {
            return this.Height;
        }

        public Shape GetShape()
        {
            return this;
        }

        public double GetWidth()
        {
            return this.Width;
        }

        public bool IsSelected()
        {
            return IsSelect;
        }

        public void Resize(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
       
        }

        public void Select()
        {
            IsSelect = true;
            this.Stroke = Brushes.Red;
            this.StrokeThickness = 6;
          
        }

        public void Translate(double dx, double dy)
        {
          
            InkCanvas.SetLeft(this, InkCanvas.GetLeft(this) + dx);
            InkCanvas.SetTop(this, InkCanvas.GetTop(this) + dy);
        }

        public void UnSelect()
        {
            IsSelect = true;
            this.Stroke = null;
            
        }

        public Property GetProperty()
        {
            Property p = new Property();
            p.height = (int)this.Height;
            p.width = (int)this.Width;
            p.absoluteX = (int)InkCanvas.GetLeft(this);
            p.absoluteY = (int)InkCanvas.GetTop(this);
            return p;


        }

  
    }
}
