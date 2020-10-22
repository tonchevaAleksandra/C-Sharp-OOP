using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
   public class Department
    {
        private const int MAX_CAPACITY = 3;
        private readonly List<Room> rooms;
      
        public string Name { get; }

        private Department()
        {
            this.rooms = new List<Room>();
            this.InitiazileRooms();
        }
        public Department(string name): this()
        {
            this.Name = name;
        }
        public IReadOnlyCollection<Room> Rooms => this.rooms;

        private void InitiazileRooms()
        {
            for (byte i = 1; i <= 20; i++)
            {
                this.rooms.Add(new Room(i));
            }
        }
        public Room GetFirstFreeRoom()
        {
            return this.rooms.First(rooms => rooms.Count < MAX_CAPACITY);
        }
  
    }
}
