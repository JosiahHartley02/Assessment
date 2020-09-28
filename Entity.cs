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
        protected bool _isDead;
        //template constructor
        public Entity()
        {
            _name = "Template";
            _health = 1;
            _baseDamage = 0;
            _level = 0;
            _experience = 0;
            _isDead = false;
        }
        //base constructor entended for important enemy
        Entity(string nameVal, float healthVal, float damageVal, int levelVal)
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _level = levelVal;
            _isDead = false;
        }
        
        //takes in min and max to make generating numbers easy and variables non permanent
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
        
        public float GetBaseDamage()
        {
            return _baseDamage;
        }
       
        public float GetHealth()
        {
            return _health;
        }
    }
}
