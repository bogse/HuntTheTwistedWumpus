using GameServer.Caverns;
using GameServer.Connection;
using GameServer.Players;

namespace GameServer
{
    public class GameManager
    {
        public void InitGameManager()
        {
            IRoom room1 = new Room("Room1");
            IRoom room2 = new Room("Room2");

            IConnection connection;
            
            Player player = new Player(room1);
        }
    }
}
