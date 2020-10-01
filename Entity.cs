using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;
using System.Text;

namespace HelloWorld
{
    class Entity
    {
        //base variables all entities should have
        protected string _name;
        protected float _health;
        protected float _baseDamage;
        protected int _level;
        protected float _experience;
        protected int _mana;
        protected bool _hasMana;
        protected Items[] inventory = new Items[3];
        public Items _EmptySlot = new Items(true);
        //template constructor
        public Entity()
        {
            _name = "Template";
            _health = 1;
            _baseDamage = 0;
            _level = 0;
            _experience = 0;
            _hasMana = false;
        }
        //base constructor entended for important enemy
        Entity(string nameVal, float healthVal, float damageVal, int levelVal)
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _level = levelVal;
            _hasMana = false;
        }

        //takes in min and max to make generating numbers easy and variables non permanent
        //i really like this function
        public float GenerateNumber(int min, int max)
        {
            Random r = new Random();
            float number = r.Next(min, max);
            return number;
        }
        //Set allows me to change values from 

        //The following allow me to Get information from the protected variables declared above
        public string GetName()
        {
            return _name;
        }

        public int GetLevel()
        {
            return _level;
        }
        public float GetBaseDamage()
        {
            return _baseDamage;
        }
        public float GetExperience()
        {
            return _experience;
        }
               
        public float GetHealth()
        {
            return _health;
        }
        public int GetMana()
        {
            return _mana;
        }
        
        //allows entity to attack an enemy by calling targets take damage function
        public void Attack(Entity agressor, Entity target)
        {
            float damage = agressor._baseDamage;
            damage += agressor.inventory[0].GetDamageBoost();
            damage += agressor.inventory[1].GetDamageBoost();
            damage += agressor.inventory[2].GetDamageBoost();
            target.TakeDamage(damage);
            Console.WriteLine(agressor._name + " hit " + target._name + " for " + damage + " damage!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void BlindAttack(Entity agressor, Entity target) //50% chance to hit target for 50% more damage;
        {
            float HitChance = GenerateNumber(1, 10);
            if (HitChance >= 5)
            {
                //50% chance of hitting for 50% more damage
                float damage =( _baseDamage + inventory[1].GetDamageBoost() + inventory[2].GetDamageBoost() + inventory[0].GetDamageBoost()) * .5f + _baseDamage;
                target.TakeDamage(damage);
                Console.WriteLine(agressor._name + " hit " + target._name + " for " + damage + " damage!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(agressor._name + " missed!\nPress any key to continue");
                Console.ReadKey();
            }
        }
        public void InitInventory()//allows me to not get a null error
        {
            for (int i = 0; i < inventory.Length; i++) // for however many positions in an array, declares item "EmptySlot" in said position
            {
                inventory[i] = _EmptySlot;
            }
        }
        public void TakeDamage(float damage) // allows for entities to decrement their own health
        {
            _health -= damage;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }
}
