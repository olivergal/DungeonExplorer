using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        //public getters
        public string Name => name;
        public int Health => health;

        //adds item to player inventory
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        //returns contents of player inventory
        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
        }

        //checks player has items
        public bool HasItem()
        {
            return inventory.Count > 0;
        }

        //gets first item in inventory 
        public string GetItem()
        {
            return inventory.Count > 0 ? inventory[0] : "None";
        }
    }
}
