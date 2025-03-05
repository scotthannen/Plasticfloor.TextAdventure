using Application;
using Domain;

namespace Persistence
{
    public class GameRepository : IGameRepository
    {
        private readonly Dictionary<Guid, Game> _games;

        public GameRepository() => _games = new Dictionary<Guid, Game>();

        public async Task<Game> LoadGame(Guid gameId) => _games.ContainsKey(gameId) ? _games[gameId] : (Game)null;

        public async Task SaveGame(Game game) => _games[game.Id] = game;
    }
}
