using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Tests
{
    public class FakeGameRepository : IGameRepository
    {
        private readonly Dictionary<Guid, Game> _games;

        public FakeGameRepository() => _games = new Dictionary<Guid, Game>();

        public async Task<Game> LoadGame(Guid gameId) => _games.ContainsKey(gameId) ? _games[gameId] : (Game)null;

        public async Task SaveGame(Game game) => _games[game.Id] = game;
    }
}
