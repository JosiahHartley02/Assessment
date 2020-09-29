using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player:Entity
    {
        //base constructor
        public Player()
        {
            _name = "UnNammed";
            _baseDamage = 0;
            _health = 0;
            _experience = 0;
            _isDead = false;
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
                    _name = "MouseMan";
                    _baseDamage = 5;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 2:
                    //Merlin is a wizard that what he lacks in loot potential makes up for with damage
                    _name = "Merlin";
                    _baseDamage = 15;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
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
                    _isDead = false;
                    _level = 0;
                    _hasMana = false;
                    break;
                case 4:
                    //Eisenburg is a necromancer that can steal life from the undead
                    _name = "Proffessor Eisenburg";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    _hasMana = false;
                    break;
            }
        }
    }
}
