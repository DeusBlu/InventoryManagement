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
            Equipment equipment = new Equipment(ref playerInventory);
            EquipSlots THIRD_WEAPON = equipment.GenerateEquipSlot();
            Gear rapier = new Gear("Rapier", THIRD_WEAPON, 1);
            equipment.Equip(rapier, rapier.EquipSlot);
            if (equipment.IsEquipped(THIRD_WEAPON))
            {
                Console.WriteLine("True");
            }

            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            int currentCount = playerInventory.GetCurrentCount();
            int currentSize = playerInventory.GetCurrentSize();
            Gear slot1 = (Gear)playerInventory.GetItemLocation(0);
            int maxSize = playerInventory.GetMaxSize();
            bool isFull = playerInventory.IsFull();
            playerInventory.RemoveItem(0);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), rapier);
            isFull = playerInventory.IsFull();
            currentCount = playerInventory.GetCurrentCount();
            Console.WriteLine("Done!");
            EquipSlots HEAD = equipment.GenerateEquipSlot();
            Gear helm = new Gear("Helm", HEAD, 2);
            EquipSlots BODY = equipment.GenerateEquipSlot();
            Gear chest = new Gear("Chest", BODY, 3);
            EquipSlots LEGS = equipment.GenerateEquipSlot();
            Gear pants = new Gear("Pants", LEGS, 4);

            Gear helm2 = new Gear("Assault Helm", HEAD, 5);
            
            equipment.Equip(helm, helm.EquipSlot);
            equipment.Equip(chest, chest.EquipSlot);
            equipment.Equip(pants, pants.EquipSlot);
            helm = null;
            helm = equipment.Equip(helm2, helm2.EquipSlot);

            if(playerInventory.GetItemLocation(2) is Gear)
            {
                Console.WriteLine("Gear tested proper out of Item array");
            }

            Item healingPotion = new Item("Healing Potion", 20, 6);
            healingPotion.StackSize = 15;
            Item healingPotion2 = new Item("Healing Potion", 20, 6);
            healingPotion2.StackSize = 7;
            playerInventory.RemoveItem(0);
            playerInventory.AddItemToLocation(0, healingPotion);
            playerInventory.AddItemToLocation(0, healingPotion2);
        }
    }
}
