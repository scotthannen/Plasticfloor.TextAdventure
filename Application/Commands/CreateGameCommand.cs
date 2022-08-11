using System;

namespace Application.Commands
{
    public class CreateGameCommand : GameCommand
    {
        public CreateGameCommand(Guid gameId)
          : base(gameId)
        {
        }
    }
}
