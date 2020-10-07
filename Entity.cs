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
        protected int _maxMana;
        protected bool _hasMana;
        protected bool _isPolymorphed;
        protected int _polynumber;

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
        public int GenerateNumber(int min, int max, bool isInt)
        {
            Random r = new Random();
            int number = r.Next(min, max);
            return number;
        }
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
        public bool isPolymorphed()
        {
            return _isPolymorphed;
        }
        public int GetPolyNumber()
        {
            return _polynumber;
        }
        public bool HasMana()
        {
            if (_hasMana == true)
            { return true; }
            else { return false; }
        }
        public void SetPolyNumber(int polynumber)
        {
            _polynumber = polynumber;
        }

        public void Polymorph(Entity target)
        {
            target._isPolymorphed = true;
        }
        
        public void Polymorph(int animalnumber)
        {
            _level = 1;
            _baseDamage = 2;
            _hasMana = false;
            switch (animalnumber)
            {
                case 1:
                    _name = "Chicken";
                    _health = 10;
                    break;
                case 2:
                    _name = "Deer";
                    _health = 20;
                    break;
                case 3:
                    _name = "Pig";
                    _health = 15;
                    break;
            }

        }

        //allows entity to attack an enemy by calling targets take damage function
        public virtual void Attack(Entity target)
        {
            target.TakeDamage(_baseDamage);
            Console.WriteLine(_name + " hit " + target._name + " for " + _baseDamage + " damage!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(false);
        }
        public virtual void BlindAttack(Entity target) //50% chance to hit target for 50% more damage;
        {
            float HitChance = GenerateNumber(1, 10);
            if (HitChance >= 5)
            {
                //50% chance of hitting for 50% more damage
                float damage = (_baseDamage) * .5f + _baseDamage;
                target.TakeDamage(damage);
                Console.WriteLine(_name + " hit " + target._name + " for " + damage + " damage!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(false);
            }
            else
            {
                Console.WriteLine(_name + " missed!\nPress any key to continue");
                Console.ReadKey(false);
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
        public virtual void PrintStats()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(_name);
            Console.WriteLine(_health + " health remaining");
            if (_hasMana == true)
            {
                Console.WriteLine(_mana + " mana remaining");
            }
            Console.WriteLine("Total output damage " + _baseDamage);
            Console.WriteLine("Level " + _level);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual void ManaAttack(Entity target)
        {
            if (_hasMana == true)
            {
                int manaAttackChoice = GenerateNumber(0, 3, true);
                switch (manaAttackChoice)
                {
                    case 0:
                        {
                            float hitChance = GenerateNumber(1, 10);
                            Console.Write(_name + " casts ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("FIREBALL");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("!");
                            if (hitChance > 5)
                            {
                                Console.Write(_name + "'s ");
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("FIREBALL");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" fizzles out pathetically");
                            }
                            else
                            {
                                if (_mana >= 5)
                                {
                                    float damage = _level * _baseDamage;
                                    Console.WriteLine(_name + " hit " + target.GetName() + " with a magical fireball for " + damage + "!");
                                    target.TakeDamage(damage);
                                    _mana -= 5;
                                }
                                else
                                {
                                    Console.Write(_name + " does not have enough mana for ");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.Write("FIREBALL");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("!");
                                }
                            }
                        }
                        break;
                    case 1:
                        {
                            float hitChance = GenerateNumber(1, 10);
                            Console.Write(_name + " casts ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("LIGHTNING BOLT");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("!");
                            if (hitChance > 5)
                            {
                                Console.Write(_name + "'s ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("LIGHTNING BOLT");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" fizzles out pathetically");
                            }
                            else
                            {
                                if (_mana >= 5)
                                {
                                    float damage = _level * _baseDamage + 3;
                                    Console.WriteLine(_name + " hit " + target.GetName() + " with a lightning bolt " + " for " + damage + "!");
                                    target.TakeDamage(damage);
                                    _mana -= 5;
                                }
                                else
                                {
                                    Console.Write(_name + " does not have enough mana for ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("LIGHTNING BOLT");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("!");
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            float hitChance = GenerateNumber(1, 10);
                            Console.Write(_name + " casts ");
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("SEND TO BRAZIL");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("!");
                            if (hitChance > 5)
                            {
                                Console.Write(_name + "'s ");
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.Write("SEND TO BRAZIL");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" fizzles out pathetically");
                            }
                            else
                            {
                                if (_mana >= 15)
                                {
                                    float damage = _level * _baseDamage + 20;
                                    Console.WriteLine(_name + " hit " + target.GetName() + " with a magical fireball for " + damage + "!");
                                    target.TakeDamage(damage);
                                    _mana -= 15;
                                }
                                else
                                {
                                    Console.Write(_name + " does not have enough mana for ");
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write("SEND TO BRAZIL");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("!");
                                }
                            }
                            break;
                        }
                    case 3:
                        {
                            float hitChance = GenerateNumber(1, 10);
                            Console.Write(_name + " casts ");
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("METEOR SHOWER");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("!");
                            if (hitChance > 5)
                            {
                                Console.Write(_name + "'s ");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write("METEOR SHOWER");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" fizzles out pathetically");
                            }
                            else
                            {
                                if (_mana >= 10)
                                {
                                    float damage = _level * _baseDamage + 10;
                                    Console.WriteLine(_name + " hit " + target.GetName() + " with a magical fireball for " + damage + "!");
                                    target.TakeDamage(damage);
                                    _mana -= 10;
                                }
                                else
                                {
                                    Console.Write(_name + " does not have enough mana for ");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write("METEOR SHOWER");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("!");
                                }
                            }
                            break;
                        }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(_name + " does not possess magical abilities!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
