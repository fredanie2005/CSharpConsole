using System;
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
            var key = System.Console.ReadKey(true).Key;
            var (dx, dy) = InputReader.GetMovement(key);

            MovePlayer(dx, dy);
            HandleMapTransition();
            Draw();
        }

        private void MovePlayer(int dx, int dy)
        {
            int newX = _player.X + dx;
            int newY = _player.Y + dy;

            if (newX >= 0 && newX < _mapManager.CurrentMap.Width &&
                newY >= 0 && newY < _mapManager.CurrentMap.Height &&
                _mapManager.CurrentMap.Tiles[newY, newX] != '#')
            {
                _player.X = newX;
                _player.Y = newY;
            }
        }

        private void HandleMapTransition()
        {
            int width = _mapManager.CurrentMap.Width;
            int height = _mapManager.CurrentMap.Height;
            var coords = _mapManager.CurrentMapCoords;

            // Transition horizontale
            if (_player.X == 0)
            {
                _mapManager.ChangeMap(coords.X - 1, coords.Y);
                _player.X = _mapManager.CurrentMap.Width - 2;
            }
            else if (_player.X == width - 1)
            {
                _mapManager.ChangeMap(coords.X + 1, coords.Y);
                _player.X = 1;
            }

            // Transition verticale
            if (_player.Y == 0)
            {
                _mapManager.ChangeMap(coords.X, coords.Y - 1);
                _player.Y = _mapManager.CurrentMap.Height - 2;
            }
            else if (_player.Y == height - 1)
            {
                _mapManager.ChangeMap(coords.X, coords.Y + 1);
                _player.Y = 1;
            }
        }

        public void Draw()
        {
            System.Console.Clear();
            _mapManager.CurrentMap.Draw();
            System.Console.SetCursorPosition(_player.X * 2, _player.Y);
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
