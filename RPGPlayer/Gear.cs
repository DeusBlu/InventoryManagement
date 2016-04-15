using System;

namespace RPGPlayer
{
    class Gear : Item
    {
        private EquipSlots equipSlot;

        public EquipSlots EquipSlot
        {
            get { return equipSlot; }
        }

        public Gear(String name, EquipSlots equipSlot, int id)
            : base(name, 1, id)
        {
            this.equipSlot = equipSlot;
        }
    }
}