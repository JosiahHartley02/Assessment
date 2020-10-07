using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Player : Entity
    {

        protected float _maxHealth;
        private int _gold;
        protected Items[] inventory = new Items[3];
        public Player() //base constructor
        {
            _name = "UnNammed";
            _baseDamage = 0;
            _health = 0;
            _experience = 0;
            _level = 0;
        }
        //Constructor used to choose character
        public Player(int choiceVal)
        {
            int choice = choiceVal;
            switch (choice)
            {
                case 1:
                    _name = "Mouse Man";
                    _baseDamage = 5;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 2:
                    _name = "Merlin";
                    _baseDamage = 15;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _mana = 50;
                    _hasMana = true;
                    _maxMana = 100;
                    break;
                case 3:
                    _name = "WolfGang";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 4:
                    _name = "Proffessor Eisenburg";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
            }
            _gold = 0;
            _maxHealth = _health;
            InitInventory();
        }
        public void InitInventory()//allows me to not get a null error
        {
            for (int i = 0; i < inventory.Length; i++) // for however many positions in an array, declares item "EmptySlot" in said position
            {
                inventory[i] = _EmptySlot;
            }
        }
        public Items Inventory(int slot)
        {
            return inventory[slot];
        }
        public void PrintInventory() // prints item names at each position in the inventory aray
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine(inventory[i].GetName());
            }
        }
        public float GainExperience(Entity enemy) // player earns experience depending on the level of the enemy
        {
            float experiencegained = 25 * enemy.GetLevel();
            _experience += experiencegained;
            return experiencegained;
        }
        public void LevelUP() // tests for each lvl the player could level
        {
            for (float i = _experience; i >= 100; i -= 100)
            {
                _level += 1;
                _experience -= 100;
            }
        }

        public void BuyItem(Shop shopname, int arrayPosition) //takes in a shop object and an int for the position in the array
        {
            if (shopname.GetValue(arrayPosition) <= _gold)//if player can afford then do this
            {
                _gold -= shopname.GetItem(arrayPosition).GetValue();
                shopname.SellItem(shopname.GetItem(arrayPosition)); //The shop increases its value by the value of the item in the
                EquipItem(shopname.GetItem(arrayPosition));
            }                                                     //shops inventory array at the desired position declared above
            else
            {
                Console.WriteLine("It appears that " + _name + " doesn't have enough gold for this");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(false);
            }
        }
        public void SellItem(Shop shopname, int arrayPosition) // takes in shop object and position of the array the player wants to sell
        {
            if (shopname.BuyItem(inventory[arrayPosition]) == true) //calls for the shop to attempt to buy the item from the player, if it can 
            {
                _gold += inventory[arrayPosition].GetValue();  //increase the players gold by the value of the item that was sold
                inventory[arrayPosition] = _EmptySlot;         //removes the item from the players inventory
            }
        }
        public void EquipItem(Items itemname) //Allows player to put an item in a specific slot, then updates max health in case an item was removed or added
        {
            Console.Clear();
            Console.WriteLine("Where would you like to store your item, other items may be overridden do not stack items");
            char input = GetInput(inventory[0].GetName(), inventory[1].GetName(), inventory[2].GetName(), "cancel", "Where would you like to place your item");
            switch (input)
            {
                case '1':
                    inventory[0] = itemname;
                    break;
                case '2':
                    inventory[1] = itemname;
                    break;
                case '3':
                    inventory[2] = itemname;
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Process canceled\nPress any key to continue");
                    Console.ReadKey(false);
                    break;
            }
            Console.Clear();
            PrintInventory();
            UpdateMaxHealth();
            Console.WriteLine("press any key to continue");
            Console.ReadKey(false);
        }
        public override void Attack(Entity target)
        {
            float damage = GetBaseDamage();
            damage += inventory[0].GetDamageBoost();
            damage += inventory[1].GetDamageBoost();
            damage += inventory[2].GetDamageBoost();
            target.TakeDamage(damage);
            Console.WriteLine(_name + " hit " + target.GetName() + " for " + damage + " damage!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(false);
        }
        public override void ManaAttack(Entity target)      //Tests for mana and may call an attack depending on luck and mana quantity
        {
            char attackChoice = GetInput("FireBall  5 mana", "LightningBolt  10 mana", "Bare Knuckles 0 mana", "Polymorph 25 mana", "Which spell would you like to cast");
            float hitChance = GenerateNumber(1, 10);
            switch (attackChoice)
            {
                case '1':
                    {
                        Console.WriteLine(_name + " casts a fireball!");
                        if (hitChance > 7)
                        {
                            Console.WriteLine("The fireball fizzles out");
                        }
                        else
                        {
                            if (_mana >= 5)
                            {
                                float damage = _baseDamage + _baseDamage * (.05f * _level);
                                target.TakeDamage(damage);
                                Console.WriteLine(target.GetName() + " took " + damage + " from the fireball");
                                _mana -= 5;

                            }
                            else
                            {
                                Console.WriteLine(_name + "'s fireball fizzled out before it was even conjured!");
                            }
                        }
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine(_name + " casts a Lightning Bolt!");
                        if (hitChance > 7)
                        {
                            Console.WriteLine("The lightning bolt fizzles out");
                        }
                        else
                        {
                            if (_mana >= 10)
                            {
                                float damage = _baseDamage + _baseDamage * (.05f * _level);
                                target.TakeDamage(damage);
                                Console.WriteLine(target.GetName() + " took " + damage + " from the lightningbolt");
                                _mana -= 10;

                            }
                            else
                            {
                                Console.WriteLine(_name + "'s lightning bolt fizzled out before it was even conjured!");
                            }
                        }
                        break;
                    }
                case '3':
                    {
                        Console.WriteLine(_name + " Throws Hands!");
                        Attack(target);
                        break;
                    }
                case '4':
                    {
                        Console.WriteLine(_name + " casts polymorphism!");
                        if (hitChance > 7)
                        {
                            Console.WriteLine("The spell fails!");
                        }
                        else
                        {
                            if (_mana >= 25)
                            {
                                Polymorph(target);
                                int animalChoice = GenerateNumber(1, 3, true);
                                string previousName = target.GetName();
                                if (animalChoice == 1) { target.Polymorph(1); }
                                else if (animalChoice == 2) { target.Polymorph(2); }
                                else { target.Polymorph(3); }
                                target.SetPolyNumber(animalChoice);
                                Console.WriteLine(previousName + " was turned into a " + target.GetName());
                                _mana -= 25;
                            }
                            else
                            {
                                Console.WriteLine(_name + "'s spell fizzled out before it was even conjured!");
                            }
                        }
                        break;
                    }
            }
        }
        public override void BlindAttack(Entity target) //50% chance to hit target for 50% more damage;
        {
            float HitChance = GenerateNumber(1, 10);
            if (HitChance >= 5)
            {
                //50% chance of hitting for 50% more damage
                float damage = (_baseDamage + inventory[1].GetDamageBoost() + inventory[2].GetDamageBoost() + inventory[0].GetDamageBoost()) * .5f + _baseDamage;
                target.TakeDamage(damage);
                Console.WriteLine(_name + " hit " + target.GetName() + " for " + damage + " damage!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(false);
            }
            else
            {
                Console.WriteLine(_name + " missed!\nPress any key to continue");
                Console.ReadKey(false);
            }
        }
        public override void PrintStats() //Prints players stats
        {
            float outputDamage = _baseDamage + inventory[1].GetDamageBoost() + inventory[2].GetDamageBoost() + inventory[0].GetDamageBoost();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(_name + "'s stats:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(_health + "/" + _maxHealth + " health remaining");
            if (_hasMana == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(_mana + " mana remaining");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total output damage " + outputDamage);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Level " + _level);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(_experience + "/100 experience");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(_gold + " total gold");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private char GetInput(string option1, string option2, string option3, string option4, string query) // prints a message, takes in 3 choices, and returns the choice as a char
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            char input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4') //repeat the question while the input is not something useable 
            {
                input = Console.ReadKey(false).KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return input;
        }
        public void GoldEarned(int goldearned) //Takes in an int then adds to player gold
        {
            _gold += goldearned;
        }
        public void HealFromRest(int healthHealed) //heals the player for specific amount;
        {
            _health += healthHealed;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
            Console.WriteLine("You just healed for a total of " + _health + "/" + _maxHealth + " total health!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(false);
        }
        public void ManaFromRest(int manaVal)
        {
            _mana += manaVal;
            if (_mana > _maxMana)
            {
                _mana = _maxMana;
            }
            Console.WriteLine("You just regened for a total of " + _mana + "/" + _maxMana + " total mana!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(false);
        }
        public void UpdateMaxHealth() // updates max health to the the base health plus all items healthboost;
        {
            _maxHealth += inventory[0].GetHealthBoost() + inventory[1].GetHealthBoost() + inventory[2].GetHealthBoost();
        }
        public virtual void Save(StreamWriter writer) // saves important player data
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_baseDamage);
            writer.WriteLine(_level);
            writer.WriteLine(_experience);
            writer.WriteLine(_gold);
            writer.WriteLine(_maxHealth);
            for (int i = 0; i < inventory.Length; i++)
            {
                writer.WriteLine(inventory[i].GetName());
                writer.WriteLine(inventory[i].GetValue());
                writer.WriteLine(inventory[i].GetDamageBoost());
                writer.WriteLine(inventory[i].GetHealthBoost());
            }
        }
        public virtual bool Load(StreamReader reader) //loads important player data
        {
            string name = reader.ReadLine();
            float health = 0;
            float baseDamage = 0;
            int level = 0;
            float exp = 0;
            int gold = 0;
            float maxhealth = 0;
            int item1Value;
            float item1damage;
            float item1health;
            int item2Value;
            float item2damage;
            float item2health;
            int item3Value;
            float item3damage;
            float item3health;
            if (float.TryParse(reader.ReadLine(), out health) == false) // Tryparse converts the string text to a float here and prints out a health value
            {
                return false;                                          //if Tryparse is unable to convert, then the save must be corrupt
            }
            if (float.TryParse(reader.ReadLine(), out baseDamage) == false) //
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out level) == false)// Tryparse converts the string text to a int here
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out exp) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out gold) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out maxhealth) == false)
            {
                return false;
            }
            string item1name = reader.ReadLine();
            if (int.TryParse(reader.ReadLine(), out item1Value) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item1damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item1health) == false)
            {
                return false;
            }
            string item2name = reader.ReadLine();
            if (int.TryParse(reader.ReadLine(), out item2Value) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item2damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item2health) == false)
            {
                return false;
            }
            string item3name = reader.ReadLine();
            if (int.TryParse(reader.ReadLine(), out item3Value) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item3damage) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out item3health) == false)
            {
                return false;
            }
            _name = name;
            _health = health;
            _baseDamage = baseDamage;
            _level = level;
            _experience = exp;
            _gold = gold;
            _maxHealth = maxhealth;
            inventory[0] = new Items(item1name, item1health, item1damage, item1Value);
            inventory[1] = new Items(item2name, item2health, item2damage, item2Value);
            inventory[2] = new Items(item3name, item3health, item3damage, item3Value);
            return true;
        }
    }
}
