using Domain;

namespace Application.Commands;

public class TakeThingCommandHandler : ICommandHandler<TakeThingCommand>
{
    private readonly IGameRepository _gameRepository;

    public TakeThingCommandHandler(IGameRepository gameRepository)
    {
        this._gameRepository = gameRepository;
    }

    public async Task<ActionResponse> Handle(TakeThingCommand command)
    {
        Game game = await this._gameRepository.LoadGame(command.GameId);


        if (game.PlayerInventory.Contains(command.Thing))
        {
            return ActionResponse.Fail("You already have that!");
        }

        if (command.Thing.Location != game.PlayerLocation)
        {
            return ActionResponse.Fail("That's not here!");
        }

        if (!command.Thing.PlayerCanTake)
        {
            return ActionResponse.Fail("You can't take that!");
        }

        command.Thing.SetLocation(game.PlayerInventoryLocation);
        game.PlayerInventory.Add(command.Thing);
        //await this._gameRepository.SaveGame(game);
        return ActionResponse.Ok();
    }
}