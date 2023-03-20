using CQRS.Core.Events;

namespace SocialMediaPost.Common.Events;

public class PostRemovedEvent : BaseEvent
{
    public PostRemovedEvent() : base(nameof(PostRemovedEvent))
    {
    }
}

