using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        //setting Items = to new item is initializing them then and there no need for InitItems function
        private Items _junk = new Items();
        public Items _EmptySlot = new Items(true);
        private Items _damageNecklace = new Items("Necklace of Harm", 0, 2, 10);
        private Items _healthPot = new Items("Potion of increase health", 25, 0, 5);
        private Player _player; //player declared but not defined to allow user to choose character later in code
        private Enemy _enemyZombie = new Enemy("Zombie", 1);
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
                if (_gameOver == false)
                {
                    MeetTheCamp();
                }
            }
            else if (_useOldSave == true)
            {
                //Put load function here
            }
        }

        //Repeated until the game ends
        public void Update()
        {
            CampLife();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing my game!");
        }
        //Allows user to select one of 4 characters each with defining features
        private void ChooseCharacter()
        {
            Console.Clear();
            Console.WriteLine("Please select a character from below!");
            Console.WriteLine("1. Mouse Man, thief of the night\n2. Merlin" +
                " master of the arcane arts\n3. WolfGang deaf musical bard\n.4 " +
                "Professer Eisenburg raiser of the dead");
            char input = ' ';
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        _player = new Player(1);
                        break;
                    case '2':
                        _player = new Player(2);
                        break;
                    case '3':
                        _player = new Player(3);
                        break;
                    case '4':
                        _player = new Player(4);
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
            Console.WriteLine(_player.GetName() + ": You wake up in a pit of the infected bodies of Castle Snositi");
            Console.WriteLine("Around you is nothing but inanimate bodies smelling of rotten flesh, the pit is nothing more than\n" +
                "a divet in the Earth around you.");
            //castle wall no let them in because of plague
            char input = GetInput("Go to castle wall", "Go to far end of the pit", "You notice only two real places to go");
            while (input != '2')
            {
                Console.Clear();
                Console.WriteLine(_player.GetName() + ": You approace the great stone wall, its significantly larger than you,\n" +
                    "and appears to still be guarded, you get the feeling you're not invited back in.");
                Console.WriteLine("Press 2 to go to the far end of the pit");
                input = Console.ReadKey().KeyChar;
                if (input != '2')
                {
                    Console.WriteLine("just press 2");
                    Console.WriteLine("but press any key to try again");
                    Console.ReadKey();
                }
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

        
        private void FarEndOfThePit()
        {
            Console.Clear();
            Console.WriteLine(_player.GetName() + ": upon arriving at the far end of the gate, you notice an undead peasant\n" +
                "just standing there. But unfortunately it notices you and begins to approach quickly\n" +
                "Press any key  begin battle introduction");
            Console.ReadKey();
            BattleLoop(_player,_enemyZombie);
        }
        private void BattleLoop(Entity player, Entity enemy)
        {
            //test for both players being alive
            while(player.GetHealth() > 0 && enemy.GetHealth() > 0)
            {
                Console.Clear();
                player.PrintStats();
                Console.WriteLine();
                enemy.PrintStats();
                //makes sure player is alive before attacking
                if (player.GetHealth() > 0)
                {
                    char input = GetInput("Attack soft yet sure", "Attack hard yet blind", "What move will you choose?");
                    if (input == '1')
                    {
                        player.Attack(player, enemy);
                    }
                    else if (input == '2')
                    {
                        player.BlindAttack(player, enemy);
                    }
                }
                //makes sure enemy is alive before attacking
                if (enemy.GetHealth() > 0 )
                {
                    //adds "ai" in the sense that attacks are randomized
                    float EnemyChoice = GenerateNumber(1, 10);
                    if (EnemyChoice >= 6)
                    {
                        enemy.Attack(enemy, player);
                    }
                    else if (EnemyChoice == 5)
                    {
                        //i thought it would be cool to have a chance for nothing to happen
                        Console.WriteLine(enemy.GetName() + " doesn't seem interested");
                        Console.ReadKey();
                    }
                    else
                    {
                        enemy.BlindAttack(enemy, player);
                    }
                }
            }
            if(player.GetHealth() > 0)
            {
                //after battle if player was the last alive they gain experience
                Console.WriteLine("You gained " + player.GainExperience(enemy) + " experience!");
                //after battle the enemy may drop an item
                int lootchance = GenerateNumber(1, 5, true);
                switch (lootchance)
                {
                    case 1:
                    case 2://case 1 and 2 will yeild nothing found
                        Console.WriteLine("Unfortunately " + _enemyZombie.GetName() + " dropped nothing!");
                            break;
                    case 3://case 3 will drop a "junk"

                    case 4: //case 4 will drop damage increase necklace

                        break;
                    case 5: //case 5 will drop health increase potion

                        break;
                    
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                if (_player.GetExperience() >= 100)
                {
                    _player.LevelUP();
                }
                player.PrintStats();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
            else if(enemy.GetHealth() > 0)
            {
                Death();
            }
        }
        //takes in min and max to make generating numbers easy and variables non permanent
        //i really like this function
        public float GenerateNumber(int min, int max)
        {
            Random r = new Random();
            float number = r.Next(min, max);
            return number;
        }
        public int GenerateNumber(int min, int max, bool integer)
        {
            Random r = new Random();
            int number = r.Next(min, max);
            return number;
        }
        public void Death()
        {
            Console.Clear();
            Console.WriteLine("You have succumbed to that of a fungi, neither alive nor dead \n" +
                    "forever growing and forever rotting, but what is death to someone whos never lived?");
            Console.WriteLine("Final Stats");
            _player.PrintStats();
            Console.WriteLine("Press any key to continue");
            _gameOver = true;
            Console.ReadKey();
        }
        
        private void MeetTheCamp() // just dialogue and background info
        {
            Console.Clear();
            Console.WriteLine(_player.GetName() + " has defeated " + _enemyZombie.GetName() + "!");
            Console.WriteLine("You notice a young girl has been watching the whole time from just beyond a few shrubs\n" +
                "she urges you to follow.\n Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(_player.GetName() + " follows the young girl into the woods for what seems like only a few minutes");
            Console.WriteLine("She suddenly stops near a clearing revealing a small society embedded deep in the woods.");
            Console.WriteLine("Press any key to continue to the center");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Once you are positioned near the center camp fire, the girl explains that this is a refugee camp for \n" +
                "those like you who have been kicked from the castle. This is your new home for the forseeable future");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        private void CampLife()
        {
            while (_gameOver == false)
            {
                char input = GetInput("Camp Shop", "Camp Rest Area", "Camp camp fire", "Wilderness Scavenge", "What will you do for now?");
                switch (input)
                {
                    case '1':
                        CampShop();
                        break;
                    case '2':
                        RestArea();
                        break;
                    case '3':
                        CampFire();
                        break;
                    case '4':
                        FightWildLife();
                        break;
                }
            }
        }
        private void CampShop()
        {
            Console.Clear();
        }
        private void RestArea()
        {

        }
        private void CampFire()
        {

        }
        private void FightWildLife()
        {

        }
        private char GetInput(string option1, string option2, string option3, string option4, string query) //gets either 1 2 3 or 4 as a char input and prints a query
        {
            char input = ' ';
            Console.WriteLine(query);

            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option1);
            Console.WriteLine("3. " + option1);
            Console.WriteLine("4. " + option1);
            while (input != '1' && input != '2' && input != '3' && input != '4')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3' && input != '4')
                {
                    Console.WriteLine("Please select a valid option");
                }
            }
            return input;
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
    }
}
