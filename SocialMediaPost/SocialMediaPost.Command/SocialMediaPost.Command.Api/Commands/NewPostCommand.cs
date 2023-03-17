using System;
using CQRS.Core.Commands;

namespace SocialMediaPost.Command.Api.Commands;

public class NewPostCommand : BaseCommand
{
	public string Author { get; set; }

	public string Message { get; set; }
}

