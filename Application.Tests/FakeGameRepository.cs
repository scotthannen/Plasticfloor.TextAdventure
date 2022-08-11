using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Tests
{
    public class FakeGameRepository : IGameRepository
    {
        private readonly Dictionary<Guid, Game> _games;

        public FakeGameRepository() => this._games = new Dictionary<Guid, Game>();

        public async Task<Game> LoadGame(Guid gameId) => this._games.ContainsKey(gameId) ? this._games[gameId] : (Game)null;

        public async Task SaveGame(Game game) => this._games[game.Id] = game;
    }
}
