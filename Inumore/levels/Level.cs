using Inumore.mobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.levels
{
    public abstract class Level
    {
        protected List<Mob> mobs = new List<Mob>();
        private bool cleared;
        public abstract int LevelId { get; }

        public abstract string Name { get; }

        public Level(bool cleared = false)
        {
            this.generateMobs();
        }

        public Level(List<Mob> mobs, bool cleared = false)
        {
            this.mobs = mobs;
            this.cleared = cleared;
        }
        protected abstract void generateMobs();



    }
}
