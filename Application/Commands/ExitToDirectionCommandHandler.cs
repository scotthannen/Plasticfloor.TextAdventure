using Domain;

namespace Application.Commands
{
    public class ExitToDirectionCommandHandler : ICommandHandler<ExitToDirectionCommand>
    {
        private readonly IGameRepository _gameRepository;

        public ExitToDirectionCommandHandler(IGameRepository gameRepository) => this._gameRepository = gameRepository;

        public async Task<ActionResponse> Handle(ExitToDirectionCommand command)
        {
            Game game = await this._gameRepository.LoadGame(command.GameId);
            Exit exit1 = game.PlayerLocation.Exits.SingleOrDefault<Exit>((Func<Exit, bool>)(exit => exit.Direction == command.Direction));
            if (exit1 == null)
                return ActionResponse.Fail("You can't go that way.");
            game.PlayerLocation = exit1.Destination;
            await this._gameRepository.SaveGame(game);
            return ActionResponse.Ok();
        }
    }
}
