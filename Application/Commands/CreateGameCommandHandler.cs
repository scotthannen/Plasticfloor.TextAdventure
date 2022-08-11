using Domain;

namespace Application.Commands
{
    public class CreateGameCommandHandler : ICommandHandler<CreateGameCommand>
    {
        private readonly IGameRepository _gameRepository;

        public CreateGameCommandHandler(IGameRepository gameRepository) => this._gameRepository = gameRepository;

        public async Task<ActionResponse> Handle(CreateGameCommand command)
        {
            Game game = new Game() { Id = command.GameId };
            this.BuildGame(game);
            await this._gameRepository.SaveGame(game);
            ActionResponse actionResponse = ActionResponse.Ok();
            game = (Game)null;
            return actionResponse;
        }

        private void BuildGame(Game game)
        {
            Location location1 = new Location()
            {
                Name = "Foyer"
            };
            Location location2 = new Location()
            {
                Name = "Bedroom"
            };
            Location location3 = new Location()
            {
                Name = "Living room"
            };
            Location location4 = new Location()
            {
                Name = "Kitchen"
            };
            Location location5 = new Location()
            {
                Name = "Bathroom"
            };
            game.Locations.AddRange((IEnumerable<Location>)new Location[5]
            {
        location1,
        location2,
        location3,
        location4,
        location5
            });
            location1.Exits.Add(new Exit()
            {
                Direction = ExitDirection.South,
                Destination = location3
            });
            location2.Exits.Add(new Exit()
            {
                Direction = ExitDirection.East,
                Destination = location3
            });
            location2.Exits.Add(new Exit()
            {
                Direction = ExitDirection.South,
                Destination = location5
            });
            location3.Exits.Add(new Exit()
            {
                Direction = ExitDirection.West,
                Destination = location2
            });
            location3.Exits.Add(new Exit()
            {
                Direction = ExitDirection.East,
                Destination = location4
            });
            location4.Exits.Add(new Exit()
            {
                Direction = ExitDirection.West,
                Destination = location3
            });
            location5.Exits.Add(new Exit()
            {
                Direction = ExitDirection.North,
                Destination = location2
            });
            game.PlayerLocation = location1;
        }
    }
}
