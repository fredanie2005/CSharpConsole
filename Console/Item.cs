using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using IItemSpace;

namespace ItemSpace;

public class Item : IItem
{
    string _name;
    public string Name => _name;

    public Item(string name)
    {
        _name = name;
    }

    public void Use()
    {
        //A remplir
    }
}
