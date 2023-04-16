using System;
using SocialMediaPost.Common.DTOs;

namespace SocialMediaPost.Command.Api.DTOs;

public class NewPostResponse : BaseResponse
{
	public Guid Id { get; set; }
}

