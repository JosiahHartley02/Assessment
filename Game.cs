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
            ControlIntro();
            MainMenu();
            if (_useOldSave == false)
            {
                ChooseCharacter();
                Introduction();
                FarEndOfThePit();
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
            Console.Clear();
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

        private void Introduction()
        {
            //small bit of plot introduced
            Console.Clear();
            Console.WriteLine(player.GetName() + ": You wake up in a pit of the infected bodies of Castle Snositi");
            Console.WriteLine("Around you is nothing but inanimate bodies smelling of rotten flesh, the pit is nothing more than\n" +
                "a divet in the Earth around you.");
            //castle wall no let them in because of plague
            char input = GetInput("Go to castle wall", "Go to far end of the pit", "You notice only two real places to go");
            while (input != '2')
            {
                Console.Clear();
                Console.WriteLine(player.GetName() + ": You approace the great stone wall, its significantly larger than you,\n" +
                    "and appears to still be guarded, you get the feeling you're not invited back in.");
                Console.WriteLine("Press 2 to return to the pit");
                input = Console.ReadKey().KeyChar;
                if (input != '2')
                {
                    Console.WriteLine("just press 2");
                    Console.WriteLine("but press any key to try again");
                    Console.ReadKey();
                }
                break;
            }
        }
        private void TestForSaves()
        {
            //Could be a bool but i prefer this, allows me to either introduce new players to the game or allow
            //old players to continue at the campfire where they left off.
            Console.WriteLine("Hello and welcome to a zombie based pvp grinding game! Please select and option from below");
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
        private void ControlIntro()
        {
            //should help clear up any problem that any player has with maybe being completely inept
            Console.WriteLine("This game consists of very few controls, use numpad or number row to\n" +
                "select options, if you enter an invalid option you will be told, often you may be prompted\n" +
                "to press any key to continue, please read each screen thouroughly before deciding");
            Console.WriteLine("\n\n\nPress any key to continue!");
            Console.ReadKey();
        }

        //This is used to get a simple 1 or 2 char from a 2 answer question
        private char GetInput(string option1, string option2, string query)
        {
            Console.WriteLine(query);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            char input = ' ';
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                    case '2':
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
            return input;
        }
        private void FarEndOfThePit()
        {
            Console.Clear();
            Console.WriteLine(player.GetName() + ": upon arriving at the far end of the gate, you notice an undead peasant\n" +
                "just standing there. But unfortunately it notices you and begins to approach quickly\n" +
                "Press any key to begin battle introduction");
            Console.ReadKey();

        }
    }
}
