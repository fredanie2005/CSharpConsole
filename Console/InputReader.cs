using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    static class InputReader
    {
        public static (int dx, int dy) GetMovement(ConsoleKey key)
        {
            return key switch
            {
                ConsoleKey.UpArrow => (0, -1),
                ConsoleKey.DownArrow => (0, 1),
                ConsoleKey.LeftArrow => (-1, 0),
                ConsoleKey.RightArrow => (1, 0),
                _ => (0, 0)
            };
        }
    }

}
