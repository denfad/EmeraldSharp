using EmeraldSharp.components;
using EmeraldSharp.shapes;
using EmeraldSharp.types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICanvas
    {
        private ShapeDao ShapesDao = new ShapeDao();
        private List<IComponent> SelectedShapes = new List<IComponent>();
        private ScaleTransform st = new ScaleTransform();
        private ITool Tool;
        private Board Board;
        public MainWindow()
        {
            
            InitializeComponent();
            canvas.EditingMode = InkCanvasEditingMode.None;
            canvas.MouseDown += new MouseButtonEventHandler(this.Canvas_MouseDown);
            canvas.MouseMove += new MouseEventHandler(this.Canvas_MouseMove);
            canvas.MouseUp += new MouseButtonEventHandler(this.Canvas_MouseUp);
            canvas.RenderTransform = st;

            SelectButton.Click += SelectButton_Click; 
            DrawButton.Click += DrawButton_Click;
            LightButton.Click += LightButton_Click;
            Pen.Click += PenButton_Click;
            Interprete.Click += InterpreteButton_Click;
            Tool = new Selector(this);
            

            Board = new Board((int)canvas.Height, (int)canvas.Width);
            MainComponent component2 = new MainComponent(new RectangleShape());
            
            component2.AddType(new AbsoluteLayout());
            this.Board.MainComponent = component2;
        }

        private void canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            Point PointMouseWheel = e.GetPosition(canvas);
            Thickness position = canvas.Margin;
            //формулу точную не выводил, но центр массштабирования теперь находится приблизительно там, где указатель мыши
            if (e.Delta > 0) { st.ScaleX *= 1.1; position.Left -= PointMouseWheel.X * 0.1 * st.ScaleX; position.Top -= PointMouseWheel.Y * 0.1 * st.ScaleY; }
            if (e.Delta < 0) { st.ScaleX /= 1.1; position.Left += PointMouseWheel.X * 0.1 * st.ScaleX; position.Top += PointMouseWheel.Y * 0.1 * st.ScaleY; }
            canvas.Margin = position;
            st.ScaleY = st.ScaleX;

        }

        private void InterpreteButton_Click(object sender, RoutedEventArgs e)
        {
            
            Console.WriteLine(Board.Interprete(new XMLInterpreter()));
           
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Admin\\Desktop\\Code.xml",true, System.Text.Encoding.Default))
            {
                sw.WriteLine(Board.Interprete(new XMLInterpreter()));
            }
        }
        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            canvas.EditingMode = InkCanvasEditingMode.Ink;
            Tool.Clear(e, SelectedShapes, ShapesDao, this);
            Tool = new EmeraldSharp.tools.Pen();

        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            Tool.Clear(e, SelectedShapes, ShapesDao, this);
            RectangleShape s = new RectangleShape();
            s.AllowDrop = true;
            s.Height = 20;
            s.Width = 20;
            s.Fill = Brushes.Black;

            MainComponent m = new MainComponent(s);
            m.AddType(new TextView());
           
            Board.MainComponent.Childes.Add(m);
            Tool = new Drawer(m, this);
        }

        private void LightButton_Click(object sender, RoutedEventArgs e)
        {
            Tool.Clear(e, SelectedShapes, ShapesDao, this);
            canvas.EditingMode = InkCanvasEditingMode.Select;
            Tool = new HighLigther();
          
          
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            Tool.Clear(e, SelectedShapes, ShapesDao, this);
            Tool = new Selector(this);
        }

        internal void AddTool(ITool tool, MouseButtonEventArgs e)
        {
            this.Tool.Clear(e, SelectedShapes, ShapesDao, this);
            this.Tool = tool;
        }

        public void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tool.MousePressed(e, SelectedShapes, ShapesDao, this);
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Tool.MouseMove(e, SelectedShapes, ShapesDao, this);
        }

        public void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Tool.MouseUp(e, SelectedShapes, ShapesDao, this);
        }

        public InkCanvas GetCanvas()
        {
       
            return this.canvas;
        }

        void ICanvas.AddTool(ITool tool, RoutedEventArgs e)
        {
            Tool.Clear(e, SelectedShapes, ShapesDao, this);
            Tool = tool;
        }

        public StackPanel GetPanel()
        {
            return PropertiesPanel;
        }
    }
}
