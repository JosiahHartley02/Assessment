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
        
        //Common item used for selling only
        public Items()
        {
            _name = "Junk";
            _healthBoost = 0;
            _damageBoost = 0;
            _value = 1;
        }
        //Good Items used for actual use
        public Items(string nameVal, float healthBoostVal, float damageBoostVal, int valueVal)
        {
            _name = nameVal;
            _healthBoost = healthBoostVal;
            _damageBoost = damageBoostVal;
            _value = valueVal;
        }
        //PlaceHolder for inventories
        public Items(bool EmptySlot)
        {
            _name = "Empty Slot";
            _value = 0;
            _healthBoost = 0;
            _damageBoost = 0;
        }
        public string GetName()
        {
            return _name;
        }
        public int GetValue()
        {
            return _value;
        }
        public float GetDamageBoost()
        {
            return _damageBoost;
        }
        public float GetHealthBoost()
        {
            return _healthBoost;
        }
    }
}
