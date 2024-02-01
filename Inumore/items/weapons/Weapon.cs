using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items.weapons
{
    public class Weapon : Item
    {
        protected int level;

        public override string Category => "weapon";
        public override string Name { get; }

        public Weapon(int level, int quantity) : base(quantity)
        {
            this.level = level;
        }

        public override string toXML()
        {
            string node = "<" + Category + " type=\"" + Name + "\" level=\"" + level + "\"";
            if (quantity > 1)
                node += "quantity=\"" + quantity + "\"";
            return node + "/>";
        }

    }
}
