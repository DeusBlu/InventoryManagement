using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPlayer
{
    class Item
    {
        String name;
        public String Name { get { return name; } }
        private int stackSize;
        public int StackSize 
        { 
            get
            {
                return stackSize;
            }
            set 
            {
                if (value >= 0)
                {
                    if (value >= stackMax)
                    {
                        stackSize = stackMax;
                    }
                    else
                    {
                        stackSize = value;
                    }
                }
            } 
        }
        private int stackMax;
        public int StackMax { get { return stackMax; } }

        private int id;
        public int Id { get { return id; } }

        public Item(String name, int stackMax, int id)
        {
            this.name = name;
            this.stackMax = stackMax;
            StackSize = 1;
        }
    }
}
