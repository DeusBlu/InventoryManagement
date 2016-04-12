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
            Equipment equipment = new Equipment();
            EquipSlots THIRD_WEAPON = equipment.GenerateEquipSlot();
            Gear gear = new Weapon("Rapier", THIRD_WEAPON);
            equipment.Equip(gear, gear.EquipSlot);
            if (equipment.IsEquipped(THIRD_WEAPON))
            {
                Console.WriteLine("True");
            }
        }
    }
}
