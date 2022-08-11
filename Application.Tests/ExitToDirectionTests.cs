using Application.Commands;
using Domain;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests
{
    public class ExitToDirectionTests
    {
        private readonly FakeGameRepository _gameRepository;
        private readonly ExitToDirectionCommandHandler _subject;
        private readonly Guid _gameId = Guid.NewGuid();

        public ExitToDirectionTests()
        {
            this._gameRepository = new FakeGameRepository();
            this._subject = new ExitToDirectionCommandHandler((IGameRepository)this._gameRepository);
        }

        [Fact]
        public async Task Exiting_To_Valid_Direction_Moves_Player()
        {
            await this.SetupGame();
            ExitToDirectionCommand command = new ExitToDirectionCommand(this._gameId, ExitDirection.South);
            ActionResponse result = await this._subject.Handle(command);
            Assert.True(result.Success);
            Game game = await this._gameRepository.LoadGame(this._gameId);
            Assert.Equal("South room", game.PlayerLocation.Name);
        }

        [Fact]
        public async Task Exiting_To_Invalid_Direction_Fails()
        {
            await this.SetupGame();
            ExitToDirectionCommand command = new ExitToDirectionCommand(this._gameId, ExitDirection.North);
            ActionResponse result = await this._subject.Handle(command);
            Assert.False(result.Success);
            Game game = await this._gameRepository.LoadGame(this._gameId);
            Assert.Equal("North room", game.PlayerLocation.Name);
        }

        private async Task SetupGame()
        {
            Game game = new Game() { Id = this._gameId };
            Location northRoom = new Location()
            {
                Name = "North room"
            };
            Location southRoom = new Location()
            {
                Name = "South room"
            };
            northRoom.Exits.Add(new Exit()
            {
                Direction = ExitDirection.South,
                Destination = southRoom
            });
            game.Locations.Add(northRoom);
            game.Locations.Add(southRoom);
            game.PlayerLocation = northRoom;
            await this._gameRepository.SaveGame(game);
        }
    }
}
