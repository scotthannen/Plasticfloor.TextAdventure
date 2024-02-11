using Domain;

namespace Application.Commands;

public class TakeThingCommand : GameCommand
{
    public TakeThingCommand(Guid gameId, Thing thing) : base(gameId)
    {
        Thing = thing;
    }

    public Thing Thing { get; set; }
}