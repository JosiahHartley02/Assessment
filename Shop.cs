using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _totalCash;
        private string _shopName;
        private string _shopClerkName;
        private Items[] _inventory = new Items[3];
        public Shop(Items item1, Items item2, Items item3) //only constructor needed, takes in 3 items for the shops permanent inventory
        {
            _totalCash = 100;
            _shopName = "KwikiMart";
            _shopClerkName = "Apu Nahasapeemapetilon";
            for(int i = 0; i < _inventory.Length; i ++)
            _inventory[0] = item1;
            _inventory[1] = item2;    //cant use a for loop here no way to specify differnt output without extra code
            _inventory[2] = item3;
        }
        private bool CanAfford(Items itemchoice) //used to see if shop can afford a specific item and returns a true or false
        {
            if (_totalCash >= itemchoice.GetValue()) // if the shops total cash is greater than or equal to the value of the item
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void PrintInventory()
        {
            for (int i = 0; i < _inventory.Length; i ++)
            {
                Console.WriteLine(_inventory[i].GetName());
            }
        }
        public Items GetItem(int arrayPosition)//displays ITEM at desired array position
        {
            return _inventory[arrayPosition]; //returns value of shops inventory at desired array position
        }
        public int GetValue(int arrayPosition)//displays ITEM value at desired array position
        {
            return _inventory[arrayPosition].GetValue(); // returns value of shops inventory value at desired array position
        }
        public void SellItem(Items itemchoice) // Sells an Item
        {
            _totalCash += itemchoice.GetValue(); //Shop sells an item for its value and increases shops total gold by value
        }
        public bool BuyItem(Items itemchoice) // Shop buys item from player inventory
        {
            if (CanAfford(itemchoice) == true) // checks if shop total gold is equal to or greater than the value of the item
            {
                _totalCash -= itemchoice.GetValue(); // shop loses money buying item from the player
                return true;
            }
            else                                    //if shop total money is less than to the value of the item
            {
                Console.WriteLine("Sorry but I simply can not afford it!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return false;
            }
        }
    }
}
