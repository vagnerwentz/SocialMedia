using System;
using Microsoft.EntityFrameworkCore;
using SocialMediaPost.Query.Domain.Entities;
using SocialMediaPost.Query.Domain.Repositories;
using SocialMediaPost.Query.Infrastructure.DataAccess;

namespace SocialMediaPost.Query.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly DatabaseContextFactory _contextFactory;

	public PostRepository(DatabaseContextFactory contextFactory)
	{
        _contextFactory = contextFactory;
	}

    public async Task CreateAsync(PostEntity post)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            context.Posts.Add(post);
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid postId)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            var post = await GetByIdAsync(postId);

            if (post is null) return;

            context.Posts.Remove(post);
            await context.SaveChangesAsync();
        }
    }

    public async Task<PostEntity> GetByIdAsync(Guid postId)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Posts
                .Include(post => post.Comments)
                .FirstOrDefaultAsync(post => post.PostId == postId);
        }
    }

    public async Task<List<PostEntity>> ListAllAsync()
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Posts
                .AsNoTracking()
                .Include(post => post.Comments).AsNoTracking()
                .ToListAsync();
        }
    }

    public async Task<List<PostEntity>> ListByAuthorAsync(string author)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Posts
                .AsNoTracking()
                .Include(post => post.Comments).AsNoTracking()
                .Where(post => post.Author.Contains(author))
                .ToListAsync();
        }
    }

    public async Task<List<PostEntity>> ListWithCommentsAsync()
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Posts
                .AsNoTracking()
                .Include(post => post.Comments).AsNoTracking()
                .Where(post => post.Comments != null && post.Comments.Any())
                .ToListAsync();
        }
    }

    public async Task<List<PostEntity>> ListWithLikesAsync(int numberOfLikes)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Posts
                .AsNoTracking()
                .Include(post => post.Comments).AsNoTracking()
                .Where(post => post.Likes >= numberOfLikes)
                .ToListAsync();
        }
    }

    public async Task UpdateAsync(PostEntity post)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            context.Posts.Update(post);

            await context.SaveChangesAsync();
        }
    }
}

