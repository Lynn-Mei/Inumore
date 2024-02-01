using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items.constructors
{
    public class HealItemConstructor : IConstructor
    {
        public Item Initialize(string name, int quantity, int level)
        {
            return new HealItem(name, level, quantity);
        }
    }
}
