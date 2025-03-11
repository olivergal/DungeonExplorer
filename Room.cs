namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string item;

        public Room(string description, string item = null)
        {
            this.description = description;
            this.item = item;
        }

        //getter 
        public string GetDescription()
        {
            return description;
        }

        //getter 
        public string GetItem()
        {
            return item ?? "No item in this room.";
        }

        //allows picking up item 
        public void PickUpItem()
        {
            item = null;
        }
    }
}
