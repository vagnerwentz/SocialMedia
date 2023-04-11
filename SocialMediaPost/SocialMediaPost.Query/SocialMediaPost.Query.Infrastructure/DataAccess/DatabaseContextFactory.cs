using System;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaPost.Query.Infrastructure.DataAccess;

public class DatabaseContextFactory
{
	private readonly Action<DbContextOptionsBuilder> _configureDbContext;

	public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
	{
		_configureDbContext = configureDbContext;
	}

	public DatabaseContext CreateDbContext()
	{
		DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
		_configureDbContext(optionsBuilder);

		return new DatabaseContext(optionsBuilder.Options);
	}
}

