using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        private Items junk = new Items();
        private Items EmptySlot = new Items(true);
        private Player player = new Player();
        private bool _gameOver = false;
        private bool _useOldSave;
        //Run the game
        public void Run()
        {
            Start();
            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        //Performed once when the game begins
        public void Start()
        {
            MainMenu();
        }

        //Repeated until the game ends
        public void Update()
        {

        }

        //Performed once when the game ends
        public void End()
        {

        }
        private void ChooseCharacter()
        {
            Console.Clear();
            Console.WriteLine("Please select a character from below!");
        }
        private void MainMenu()
        {
            Console.Clear();
            TestForSaves();
            if (_useOldSave == false)
            {
                
            }
            else if (_useOldSave == true)
            {

            }

        }

        private void TestForSaves()
        {
            Console.WriteLine("Hello and welcome! Please select and option from below using\n" +
                "either the numpad or number row!");
            char input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine("1. New Game");
                Console.WriteLine("2. Load Game");
                input = Console.ReadKey().KeyChar;
                if (input == '1')
                {
                    _useOldSave = false;
                }
                else if (input == '2')
                {
                   _useOldSave = true;
                }
                else
                {
                    Console.WriteLine("Error Invalid Option");
                }                
            }
        }
    }
}
