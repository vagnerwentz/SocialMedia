using System;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using SocialMediaPost.Query.Domain.Entities;
using SocialMediaPost.Query.Domain.Repositories;
using SocialMediaPost.Query.Infrastructure.DataAccess;

namespace SocialMediaPost.Query.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly DatabaseContextFactory _contextFactory;

    public CommentRepository(DatabaseContextFactory contextFactory)
	{
        _contextFactory = contextFactory;
	}

    public async Task CreateAsync(CommentEntity comment)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            context.Comments.Add(comment);

            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid commentId)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            var comment = await GetByIdAsync(commentId);
            if (comment is null) return;

            context.Comments.Remove(comment);

            await context.SaveChangesAsync();
        }
    }

    public async Task<CommentEntity> GetByIdAsync(Guid commentId)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            return await context.Comments.FirstOrDefaultAsync(comment => comment.CommentId == commentId);
        }
    }

    public async Task UpdateAsync(CommentEntity comment)
    {
        using (DatabaseContext context = _contextFactory.CreateDbContext())
        {
            context.Comments.Update(comment);

            await context.SaveChangesAsync();
        }
    }
}

