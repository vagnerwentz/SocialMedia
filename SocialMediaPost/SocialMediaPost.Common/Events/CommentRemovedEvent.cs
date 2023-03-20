using CQRS.Core.Events;

namespace SocialMediaPost.Common.Events;

public class CommentRemovedEvent : BaseEvent
{
    public CommentRemovedEvent() : base(nameof(CommentRemovedEvent))
    {
    }

    public Guid CommentId { get; set; }
}

