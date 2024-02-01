﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inumore.items.weapons
{
    public class Sword:Weapon
    {
        private string name;
        private int damage = 5;
        public override string Name { get { return name; } }

        public Sword(int level, string name, int quantity):base(level, quantity)
        {
            this.name = name;
            this.damage = 5;
        }
    }
}
