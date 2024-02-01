using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items
{
    public class HealItem : Item, IExportable
    {
        private string name;
        private int healing = 5;
        public override string Category => "heal";

        public override string Name => name;

        public HealItem(string name, int healing, int quantity): base(quantity)
        {
            this.name = name;
            this.healing = healing;
        }

        public override string toXML()
        {
            string node = "<heal name=\"" + name + "\" ";
            node += "heal=\"" + healing + "\"";
            node += "nb=\"" + quantity + "\"";
            return node + " >";
        }
    }
}
