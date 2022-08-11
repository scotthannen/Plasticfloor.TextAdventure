using Domain;

namespace Application
{
    public interface IGameRepository
    {
        Task<Game> LoadGame(Guid gameId);

        Task SaveGame(Game game);
    }
}
