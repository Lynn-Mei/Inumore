using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items
{
    public class HealItem : Item
    {
        private string name;
        private int healing = 5;
        public override string Category => "heal";

        public override string Name => name;

        public HealItem(string name, int healing)
        {
            this.name = name;
            this.healing = healing;
        }
    }
}
