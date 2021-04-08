using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace EmeraldSharp
{
    class ShapeDao
    {
        public List<IComponent> Components { get; set; } = new List<IComponent>();

        public ShapeDao(){
            
        }
        public ShapeDao(List<IComponent> components)
        {
            Components = components;
        }

        public IComponent GetComponent(int index)
        {
            return Components[index];
        }

        public void AddComponent(IComponent component)
        {
            Components.Add(component);
        }

        
    }
}
