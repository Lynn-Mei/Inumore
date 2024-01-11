using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items
{
    public abstract class Item: IExportable
    {
        protected int quantity = 1;

        public abstract string Category { get; }
        public abstract string Name { get; }

        public virtual string toXML()
        {
            string node = "<" + Category + " type=\"" + Name + "\"";
            if (quantity > 1)
                node += "quantity=\"" + this.quantity + "\"";
            return node + "/>";
        }
    }
}
