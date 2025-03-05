namespace Application
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<ActionResponse> Handle(TCommand command);
    }
}
