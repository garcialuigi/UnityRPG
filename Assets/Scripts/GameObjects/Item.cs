﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SimpleRPG2
{

    public class ItemSet
    {
        public string itemName { get; set; }
        public int itemID { get; set; }
        public int count { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is ItemSet)
            {
                ItemSet itemSet2 = (ItemSet)obj;
                if (this.itemID == itemSet2.itemID)
                {
                    return true;

                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return itemID.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", itemName, count);
        }
        
    }

    public class Item
    {
        public int ID { get; set; }
        public string name { get; set; }
        public ItemType type { get; set; }
        public List<PassiveEffect> passiveEffects { get; set; }
        public List<ActiveEffect> activeEffects { get; set; }

        public string getEffects()
        {
            string retval = "";
            foreach(var p in passiveEffects)
            {
                retval+= p.ToString() + " ";
            }

            foreach(var a in activeEffects)
            {
                retval += a.ToString() + " ";
            }

            return retval;
        }

    }

    public class UsableItem : Item
    {
        public int actionPoints { get; set; }
        public int uses { get; set; }
        public Ability itemAbility { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ap: {1} use: {2} effects: {3}", name, actionPoints,uses, getEffects());
        }
    }

    public class Weapon : Item
    {
        public int minDamage { get; set; }
        public int maxDamage { get; set; }
        public int actionPoints { get; set; }
        public WeaponType weaponType {get;set;}
             

        public override string ToString()
        {
            return string.Format("{0} dmg: {1}-{2} ap: {3}", name, minDamage,maxDamage,actionPoints);
        }

    }

    public class RangedWeapon : Weapon
    {
        public int range { get; set; }
        public AmmoType ammoType { get; set; }

        public override string ToString()
        {
            return string.Format("{0} dmg: {1}-{2} range:{3} ammo {4} ap: {5}", name, minDamage, maxDamage,range,ammoType.ToString(), actionPoints);
        }
    }

    public class Ammo : Item
    {
        
        public int bonusDamage { get; set; }
        public AmmoType ammoType { get; set; }

        public override string ToString()
        {
            return string.Format("{0} dmg: {1} type: {2}", name, bonusDamage, ammoType.ToString());
        }
    }

    public class Armor : Item
    {
        public int armor { get; set; }
        public ArmorType armorType { get; set; }

        public override string ToString()
        {
            return string.Format("{0} armor: {1} type: {2}", name, armor, armorType.ToString());
        }
    }

   
    
}
