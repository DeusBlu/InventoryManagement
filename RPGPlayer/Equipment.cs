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

        /* Equips the item passed to the EquipSlot passed. If the equipment cannot be equipped
        to the equip slot then the original item passed is returned. */
        public Gear Equip(Gear equip, EquipSlots slot)
        {
            Gear equipped = equip;
            // will be 0 if the equipment cannot go in that slot
            if((equip.EquipSlot & slot) != 0)
            {
                // will be false if there is nothing equipped to that slot
                if(IsEquipped(slot))
                {
                    // is the item to equip two handed
                    if((equip.EquipSlot & EquipSlots.TWO_HANDED) != 0)
                    {
                        // will be false if a two handed weapon is not equipped
                        if (!IsEquipped(EquipSlots.TWO_HANDED))
                        {
                            // Here we need to know if both hands are equipped or only one
                            // returns true is both hands equipped with item
                            if (IsEquipped(EquipSlots.BOTH_HANDS))
                            {
                                // evaluates to true if the inventory has enough space to return the item
                                if (!playerInventory.IsFull())
                                {
                                    // both hands have to have something in them and cannot be a 2H item by here
                                    // so we add offhand to the inventory and place main hand on the cursor by returning it
                                    playerInventory.AddItemToLocation(playerInventory.GetFirstEmptyIndex(), (Item)equipment[EquipSlots.OFF_HAND]);
                                    equipped = Unequip(EquipSlots.MAIN_HAND);
                                    equipGear(equip, slot);
                                }
                            }
                            else
                            {
                                // by this point we can assume that the item being
                                // equipped is a 2H weapon and only one hand is used
                                if (IsEquipped(EquipSlots.MAIN_HAND))
                                {
                                    equipped = Unequip(EquipSlots.MAIN_HAND);
                                    equipGear(equip, slot);
                                }
                                else
                                {
                                    equipped = Unequip(EquipSlots.OFF_HAND);
                                    equipGear(equip, slot);
                                }
                            }
                        }
                        else
                        {
                            equipped = Unequip(slot);
                            equipGear(equip, slot);
                        }
                    }
                    else
                    {
                        equipped = Unequip(slot);
                        equipGear(equip, slot);
                    }
                }
                else
                {
                    equipGear(equip, slot);
                }
            }
            return equipped;
        }

        /* unequips items updates the equip state and returns the unequipped item*/
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

        /* equips gear and updates the equipState at the same time to
        keep these two items in sync */
        private void equipGear(Gear equip, EquipSlots slot)
        {
            equipment.Add(slot, equip);
            equipState = equipState | equip.EquipSlot;
        }

        /* returns an enumerator for working with the gear set in game */
        public IDictionaryEnumerator GetIterator()
        {
            return equipment.GetEnumerator();
        }

        /* returns the gear in the specified equip slot */
        public Gear GetGearBySlot(EquipSlots slot)
        {
            return (Gear)equipment[slot];
        }

        /* returns the current equip state to the user for testing in game logic */
        public EquipSlots GetCurrentEquipState()
        {
            return equipState;
        }

        /* generates new enum labels so you can create your own equipment location lists */
        public EquipSlots GenerateEquipSlot()
        {
            EquipSlots slot = (EquipSlots)(1 << nextSlot);
            ++nextSlot;
            return slot;
        }

        /* returns true if the spot being equipped to has equipment in it */
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
