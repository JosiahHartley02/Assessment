using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy:Entity
    {
        private bool _isUndead;
        private float _maxHealth; 
        //base constructor for average enemy
        public Enemy(string nameVal, int levelVal)
        {
            _name = nameVal;
            _level = levelVal;
            _baseDamage = 100;
            //generates a float between 0 and 2 to either weaken or increase level affect
            //multiplied by average enemy base health.
            _health = (GenerateNumber(0, 2) * levelVal) * 50;
            //if health ends up being 0 the entity is reborn stronger as an easter egg thing
            if (GetHealth() == 0)
            {
                _health = 80;
                _name ="VengeFul " + nameVal;
                _baseDamage = 10;
            }
            _maxHealth = _health;
        }
        private void ResetEnemy()
        {
            _health = _maxHealth;
        }
    }
}
