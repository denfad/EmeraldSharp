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
    class HighLigther : ITool
    {

        private double StartX, StartY;
        private double EndX, EndY;
        private Rectangle HighlightRect;

     
        public void Clear(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
          
        }

        public void MouseMove(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
           /* if (((MouseEventArgs)e).LeftButton == MouseButtonState.Pressed)
            {
                EndX = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X;
            EndY = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y;
            HighlightRect.Height = Math.Abs(EndY - StartY);
            HighlightRect.Width = Math.Abs(EndX - StartX);
            foreach(IComponent c in shapesDao.Components) {
                if (isHighlight(c)) {
                    shapes.Add(c);
                    c.Select();
                }
                else {
                    shapes.Remove(c);
                    c.UnSelect();
                }
            }
            }*/
        }

        public void MousePressed(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
            /*StartX = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).X;
            StartY = ((MouseEventArgs)e).GetPosition(canvas.GetCanvas()).Y;
            HighlightRect = new Rectangle();
            Canvas.SetLeft(HighlightRect, StartX);
            Canvas.SetTop(HighlightRect, StartY);
            HighlightRect.Fill = null;
            HighlightRect.Stroke = Brushes.Blue;
            HighlightRect.StrokeThickness = 6;
            canvas.GetCanvas().Children.Add(HighlightRect);*/
            canvas.GetCanvas().EditingMode = InkCanvasEditingMode.Select;
           
        }

        public void MouseUp(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas)
        {
          /*  canvas.GetCanvas().Children.Remove(HighlightRect);
            canvas.AddTool(new Selector(shapes), e);*/
        }

     /*   private bool isHighlight(IComponent c)
        {
            *//*if (c.GetCompCenterX() > StartX & c.GetCompCenterX() < EndX & c.GetCompCenterY() > StartY & c.GetCompCenterY() < EndY)
            {
                return true;
            }
            return false;*//*
        }*/

    }


}
