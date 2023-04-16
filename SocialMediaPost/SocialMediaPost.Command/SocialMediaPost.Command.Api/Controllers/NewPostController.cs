using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPost.Command.Api.Commands;
using SocialMediaPost.Command.Api.DTOs;
using SocialMediaPost.Common.DTOs;

namespace SocialMediaPost.Command.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class NewPostController : ControllerBase
{
    private readonly ILogger<NewPostController> _logger;
    private readonly ICommandDispatcher _commandDispatcher;

    public NewPostController(ILogger<NewPostController> logger, ICommandDispatcher commandDispatcher)
    {
        _logger = logger;
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> NewPostAsync(NewPostCommand newPostCommand)
    {
        Guid id = Guid.NewGuid();
        try
        {
            newPostCommand.Id = id;

            await _commandDispatcher.SendAsync(newPostCommand);

            return StatusCode(StatusCodes.Status201Created, new NewPostResponse
            {
                Message = "New post creation request completed successfully!"
            });
        } catch (InvalidOperationException ex)
        {
            _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
            return BadRequest(new BaseResponse
            {
                Message = ex.Message
            });
        } catch (Exception ex)
        {
            const string SAFE_ERROR_MESSAGE = "Error while processing request to create a new post!";
            _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

            return StatusCode(StatusCodes.Status500InternalServerError, new NewPostResponse
            {
                Id = id,
                Message = SAFE_ERROR_MESSAGE
            });
        }
    }
}

