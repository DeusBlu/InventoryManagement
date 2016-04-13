using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGPlayer
{
    class Character
    {
        // Primary stats for the player characters
        // Strength - effects attack power with normal weapons and block chance with heavy shields
        // Agility  - effects attack power with light/ranged weapons dodge, dodge, block with light shields, aim
        // Stamina  - effects HP, armor
        // Magic    - effects magic power, mp
        // Faith    - effects healing power, mp, 

        // Secondary stats for the player
        // HP - measure of health
        // MP - measure of mana to spend on skills
        // Attack Power - damage with weapon attacks and weapon skills
        // Magic Power - damage with elemental attacks and skills
        // Armor - reduces damage taken from a hit
        // Aim - chance to hit the monster
        // Dodge - works directly against aim
        // Block - additive avoidance to dodge, reduces damage by % amount based on shield
        // HIDDEN STAT: Healing Power - directly effects your healing spells
        // 
        // Combat order of operations: parry skill -> dodge -> block -> miss -> hit
        //
        // Level: 20
        // Strength: 95
        // Base Damage: 30
        // Attack Power: 125
        // Damage Desired: 750
        //
        // Level: 50
        // Strength: 200
        // Base Damage: 30
        // Attack Power: 550
        // Damage Desired: 2900
        //
        // Level: 70
        // Strength: 240
        // Base Damage: 30
        // Attack Power: 900
        // Damage Desired: 
        //
        // Variables in damage: roll(5-10), 
        //                      attackPower = added to final damage, 
        //                      level = baseDamage doubles every 3 levels, 
        //                      strength = added to base damage,
        //
        // Damage Calculation:  damageDone = (((strength/10) + roll(5-10)) * (level * level) + attackPower)
        // Hit Calculation:     hit = ((aim - targetDodge > roll) - targetBlock > roll)
        // Damage Reduction:    damageTaken = damageDone * 1 - (armor * 0.00125)

        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Stamina { get; private set; }
        public int Magic { get; private set; }
        public int Faith { get; private set; }

        private HP hp;
        private HP mp;

        public int HP
        {
            get
            {
                return hp.current;
            }
            set
            {
                hp.current = value;
            }
        }
        public int MP
        {
            get
            {
                return mp.current;
            }
            set
            {
                mp.current = value;
            }
        }
        public int AttackPower { get; private set; }
        public int MagicPower { get; private set; }
        public int HealingPower { get; private set; }
        public int Armor { get; private set; }
        public int Aim { get; private set; }
        public int Dodge { get; private set; }
        public int Block { get; private set; }

        public bool IsDead()
        {
            return hp.isEmpty();
        }

        public int getMaxHP()
        {
            return hp.max;
        }

        public int getMaxMP()
        {
            return mp.max;
        }
    }

    struct HP
    {
        public int max { get; set; }
        public int current { get; set; }
        public bool isEmpty()
        {
            if (current <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
