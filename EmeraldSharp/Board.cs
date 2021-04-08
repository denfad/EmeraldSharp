using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmeraldSharp
{
    class Board
    {
        public IComponent MainComponent { get; set; }
        int ScaleX { get; set; }
        int ScaleY { get; set; }
        public Board(int ScaleX, int ScaleY)
        {
            this.ScaleX = ScaleX;
            this.ScaleY = ScaleY;
        }

        public String Interprete(IInterpreter interpreter)
        {
            return interpreter.GetInterpreter(MainComponent);
        }
    }
}
