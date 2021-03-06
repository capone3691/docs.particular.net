using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;

public class AnotherEventMessageHandler : IHandleMessages<AnotherEventMessage>
{
    static ILog log = LogManager.GetLogger<AnotherEventMessageHandler>();

    public Task Handle(AnotherEventMessage message, IMessageHandlerContext context)
    {
        log.InfoFormat("Subscriber 1 received AnotherEventMessage with Id {0}.", message.EventId);
        log.InfoFormat("Message time: {0}.", message.Time);
        log.InfoFormat("Message duration: {0}.", message.Duration);
        return Task.FromResult(0);
    }
    
}