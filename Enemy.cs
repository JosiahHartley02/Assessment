using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy:Entity
    {
        private bool _isReborn;
        public Enemy(int numberVal)//base constructor for average enemy
        {
            _isReborn = false;
            switch(numberVal)
            {
                case 1:
                    _name = "Zombie";
                    _level = GenerateNumber(1,3, true);
                    _baseDamage = 10;
                    _health = (GenerateNumber(0, 2) * _level) * 50;//generates a float between 0 and 2 to either weaken or increase level affect
                    break;                                         //multiplied by average enemy base health
                case 2:
                    _name = "Giant Spider";
                    _level = GenerateNumber(1, 3, true);
                    _baseDamage = 5;
                    _health = (GenerateNumber(0, 2) * _level) * 50;
                    break;
                case 3:
                    _name = "Castle Mage";
                    _level = GenerateNumber(1, 3, true);
                    _baseDamage = 5;
                    _hasMana = true;
                    _mana = 50;
                    _health = (GenerateNumber(0, 2) * _level) * 50;
                    break;
                case 4:
                    _name = "Swamp Monster";
                    _level = GenerateNumber(0, 5, true);
                    _baseDamage = 5;
                    _health = (GenerateNumber(0, 2) * _level) * (GenerateNumber(0,50,true));
                    break;
            }
            if (_health == 0)//if health ends up being 0 the entity is reborn stronger as an easter egg thing
            {
                _health += 30;
                _name = "VengeFul " + _name;
                _baseDamage += 6;
                _isReborn = true;
            }
        }
    }
}
