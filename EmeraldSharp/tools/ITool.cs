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
    interface ITool
    {
        void MouseMove(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas);

        void MousePressed(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas);

        void MouseUp(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas);

        void Clear(RoutedEventArgs e, List<IComponent> shapes, ShapeDao shapesDao, ICanvas canvas);
        } 
}