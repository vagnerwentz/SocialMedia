using System;
using SocialMediaPost.Query.Domain.Entities;

namespace SocialMediaPost.Query.Domain.Repositories;

public interface ICommentRepository
{
    Task CreateAsync(CommentEntity comment);
    Task UpdateAsync(CommentEntity comment);
    Task<CommentEntity> GetByIdAsync(Guid commentId);
    Task DeleteAsync(Guid commentId);
}

