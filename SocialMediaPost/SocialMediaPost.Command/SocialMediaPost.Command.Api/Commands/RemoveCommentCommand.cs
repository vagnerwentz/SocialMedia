using System;
using CQRS.Core.Commands;

namespace SocialMediaPost.Command.Api.Commands;

public class RemoveCommentCommand : BaseCommand
{
	public Guid CommentId { get; set; }

	public string Username { get; set; }
}

