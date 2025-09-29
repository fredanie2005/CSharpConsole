using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class MapManager
    {
        private Dictionary<(int, int), Map> _maps = new Dictionary<(int, int), Map>();
        public (int X, int Y) _currentMapCoords { get; private set; }
        public Map _currentMap => _maps[_currentMapCoords];

        public void LoadMap(int x, int y)
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Maps");
            string fileName = Path.Combine(basePath, $"map_{x}_{y}.txt");
            fileName = Path.GetFullPath(fileName);

            System.Console.WriteLine(fileName);
            _maps[(x, y)] = new Map(fileName);
            _currentMapCoords = (x, y);
        }

        public void ChangeMap(int newX, int newY)
        {
            if (!_maps.ContainsKey((newX, newY)))
                LoadMap(newX, newY);
            _currentMapCoords = (newX, newY);
        }
    }

}
