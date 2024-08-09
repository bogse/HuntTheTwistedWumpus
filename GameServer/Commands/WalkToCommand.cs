using GameServer.Caverns;
using GameServer.Players;

namespace GameServer.Commands
{
    public class WalkToCommand : ICommand
    {
        public const string Name = "Walk to room";
        private IRoom _room;

        public WalkToCommand(IRoom room)
        {
            _room = room;
        }

        private void MovePlayerToRoom(Player? player)
        {
            if (player == null)
                return;

            player.SetCurrentRoom(_room);
        }

        public void Execute(object player)
        {
            MovePlayerToRoom((player as Player));
        }
    }
}
