using System;
using System.Collections.Generic;
using System.IO;

namespace Console
{
    class MapManager
    {
        private readonly Dictionary<(int X, int Y), Map> _maps = new();
        public (int X, int Y) CurrentMapCoords { get; private set; }
        public Map CurrentMap => _maps[CurrentMapCoords];

        public void LoadMap(int x, int y)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Maps");
            string fileName = Path.Combine(basePath, $"map_{x}_{y}.txt");
            fileName = Path.GetFullPath(fileName);

            System.Console.WriteLine(fileName); // Pour debug
            _maps[(x, y)] = new Map(fileName);
            CurrentMapCoords = (x, y);
        }

        public void ChangeMap(int x, int y)
        {
            if (!_maps.ContainsKey((x, y)))
                LoadMap(x, y);

            CurrentMapCoords = (x, y);
        }
    }
}