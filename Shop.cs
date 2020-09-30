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
        public Shop(Items item1, Items item2, Items item3)
        {
            _totalCash = 100;
            _shopName = "KwikiMart";
            _shopClerkName = "Apu Nahasapeemapetilon";
            _inventory[0] = item1;
            _inventory[1] = item2;
            _inventory[2] = item3;
        }
        public void SellItem(int itemchoice)
        {
            _totalCash += _inventory[itemchoice].GetValue();
        }
        public void BuyItem(int itemchoice)
        {
            _totalCash -= _inventory[itemchoice].GetValue();
        }
    }
}
