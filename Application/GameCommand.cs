using System;

namespace Application
{
    public abstract class GameCommand : ICommand
    {
        protected GameCommand(Guid gameId) => this.GameId = gameId;

        public Guid GameId { get; }
    }
}
