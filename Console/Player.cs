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
        public Inventory getInventory => _inventory;

        public int _x = 1;
        public int _y = 1;

        public Player(int hp, int maxHp = 20) : base(hp, maxHp)
        {
            _inventory = new Inventory();
        }
    }
}
