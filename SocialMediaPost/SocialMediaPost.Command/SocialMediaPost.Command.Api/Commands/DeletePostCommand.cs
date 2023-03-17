using CQRS.Core.Commands;

namespace SocialMediaPost.Command.Api.Commands;

public class DeletePostCommand : BaseCommand
{
	public string Username { get; set; }
}

