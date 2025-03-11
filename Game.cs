using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            //initialize game
            player = new Player("Hero", 100);
            currentRoom = new Room("The Dark Dungeon", "Old Sword");
        }

        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine($"Player: {player.Name} | Health: {player.Health}");
                Console.WriteLine("Inventory: " + player.InventoryContents());

                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Quit game");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (currentRoom.GetItem() != "No item in this room.")
                        {
                            player.PickUpItem(currentRoom.GetItem());
                            Console.WriteLine($"You picked up: {currentRoom.GetItem()}");
                            currentRoom.PickUpItem();
                        }
                        else
                        {
                            Console.WriteLine("There is no item to pick up.");
                        }
                        break;
                    case "2":
                        playing = false;
                        Console.WriteLine("Game Over. Thanks for playing!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                        break;
                }
            }
        }
    }
}
