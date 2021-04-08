using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    class Selector : ITool
    {
        private double LastX, LastY;
        private List<UIElement> SelectedUi = new List<UIElement>();

        public Selector(ICanvas canvas) {
            canvas.GetCanvas().EditingMode = InkCanvasEditingMode.None;
        }
        public Selector(List<IComponent> components, ICanvas canvas)
        {
            foreach (IComponent c in components)
            {
                c.Select();
                SelectedUi.Add(c.GetElement());
            }
        }
        public void Clear(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            foreach(IComponent selectedShape in shapes)
            {
                selectedShape.UnSelect();
            }
            shapes.Clear();
        }


        public void MouseMove(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            if (((MouseEventArgs)e).LeftButton == MouseButtonState.Pressed) {
                double newX = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X;
                double newY = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y;
                double dx = newX - LastX;
                double dy = newY - LastY;
                foreach (IComponent selectedShape in shapes) {
                    selectedShape.Translate(dx, dy);
                    Console.WriteLine($"select {selectedShape.GetShape().ToString()}");
                }
                LastX = newX;
                LastY = newY;
            }
          
        }

        public void MousePressed(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            canvas.GetCanvas().EditingMode = InkCanvasEditingMode.None;
            LastX = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X;
            LastY = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y;
            Console.WriteLine("Pressed");
            foreach(IComponent component in SelectedUi)
            {
                shapes.Add(component);
            }
            SelectedUi.Clear();
            if (e.Source is IComponent && Keyboard.IsKeyDown(Key.LeftShift))
            {
                Console.WriteLine("Shift");
                IComponent shape = (IComponent)e.Source;
                shape.Select();
                shapes.Add(shape);
                
            }
            else if (e.Source is IComponent)
            {
                Console.WriteLine("Nome");
                SelectedUi.Clear();
                Clear(e, shapes, shapesDao, canvas);
                IComponent shape = (IComponent)e.Source;
                shape.Select();
                shapes.Add(shape);
                

            }
            else
            {
                Console.WriteLine("Clear");
                Clear(e,shapes,shapesDao,canvas);
            }
            //if (canvas.GetCanvas().EditingMode != InkCanvasEditingMode.Select) canvas.GetCanvas().EditingMode = InkCanvasEditingMode.Select;
            Console.WriteLine("press");

            try
            {
                IComponent component = shapes[0];
                if(component != null)
                {
                    Console.WriteLine(component.ToString());
                    component.Type.FillPropertiesPanel(canvas.GetPanel());
                    Console.WriteLine("fill");
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }

        public void MouseUp(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
           
        }
    }
}
