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
            Console.WriteLine("Hello and welcome! Please select and option from below using\n" +
                "either the numpad or number row!");
            GetInput("New Game", "Continue Game");

        }
        void GetInput(string option1, string option2)
        {
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);
            char input = Console.ReadKey().KeyChar;
        }
    }
}
