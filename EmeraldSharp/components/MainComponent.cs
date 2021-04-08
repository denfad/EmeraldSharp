using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace EmeraldSharp.components
{
    internal class MainComponent :  Grid, IComponent
    {
        public IType Type { get; set; }
        public List<IComponent> Childes { get ; set ; }
        public IShape Shape { get; set; }

        public MainComponent(IShape shape)
        {
            Shape = shape;
            this.Children.Add(Shape.GetShape());
            Childes = new List<IComponent>();
            this.Background = null;
        }

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

        public Property GetProperty()
        {
            Property p = new Property();
            p.height = (int)this.Height;
            p.width = (int)this.Width;
            p.absoluteX = (int)InkCanvas.GetLeft(this);
            p.absoluteY = (int)InkCanvas.GetTop(this);
            return p;
        }

        public Shape GetShape()
        {
            return Shape.GetShape();
        }

        public double GetWidth()
        {
            return this.Width;
        }

        public bool IsSelected()
        {
            return Shape.IsSelected();
        }

        public void Resize(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            Shape.Resize(width, height);
            
        }

        public void Select()
        {
            Shape.Select();
        }

        public void Translate(double dx, double dy)
        {
            InkCanvas.SetLeft(this, InkCanvas.GetLeft(this) + dx);
            InkCanvas.SetTop(this, InkCanvas.GetTop(this) + dy);
        }

        public void UnSelect()
        {
            Shape.UnSelect();

        }

        public UIElement GetElement()
        {
            return this;
        }

        public void AddType(IType type)
        {
            Type = type;
            Control c = type.GetControl();
            Panel.SetZIndex(c, 1000);
            this.Children.Add(c);
        }
    }
}
