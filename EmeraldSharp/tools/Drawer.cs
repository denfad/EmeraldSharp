using EmeraldSharp.types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmeraldSharp
{
    class Drawer : ITool
    {
        private double StartX, StartY;
        private IComponent DrawComponent;
        private ICanvas DrawCanvas;

        public Drawer(IComponent component, ICanvas canvas)
        {
            DrawComponent = component;
            DrawCanvas = canvas;
            canvas.GetCanvas().EditingMode = InkCanvasEditingMode.None;

        }
        public void Clear(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
           
        }

        public void MouseMove(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            if (((MouseEventArgs)e).LeftButton.HasFlag(MouseButtonState.Pressed))
            {
                foreach (IComponent c in shapes)
                {
                    Console.WriteLine(c.ToString());
                    c.Resize(Math.Abs(((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X - InkCanvas.GetLeft(c.GetElement())), Math.Abs(((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y - InkCanvas.GetTop(c.GetElement())));
                }

            }
        }

        public void MousePressed(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            canvas.GetCanvas().EditingMode = InkCanvasEditingMode.None;
            foreach (IComponent c in shapes)
            {
                c.UnSelect();
            }
            shapes.Clear();
            StartX = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X;
            StartY = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y;
            shapes.Add(DrawComponent);
            canvas.GetCanvas().Children.Add(DrawComponent.GetElement());
            DrawComponent.Drag(StartX, StartY);
        }

        public void MouseUp(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            
            foreach(IComponent c in shapes)
            {
                if (c.GetWidth() > 1 && c.GetHeight() > 1) shapesDao.AddComponent(c);
            }
            canvas.AddTool(new Selector(shapes,canvas), e);

        }
    }
}
