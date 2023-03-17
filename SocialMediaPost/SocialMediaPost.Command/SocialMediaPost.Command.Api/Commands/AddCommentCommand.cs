using CQRS.Core.Commands;

namespace SocialMediaPost.Command.Api.Commands;

public class AddCommentCommand : BaseCommand
{
	public string Comment { get; set; }

	public string Username { get; set; }
}

