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

        public float GainExperience(Entity enemy)
        {
            float experiencegained = 25 * enemy._level;
            _experience += experiencegained;
            return experiencegained;
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
        //prints an entities stats
        
        //allows entity to attack an enemy by calling targets take damage function
        public void Attack(Entity agressor, Entity target)
        {
            float damage = agressor._baseDamage;
            target.TakeDamage(damage);
            Console.WriteLine(agressor._name + " hit " + target._name + " for " + damage + " damage!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public void BlindAttack(Entity agressor, Entity target)
        {
            float HitChance = GenerateNumber(1, 10);
            if (HitChance >= 5)
            {
                //50% chance of hitting for 50% more damage
                float damage = agressor._baseDamage * .5f + _baseDamage;
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
        public void TakeDamage(float damage)
        {
            _health -= damage;
            if (_health < 0)
            {
                _health = 0;
            }
        }
        public void LevelUP()
        {
            for (float i = _experience; i >= 100; i -= 100)
            {
                _level += 1;
                _experience -= 100;
            }
        }
    }
}
