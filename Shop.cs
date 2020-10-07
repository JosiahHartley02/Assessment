using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _totalGold;
        private string _shopName;
        private string _shopClerkName;
        private Items[] _inventory = new Items[3];
        public Shop() //only constructor needed, takes in 3 items for the shops permanent inventory
        {
            _totalGold = 100;
            _shopName = "KwikiMart";
            _shopClerkName = "Apu Nahasapeemapetilon";
        }
        private bool CanAfford(Items itemchoice) //used to see if shop can afford a specific item and returns a true or false
        {
            if (_totalGold >= itemchoice.GetValue()) // if the shops total cash is greater than or equal to the value of the item
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
            _totalGold += itemchoice.GetValue(); //Shop sells an item for its value and increases shops total gold by value
        }
        public bool BuyItem(Items itemchoice) // Shop buys item from player inventory
        {
            if (CanAfford(itemchoice) == true) // checks if shop total gold is equal to or greater than the value of the item
            {
                _totalGold -= itemchoice.GetValue(); // shop loses money buying item from the player
                return true;
            }
            else                                    //if shop total money is less than to the value of the item
            {
                Console.WriteLine("Sorry but I simply can not afford it!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                return false;
            }
        }
        public void SetItem(Items itemname, int arrayPostion)
        {
            _inventory[arrayPostion] = itemname;
        }
        public string GetName()
        {
            return _shopName;
        }
        public int GetGold()
        {
            return _totalGold;
        }
    }
}
