using HoneyDo.WebApp.Core.Requests;
using HoneyDo.WebApp.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace HoneyDo.WebApp.Core.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoItemsController : ControllerBase
{
    /// <summary>
    /// Creates a new Todo Item
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost(Name = "CreateTodoItem")]
    public IActionResult Create(TodoRequest request, CancellationToken cancellationToken = default)
    {
        var newTodoItem = new TodoResponse(request.Title, request.Description);
        var newTodoItemId = newTodoItem.Id;
        // we can return newTodoItem, but client would already know this information right?
        // considering returning only the id instead
        var response = new { TodoId = newTodoItemId };
        return CreatedAtRoute("GetTodoItemById", response, response);
    }
    
    
    /// <summary>
    /// Gets the Todo item provided an Id
    /// </summary>
    /// <param name="TodoId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{TodoId:guid}", Name = "GetTodoItemById")]
    public IActionResult GetTodoItemById(Guid TodoId, CancellationToken cancellationToken = default) => Ok(new TodoResponse("Todo Title", "Description", TodoId));

    
    /// <summary>
    /// Updates the Todo Item
    /// </summary>
    /// <param name="TodoId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{TodoId:guid}", Name = "GetTodoItemById")]
    public IActionResult UpdateTodoItem(Guid TodoId, CancellationToken cancellationToken = default) => NoContent();
    
    /// <summary>
    /// Deletes item provided an id
    /// </summary>
    /// <param name="TodoId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{TodoId:guid}", Name = "DeleteTodoItemById")]
    public ActionResult Delete(Guid TodoId, CancellationToken cancellationToken = default) => NoContent();
}