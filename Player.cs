using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Player : Entity
    {
        private int _gold;
        public Items _EmptySlot = new Items(true);
        private Items[] inventory = new Items[3];
        //base constructor
        public Player()
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
                    //Mouseman is a thief that what he lacks in combat makes up for in increased loot potential
                    _name = "Mouse Man";
                    _baseDamage = 5;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 2:
                    //Merlin is a wizard that what he lacks in loot potential makes up for with damage
                    _name = "Merlin";
                    _baseDamage = 15;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _mana = 50;
                    _hasMana = true;
                    break;
                case 3:
                    //WolfGang is a deaf musician who uses horrible music to deal damage, nothing stands out
                    _name = "WolfGang";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 4:
                    //Eisenburg is a necromancer that can steal life from the undead
                    _name = "Proffessor Eisenburg";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _level = 0;
                    _hasMana = false;
                    break;
            }
            _gold = 0;
            InitInventory(); // sets every slot in inventory array to Item Empty slot as a place holder.
        }
        private void InitInventory()//allows me to not get a null error
        {
            for (int i = 0; i < inventory.Length; i++) // for however many positions in an array, declares item "EmptySlot" in said position
            {
                inventory[i] = _EmptySlot;
            }
        }
        private void PrintInventory() // prints item names at each position in the inventory aray
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine(inventory[i].GetName());
            }
        }
        public void BuyItem(Shop shopname, int arrayPosition) //takes in a shop object and an int for the position in the array
        {
            if (shopname.GetValue(arrayPosition) <= _gold)//if player can afford then do this
            {
                shopname.SellItem(shopname.GetItem(arrayPosition)); //The shop increases its value by the value of the item in the
                EquipItem(shopname.GetItem(arrayPosition));
            }                                                     //shops inventory array at the desired position declared above
            else
            {
                Console.WriteLine("It appears that " + _name + " doesn't have enough gold for this");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
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
        public void EquipItem(Items itemname)
        {
            Console.Clear();
            Console.WriteLine("This will destroy any item in the slot, no givesie's backsie's");
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
                    Console.ReadKey();

                    break;
            }
        }
        public void PrintStats() //Prints players stats
        {
            Console.WriteLine(_name + "'s stats:");
            Console.WriteLine(_health + " health remaining");
            if (_hasMana == true)
            {
                Console.WriteLine(_mana + " mana remaining");
            }
            Console.WriteLine("Total output damage " + _baseDamage);
            Console.WriteLine("Level " + _level);
            Console.WriteLine(_experience + "/100 experience");
            Console.WriteLine(_gold + " total gold");
        }
        private char GetInput(string option1, string option2, string option3, string option4, string query) // prints a message, takes in 3 choices, and returns the choice as a char
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            Console.WriteLine("3. " + option3);
            Console.WriteLine("4. " + option4);
            char input = ' ';
            while (input != '1' && input != '2' && input != '3') //repeat the question while the input is not something useable 
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid input");
                }
            }
            return input;
        }
        public void HealFromRest(int healthHealed)
        {
            _health += healthHealed;
            Console.WriteLine("You just healed " + healthHealed + " for a total of " + _health + " total health!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        public virtual void Save(StreamWriter writer)
        {
            writer.WriteLine(_name);
            writer.WriteLine(_health);
            writer.WriteLine(_baseDamage);
            writer.WriteLine(_level);
            writer.WriteLine(_experience);
            writer.WriteLine(_gold);
            for (int i = 0; i < inventory.Length; i++)
            {
                writer.WriteLine(inventory[i].GetName());
                writer.WriteLine(inventory[i].GetValue());
                writer.WriteLine(inventory[i].GetDamageBoost());
                writer.WriteLine(inventory[i].GetHealthBoost());
            }
        }
        public virtual bool Load(StreamReader reader)
        {
            string name = reader.ReadLine();
            float health = 0;
            float baseDamage = 0;
            int level = 0;
            float exp = 0;
            int gold = 0;
            int item1Value;
            float item1damage;
            float item1health;
            int item2Value;
            float item2damage;
            float item2health;
            int item3Value;
            float item3damage;
            float item3health;
            if (float.TryParse(reader.ReadLine(), out health) == false)
            {
                return false;
            }
            if (float.TryParse(reader.ReadLine(), out baseDamage) == false)
            {
                return false;
            }
            if (int.TryParse(reader.ReadLine(), out level) == false)
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
            inventory[0] = new Items(item1name, item1health, item1damage, item1Value);
            inventory[1] = new Items(item2name, item2health, item2damage, item2Value);
            inventory[2] = new Items(item3name, item3health, item3damage, item3Value);
            return true;
        }

    }
}
