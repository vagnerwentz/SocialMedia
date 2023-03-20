using System;
using CQRS.Core.Events;

namespace SocialMediaPost.Common.Events;

public class PostLikedEvent : BaseEvent
{
    public PostLikedEvent() : base(nameof(PostLikedEvent))
    {
    }
}

