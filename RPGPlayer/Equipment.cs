using System;
using System.Collections;

namespace RPGPlayer
{
    class Equipment
    {
        private Inventory playerInventory;
        private Hashtable equipment = new Hashtable();
        private EquipSlots equipState = new EquipSlots();
        private int nextSlot = 5;


        public Equipment(ref Inventory playerInventory)
        {
            this.playerInventory = playerInventory;
            equipState = equipState | EquipSlots.NO_WEAPONS;
        }

        // Equips the item passed to the EquipSlot passed. If the equipment cannot be equipped
        // to the equip slot then the original item passed is returned.
        public Gear Equip(Gear equip, EquipSlots slot)
        {
            Gear equipped = equip;
            // will be 0 if the equipment cannot go in that slot
            if((equip.EquipSlot & slot) != 0)
            {
                // will be 0 if there is nothing equipped to that slot
                if((equip.EquipSlot & equipState) != 0)
                {
                    // is the item to equip two handed
                    if(equip.EquipSlot == EquipSlots.TWO_HANDED)
                    {
                        // will be 0 if only one hand is equipped
                        if((equipState & EquipSlots.BOTH_HANDS) != 0)
                        {
                            // evaluates to true if the inventory has enough space to return the item
                            if(!playerInventory.IsFull())
                            {

                            }
                        }
                    }
                }
            }
            return equipped;
        } // TODO: FINISH LOGIC!

        public Gear Unequip(EquipSlots slot)
        {
            Gear equipped = (Gear)equipment[slot];
            if (equipped != null)
            {
                equipState = equipState ^ equipped.EquipSlot;
                equipment.Remove(slot);
            }
            return equipped;
        }

        public IDictionaryEnumerator GetIterator()
        {
            return equipment.GetEnumerator();
        }

        public Gear GetGearBySlot(EquipSlots slot)
        {
            return (Gear)equipment[slot];
        }

        public EquipSlots GetCurrentEquipState()
        {
            return equipState;
        }

        public EquipSlots GenerateEquipSlot()
        {
            EquipSlots slot = (EquipSlots)(1 << nextSlot);
            ++nextSlot;
            return slot;
        }

        public bool IsEquipped(EquipSlots slot)
        {
            return equipState.HasFlag(slot);
        }
    }

    [Flags]
    public enum EquipSlots
    {
        NO_WEAPONS = 1,
        BOTH_WEAPONS = 1 << 1,
        TWO_HANDED = 1 << 2,
        MAIN_HAND = 1 << 3,
        OFF_HAND = 1 << 4,
        BOTH_HANDS = MAIN_HAND | OFF_HAND
    }
}
