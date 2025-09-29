using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console;
using PlayerSpace;

namespace Console.GameState
{
    class AdventureState : IGameState
    {
        private MapManager _mapManager;
        private Player _player;

        public void Init()
        {
            _mapManager = new MapManager();
            _mapManager.LoadMap(1, 1);
            _player = new Player(1, 1);
            Draw();
        }

        public void Update()
        {
            ConsoleKey key = System.Console.ReadKey(true).Key;
            var (dx, dy) = InputReader.GetMovement(key);

            int _newX = _player._x + dx;
            int _newY = _player._y + dy;

            if (_newX >= 0 && _newX < _mapManager._currentMap._width &&
                _newY >= 0 && _newY < _mapManager._currentMap._height)
            {
                if (_mapManager._currentMap._tiles[_newY, _newX] != '#')
                {
                    _player._x = _newX;
                    _player._y = _newY;
                }
            }

            if (_player._x == 0)
            {
                _mapManager.ChangeMap(_mapManager._currentMapCoords.X - 1, _mapManager._currentMapCoords.Y);
                _player._x = _mapManager._currentMap._width - 2;
            }
            if (_player._x == _mapManager._currentMap._width - 1)
            {
                _mapManager.ChangeMap(_mapManager._currentMapCoords.X + 1, _mapManager._currentMapCoords.Y);
                _player._x = 1;
            }
            if (_player._y == 0)
            {
                _mapManager.ChangeMap(_mapManager._currentMapCoords.X, _mapManager._currentMapCoords.Y + 1);
                _player._y = _mapManager._currentMap._height - 2;
            }
            if (_player._y == _mapManager._currentMap._height - 1)
            {
                _mapManager.ChangeMap(_mapManager._currentMapCoords.X, _mapManager._currentMapCoords.Y - 1);
                _player._y = 1;
            }
        }

        public void Draw()
        {
            System.Console.Clear();
            _mapManager._currentMap.Draw();
            System.Console.SetCursorPosition(_player._x * 2, _player._y);
            System.Console.BackgroundColor = ConsoleColor.Yellow;
            System.Console.Write("  ");
            System.Console.ResetColor();

        }

        public void Exit()
        {
            // Nettoyage si nécessaire
        }
    }
}
