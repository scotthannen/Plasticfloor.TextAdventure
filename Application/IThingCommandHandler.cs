using Domain;

namespace Application;

public interface IThingCommandHandler<TCommand> where TCommand : ICommand
{
    Task<ActionResponse> Handle(TCommand command, Game game);
}