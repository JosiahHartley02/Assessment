using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class WildLife:Entity
    {
        public WildLife(int AnimalNumber)
        {
            _level = 5;
            _experience = 0;
            _baseDamage = 2;
            switch (AnimalNumber)
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
    }
}
