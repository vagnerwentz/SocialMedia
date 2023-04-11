using System;
using CQRS.Core.Events;

namespace SocialMediaPost.Common.Events;

public class PostCreatedEvent : BaseEvent
{
	public PostCreatedEvent() : base(nameof(PostCreatedEvent))
	{
	}

	public string Author { get; set; }

	public string Message { get; set; }

	public DateTime PostedAt { get; set; }
}

