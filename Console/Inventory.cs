using System;
using IItemSpace;
using ItemSpace;
using PlayerSpace;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySpace
{
    public class Inventory
    {
        private Dictionary<Item, int> items = new Dictionary<Item, int>();

        public void Add(Item item, int qty = 1)
        {
            if (items.ContainsKey(item))
                items[item] += qty;
            else
                items[item] = qty;
        }

        public void Show()
        {
            System.Console.WriteLine("=== Inventaire ===");
            if (items.Count == 0)
            {
                System.Console.WriteLine("Inventaire vide !");
                return;
            }

            foreach (var kvp in items)
            {
                System.Console.WriteLine($"{kvp.Key} x{kvp.Value}");
            }
        }


    }
}
