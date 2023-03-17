using System;
using CQRS.Core.Commands;

namespace SocialMediaPost.Command.Api.Commands;

public class EditMessageCommand : BaseCommand
{
	public string Message { get; set; }
}

