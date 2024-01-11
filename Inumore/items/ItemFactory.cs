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
        public Item generateItem(string category, string name, int quantity = 1, int level = 0)
        {
            //To improve
            Item item;
            switch (category)
            {
                case "sword":
                    item = new Sword(name);
                    break;
                case "heal":
                    item = new HealItem("Fubuki Corn", level);
                    break;
                default:
                    item = new Sword("Emiyako");
                    break;
            }
            return item;
        }
    }
}
