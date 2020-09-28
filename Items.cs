using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Items
    {
        private string _name;
        private float _healthBoost;
        private float _damageBoost;
        private int _value;
        
        public Items()
        {
            _name = "Junk";
            _healthBoost = 0;
            _damageBoost = 0;
            _value = 1;
        }
        public Items(string nameVal, float healthBoostVal, float damageBoostVal, int valueVal)
        {
            _name = nameVal;
            _healthBoost = healthBoostVal;
            _damageBoost = damageBoostVal;
            _value = valueVal;
        }
        public Items(bool EmptySlot)
        {
            _name = "EmptySlot";
            _value = 0;
            _healthBoost = 0;
            _damageBoost = 0;
        }
    }
}
