using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CharacterSpace;
using InventorySpace;

namespace PlayerSpace
{
    public class Player : Character
    {
        Inventory _inventory;
        public Inventory GetInventory => _inventory;

        private int _x = 2;
        private int _y = 2;
        public int X { get; set; }
        public int Y { get; set; }

        public Player(int hp, int maxHp = 20) : base(hp, maxHp)
        {
            _inventory = new Inventory();
        }
    }
}
