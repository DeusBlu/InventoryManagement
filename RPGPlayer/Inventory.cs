using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPlayer
{
    class Inventory
    {
        private List<Item> inventory;

        public Inventory(int size)
        {
            inventory = new List<Item>(size);
        }
    }
}
