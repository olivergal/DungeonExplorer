using System;

namespace DungeonExplorer
{
    internal class Game
    {
        //private attributes
        private Player player;
        private Room currentRoom;
        private Room room1;
        private Room room2;
        private Room room3;

        public Game()
        {
            //initialize player
            player = new Player("Hero", 100);

            //initialize rooms
            room1 = new Room("The Dark Dungeon", "Old Sword");
            room2 = new Room("The Unknown Caverns", "Healing Potion", new Enemy("Goblin", 30, 10));
            room3 = new Room("Spire of Certain Oblivion", "Ancient Necklace", new Enemy("Zombie", 50, 15));

            //start game 
            currentRoom = room1;
        }

        public void Start()
        {
            bool playing = true;

            while (playing)
            {
                //display room description and player health
                Console.WriteLine(currentRoom.GetDescription() + Environment.NewLine);
                Console.WriteLine($"Player: {player.Name} | Health: {player.Health}");
                Console.WriteLine("Inventory: " + player.InventoryCount());
                Console.WriteLine(Environment.NewLine);

                if (currentRoom.Enemy != null)
                {
                    //enemy lines
                    Console.WriteLine($"You have found an enemy! : {currentRoom.Enemy.Name}");
                    Console.WriteLine("Do you want to fight or run?");
                    Console.WriteLine("1. Fight");
                    Console.WriteLine("2. Run");

                    string fightChoice = Console.ReadLine();

                    switch (fightChoice)
                    {
                        case "1":
                            FightEnemy(currentRoom.Enemy);
                            break;

                        case "2":
                            Console.WriteLine("You ran from the battle!" + Environment.NewLine);
                            break;

                        default:
                            Console.WriteLine("Invalid choice." + Environment.NewLine);
                            break;
                    }
                }
                //standard text
                Console.WriteLine("What would you like to do on your quest?");
                Console.WriteLine("1. Pick up item");
                Console.WriteLine("2. Move to another room");
                Console.WriteLine("3. Quit game");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (currentRoom.GetItem() != "No item in this room.")
                        {
                            player.PickUpItem(currentRoom.GetItem());
                            Console.WriteLine($"You picked up: {currentRoom.GetItem()}" + Environment.NewLine);
                            currentRoom.PickUpItem();
                        }
                        else
                        {
                            Console.WriteLine("There is no item to pick up." + Environment.NewLine);
                        }
                        break;

                    case "2":
                        //player can move rooms
                        Console.WriteLine("Which room would you like to go to?");
                        Console.WriteLine("1. The Dark Dungeon");
                        Console.WriteLine("2. The Unknown Caverns");
                        Console.WriteLine("3. Spire of Certain Oblivion");
                        string roomChoice = Console.ReadLine();

                        switch (roomChoice)
                        {
                            case "1":
                                currentRoom = room1;
                                break;
                            case "2":
                                currentRoom = room2;
                                break;
                            case "3":
                                currentRoom = room3;
                                break;
                            default:
                                Console.WriteLine("Invalid room choice." + Environment.NewLine);
                                break;
                        }
                        break;

                    case "3":
                        playing = false;
                        Console.WriteLine("Game Over!" + Environment.NewLine);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3." + Environment.NewLine);
                        break;
                }
            }
        }

        private void FightEnemy(Enemy enemy)
        {
            //fight initiation
            Console.WriteLine($"You are fighting {enemy.Name}!");
            Random random = new Random();
            while (!enemy.IsDead() && player.Health > 0)
            {
                //attacking enemy
                int playerDamage = random.Next(10, 20); 
                enemy.TakeDamage(playerDamage);
                Console.WriteLine($"You dealt {playerDamage} damage to {enemy.Name}. Enemy's health: {enemy.Health}");

                //attacking player
                if (!enemy.IsDead())
                {
                    player.TakeDamage(enemy.Damage);
                    Console.WriteLine($"The enemy attacked you! You took {enemy.Damage} damage. Your health: {player.Health}");
                }
            }
            //after enemy fight text
            if (enemy.IsDead())
            {
                Console.WriteLine($"You defeated {enemy.Name}!" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine($"You were defeated by {enemy.Name}..." + Environment.NewLine);
            }
        }
    }

    public class Enemy
    {
        //enemy attributes
        public string Name { get; }
        public int Health { get; private set; }
        public int Damage { get; }

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }
    }
}
