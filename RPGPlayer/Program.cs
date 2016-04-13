using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory playerInventory = new Inventory(10, 20);
            Equipment equipment = new Equipment(playerInventory);
            EquipSlots THIRD_WEAPON = equipment.GenerateEquipSlot();
            Gear gear = new Weapon("Rapier", THIRD_WEAPON);
            equipment.Equip(gear, gear.EquipSlot);
            if (equipment.IsEquipped(THIRD_WEAPON))
            {
                Console.WriteLine("True");
            }

            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            int currentCount = playerInventory.GetCurrentCount();
            int currentSize = playerInventory.GetCurrentSize();
            Gear slot1 = (Gear)playerInventory.GetItemLocation(0);
            int maxSize = playerInventory.GetMaxSize();
            bool isFull = playerInventory.IsFull();
            playerInventory.RemoveItem(0);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), gear);
            isFull = playerInventory.IsFull();
            currentCount = playerInventory.GetCurrentCount();
            Console.WriteLine("Done!");
        }
    }
}
