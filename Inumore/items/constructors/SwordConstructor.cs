using Inumore.items.weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items.constructors
{
    public class SwordConstructor : IConstructor
    {
        public Item Initialize(string name, int quantity = 1, int level = 0)
        {
            return new Sword(level, name, quantity);
        }
    }
}
