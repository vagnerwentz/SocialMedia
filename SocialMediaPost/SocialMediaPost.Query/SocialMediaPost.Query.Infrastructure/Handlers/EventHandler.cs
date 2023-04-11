using System;
using SocialMediaPost.Common.Events;
using SocialMediaPost.Query.Domain.Entities;
using SocialMediaPost.Query.Domain.Repositories;

namespace SocialMediaPost.Query.Infrastructure.Handlers;

public class EventHandler : IEventHandler
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentRepository _commentRepository;

	public EventHandler(IPostRepository postRepository, ICommentRepository commentRepository)
	{
        _postRepository = postRepository;
        _commentRepository = commentRepository;
	}

    public async Task On(PostCreatedEvent @event)
    {
        var post = new PostEntity
        {
            PostId = @event.Id,
            Author = @event.Author,
            PostedAt = @event.PostedAt,
            Message = @event.Message
        };

        await _postRepository.CreateAsync(post);
    }

    public async Task On(MessageUpdatedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if (post is null) return;

        post.Message = @event.Message;
        await _postRepository.UpdateAsync(post);
    }

    public async Task On(PostLikedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if (post is null) return;

        post.Likes++;
        await _postRepository.UpdateAsync(post);
    }

    public async Task On(CommentAddedEvent @event)
    {
        var comment = new CommentEntity
        {
            PostId = @event.Id,
            CommentId = @event.CommentId,
            CommentedAt = @event.CommentedAt,
            Comment = @event.Comment,
            Username = @event.Username,
            Edited = false
        };

        await _commentRepository.CreateAsync(comment);
    }

    public async Task On(CommentUpdatedEvent @event)
    {
        var comment = await _commentRepository.GetByIdAsync(@event.Id);

        if (comment is null) return;

        comment.Comment = @event.Comment;
        comment.Edited = true;
        comment.CommentedAt = @event.EditDate;
        await _commentRepository.UpdateAsync(comment);
    }

    public async Task On(CommentRemovedEvent @event)
    {
        await _commentRepository.DeleteAsync(@event.CommentId);
    }

    public async Task On(PostRemovedEvent @event)
    {
        await _postRepository.DeleteAsync(@event.Id);
    }
}

