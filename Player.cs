using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        //private player attributes
        private string name;
        private int health;
        private List<string> inventory = new List<string>();

        //public player attributes
        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public string Name => name;
        public int Health => health;

        //pick up item public attribute
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        //whats in the inventory public attribute
        public string InventoryCount()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Empty";
        }

        //item to go to inventory public attribute
        public bool HasItem()
        {
            return inventory.Count > 0;
        }

        //get item public attribute
        public string GetItem()
        {
            return inventory.Count > 0 ? inventory[0] : "None";
        }

        //damage taken public attribute
        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
