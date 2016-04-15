using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPlayer
{
    class Inventory
    {
        private List<Item> inventory = new List<Item>();
        private int currentSize = 0;
        private int currentCount = 0;

        // constructs the inventory setting the total gameMax size and
        // the current inventory size, gameMax assigns the memory at
        // construction time
        public Inventory(int size, int gameMax)
        {
            inventory.Capacity = gameMax;
            SetCurrentSize(size);
        }
        // returns the total max size the inventory is alowed to expand to
        public int GetMaxSize()
        {
            return inventory.Capacity;
        }
        // returns how big the inventory currently is
        public int GetCurrentSize()
        {
            return currentSize;
        }
        // returns the number of items currently in the inventory
        public int GetCurrentCount()
        {
            return currentCount;
        }
        // change how big the inventory is, must be greater than 0 
        // and less than or equal to capacity
        public void SetCurrentSize(int size)
        {
            while (currentSize < size && currentSize <= inventory.Capacity)
            {
                inventory.Add(null);
                ++currentSize;
            }
        }
        // Places the passed item into the provided index and returns 
        // the item previously in that location
        public Item AddItemToLocation(int index, Item item)
        {
            if (index >= 0 && index <= currentSize)
            {
                if (!(item is Gear) && inventory[index] != null && item.Id == inventory[index].Id)
                {
                    if(item.StackSize + inventory[index].StackSize > item.StackMax)
                    {
                        int totalStack = item.StackSize + inventory[index].StackSize;
                        inventory[index].StackSize = item.StackMax;
                        item.StackSize = totalStack - item.StackMax;
                    }
                }
                else
                {
                    Item previousItem = inventory[index];
                    RemoveItem(index);
                    inventory[index] = item;
                    ++currentCount;
                    return previousItem;
                }
            }
            return item;
        }
        // removes the item at index, returns true if successful
        public bool RemoveItem(int index)
        {
            if (index >= 0 && index <= currentSize && inventory[index] != null)
            {
                inventory[index] = null;
                --currentCount;
                return true;
            }
            return false;
        }
        // returns the item at provided index, returns null if the index
        // is empty or does not exist (is below 0 or above capacity)
        public Item GetItemLocation(int index)
        {
            if (index >= 0 && index <= currentSize)
            {
                return inventory[index];
            }
            return null;
        }
        // returns the index of the next empty spot in the array
        public int GetFirstEmptyIndex()
        {
            if (currentCount < currentSize)
            {
                for (int iter = 0; iter < currentSize; ++iter)
                {
                    if (inventory[iter] == null)
                    {
                        return iter;
                    }
                }
            }
            return -1;
        }
        // returns true if the inventory is full
        public bool IsFull()
        {
            if (currentCount == currentSize)
            {
                return true;
            }
            return false;
        }
    }
}
