using System;
using CQRS.Core.Domain;
using CQRS.Core.Handlers;
using CQRS.Core.Infrastructure;
using SocialMediaPost.Command.Domain.Aggregates;
using SocialMediaPost.Command.Infrastructure.Stores;

namespace SocialMediaPost.Command.Infrastructure.Handlers;

public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
{
    private readonly IEventStore _eventStore;

	public EventSourcingHandler(IEventStore eventStore)
	{
        _eventStore = eventStore;
    }

    public async Task<PostAggregate> GetByIdAsync(Guid aggregateId)
    {
        var aggregate = new PostAggregate();
        var events = await _eventStore.GetEventsAsync(aggregateId);

        if (events is null || !events.Any()) return aggregate;

        aggregate.ReplayEvents(events);
        aggregate.Version = events.Select(e => e.Version).Max();

        return aggregate;
    }

    public async Task SaveAsync(AggregateRoot aggregate)
    {
        await _eventStore.SaveEventsAsync(aggregate.Id, aggregate.GetUncommittedChanges(), aggregate.Version);
        aggregate.MarkChangesAsCommitted();
    }
}

