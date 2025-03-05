using System;
using System.Threading.Tasks;
using Application.Commands;
using Domain;
using Xunit;

namespace Application.Tests;

public class TakeThingTests
{
    private readonly FakeGameRepository _gameRepository;
    private readonly TakeThingCommandHandler _subject;
    private readonly Guid _gameId = Guid.NewGuid();

    public TakeThingTests()
    {
        _gameRepository = new FakeGameRepository();
        _subject = new TakeThingCommandHandler((IGameRepository)_gameRepository);
    }

    [Fact]
    public async Task Take_Thing_Works()
    {
        await SetupGame();
        Game game = await _gameRepository.LoadGame(_gameId);
        game.PlayerLocation = game.Locations[0];
        var thingPickingUp = new Thing("Lamp", game.PlayerLocation, true);
        var command = new TakeThingCommand(_gameId, thingPickingUp);
        var result = await _subject.Handle(command);
        Assert.True(result.Success);
        Assert.Equal(thingPickingUp.Location, game.PlayerInventoryLocation);
        Assert.True(game.PlayerInventory.Contains(thingPickingUp));
    }

    [Fact]
    public async Task Cant_Take_What_You_Already_Have()
    {
        await SetupGame();
        Game game = await _gameRepository.LoadGame(_gameId);
        game.PlayerLocation = game.Locations[0];
        var thingPickingUp = new Thing("Lamp", game.PlayerInventoryLocation, true);
        game.PlayerInventory.Add(thingPickingUp);
        var command = new TakeThingCommand(_gameId, thingPickingUp);
        var result = await _subject.Handle(command);
        Assert.False(result.Success);
        Assert.True(result.FailureReason.Contains("already have"));
    }

    [Fact]
    public async Task Cant_Take_What_Isnt_Here()
    {
        await SetupGame();
        Game game = await _gameRepository.LoadGame(_gameId);
        // They are in different locations
        game.PlayerLocation = game.Locations[0];
        var thingPickingUp = new Thing("Lamp", game.Locations[1], true);
        var command = new TakeThingCommand(_gameId, thingPickingUp);
        var result = await _subject.Handle(command);
        Assert.False(result.Success);
        Assert.True(result.FailureReason.Contains("not here"));
    }

    [Fact]
    public async Task Cant_Take_What_Cant_Be_Picked_Up()
    {
        await SetupGame();
        Game game = await _gameRepository.LoadGame(_gameId);
        game.PlayerLocation = game.Locations[0];
        var thingPickingUp = new Thing("Lamp", game.PlayerLocation, false);
        var command = new TakeThingCommand(_gameId, thingPickingUp);
        var result = await _subject.Handle(command);
        Assert.False(result.Success);
        Assert.True(result.FailureReason.Contains("can't take"));
    }

    private async Task SetupGame()
    {
        Game game = new Game() { Id = _gameId };
        Location northRoom = new Location()
        {
            Name = "North room"
        };
        Location southRoom = new Location()
        {
            Name = "South room"
        };
        game.Locations.Add(northRoom);
        game.Locations.Add(southRoom);
        await _gameRepository.SaveGame(game);
    }
}