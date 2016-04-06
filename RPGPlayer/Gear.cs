using System;

namespace RPGPlayer
{
    class Gear : Item
    {
        private EquipSlots equipSlot;
        private bool isWeapon;

        public bool IsWeapon
        {
            get { return isWeapon; }
           
        }
        public EquipSlots EquipSlot
        {
            get { return equipSlot; }
        }

        public Gear(String name, EquipSlots equipSlot, bool isWeapon)
            : base(name)
        {
            this.equipSlot = equipSlot;
            this.isWeapon = isWeapon;
        }


    }

    class Weapon : Gear
    {
        public Weapon(String name, EquipSlots equipSlot)
            : base(name, equipSlot, true)
        {

        }
    }
}