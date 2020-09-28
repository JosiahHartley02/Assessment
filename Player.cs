using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player:Entity
    {
        private int _mana;
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
                    _name = "MouseMan";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    break;
                case 2:
                    _name = "Merlin";
                    _baseDamage = 15;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    _mana = 50;
                    break;
                case 3:
                    _name = "WolfGang";
                    _baseDamage = 5;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    break;
                case 4:
                    _name = "Proffessor Eisenburg";
                    _baseDamage = 10;
                    _health = 100;
                    _experience = 0;
                    _isDead = false;
                    _level = 0;
                    break;
            }
        }
    }
}
