using System;
using System.IO;

namespace Console
{
    class Map
    {
        public int _width { get; private set; }
        public int _height { get; private set; }
        public char[,] _tiles { get; private set; }

        public Map(string filePath)
        {
            LoadMap(filePath);
        }

        private void LoadMap(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            _height = lines.Length;
            _width = lines[0].Length;
            _tiles = new char[_height, _width];
            for (int y = 0; y < _height; y++)
                for (int x = 0; x < _width; x++)
                    _tiles[y, x] = lines[y][x];
        }

        public void Draw()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    char tile = _tiles[y, x];

                    switch (tile)
                    {
                        case '#':
                            System.Console.BackgroundColor = ConsoleColor.Magenta;
                            break;
                        case '.':
                            System.Console.BackgroundColor = ConsoleColor.Cyan;
                            break;
                        default:
                            System.Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }

                    System.Console.Write("  ");
                }

                System.Console.ResetColor();
                System.Console.WriteLine();
            }
        }
    }
}
