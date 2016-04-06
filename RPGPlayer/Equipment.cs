﻿using System;
using System.Collections;

namespace RPGPlayer
{
    class Equipment
    {
        private Hashtable equipment = new Hashtable();
        private EquipSlots equipState = new EquipSlots();
        private int nextSlot;

        private bool debug = false;

        public Equipment()
        {
            equipState = equipState | EquipSlots.NO_WEAPONS;
            nextSlot = 5;
        }

        public Gear Equip(Gear equip)
        {
            Gear equipped = null;
            if (equip.EquipSlot == EquipSlots.TWO_HANDED)
            {
                if(equipState.HasFlag(EquipSlots.OFF_HAND) && equipState.HasFlag(EquipSlots.MAIN_HAND))
                {
                    // TODO: Add inventory system and move offhand to inventory first
                    /*MoveToInventory(*/Unequip(EquipSlots.OFF_HAND);
                    equipped = Unequip(EquipSlots.MAIN_HAND);
                    equipment.Add(equip.EquipSlot, equip);
                }

            }
            else
            {
                equipped = Unequip(equip.EquipSlot);
                equipState = equipState ^ equip.EquipSlot;
                equipment.Add(equip.EquipSlot, equip);
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
