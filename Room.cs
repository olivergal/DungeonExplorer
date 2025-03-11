namespace DungeonExplorer
{
    public class Room
    {
        //private room attributes
        private string description;
        private string item;
        public Enemy Enemy { get; }

        public Room(string description, string item = null, Enemy enemy = null)
        {
            this.description = description;
            this.item = item;
            this.Enemy = enemy;
        }

        //room discription public attribute
        public string GetDescription()
        {
            return description;
        }

        //get item public attribute
        public string GetItem()
        {
            return item ?? "No item this room.";
        }

        //pick up item public attribute
        public void PickUpItem()
        {
            item = null;
        }
    }
}
