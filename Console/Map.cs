using System;
using System.IO;

namespace Console
{
    class Map
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char[,] Tiles { get; private set; }

        public Map(string filePath)
        {
            LoadMap(filePath);
        }

        private void LoadMap(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            Height = lines.Length;
            Width = lines[0].Length;
            Tiles = new char[Height, Width];

            for (int y = 0; y < Height; y++)
            for (int x = 0; x < Width; x++)
                Tiles[y, x] = lines[y][x];
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    char tile = Tiles[y, x];
                    System.Console.BackgroundColor = tile switch
                    {
                        '#' => ConsoleColor.Magenta,
                        '.' => ConsoleColor.Cyan,
                        _ => ConsoleColor.Black
                    };
                    System.Console.Write("  ");
                }
                System.Console.ResetColor();
                System.Console.WriteLine();
            }
        }
    }
}