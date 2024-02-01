using Inumore.items.constructors;
using Inumore.items.weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items
{
    public class ItemFactory
    {
        private readonly Dictionary<string, IConstructor> constructors;
        public ItemFactory()
        {
            this.constructors = new Dictionary<string, IConstructor>();
            this.constructors.Add("sword", new SwordConstructor());
            this.constructors.Add("heal", new HealItemConstructor());
        } 
        public Item generateItem(string category, string name, int quantity = 1, int level = 0)
        {
            return constructors[category].Initialize(name, quantity, level);
        }
    }
}
