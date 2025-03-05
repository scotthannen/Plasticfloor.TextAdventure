using Domain;
using System;

namespace Application.Commands
{
    public class ExitToDirectionCommand : GameCommand
    {
        public ExitToDirectionCommand(Guid gameId, ExitDirection direction)
          : base(gameId)
          => Direction = direction;

        public ExitDirection Direction { get; set; }
    }
}
