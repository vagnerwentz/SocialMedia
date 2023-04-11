using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPost.Query.Domain.Entities;

[Table("Post")]
public class PostEntity
{
	[Key]
	public Guid PostId { get; set; }
	public string Author { get; set; }
	public DateTime PostedAt { get; set; }
	public string Message { get; set; }
	public int Likes { get; set; }
	public virtual ICollection<CommentEntity> Comments { get; set; }
}

