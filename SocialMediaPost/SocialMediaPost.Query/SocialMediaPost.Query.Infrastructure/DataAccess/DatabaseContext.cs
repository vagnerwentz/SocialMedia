using System;
using Microsoft.EntityFrameworkCore;
using SocialMediaPost.Query.Domain.Entities;

namespace SocialMediaPost.Query.Infrastructure.DataAccess;

public class DatabaseContext : DbContext
{
	public DatabaseContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
}

