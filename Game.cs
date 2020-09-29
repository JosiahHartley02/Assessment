using System;
using System.Collections.Generic;
using System.IO;
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
            if (_useOldSave == true)
            {
                ChooseCharacter();
            }

        }

        //Repeated until the game ends
        public void Update()
        {

        }

        //Performed once when the game ends
        public void End()
        {

        }
        //Allows user to select one of 4 characters each with defining features
        private void ChooseCharacter()
        {
            Console.Clear();
            Console.WriteLine("Please select a character from below!");
            Console.WriteLine("1. Mouse Man, thief of the night\n2. Merlin" +
                "master of the arcane arts\n3. WolfGang deaf musical bard\n.4 " +
                "Professer Eisenburg raiser of the dead");
            char input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        player = new Player(1);
                        break;
                    case '2':
                        player = new Player(2);
                        break;
                    case '3':
                        player = new Player(3);
                        break;
                    case '4':
                        break;
                    default:
                        Console.WriteLine("Error please select a valid input");
                        break;
                }
            }
        }
        private void MainMenu()
        {
            Console.Clear();
            TestForSaves();
            if (_useOldSave == false)
            {
                Console.Clear();
            }
            else if (_useOldSave == true)
            {
                Console.Clear();
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
