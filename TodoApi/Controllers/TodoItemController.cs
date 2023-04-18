using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TodoApi.Abstractions;
using TodoApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TodoApi.Controllers
{
    public class TodoItemController : ODataController
    {
        private readonly ITodoRepo _todoRepo;

        public TodoItemController(ITodoRepo todoRepo) 
        {
            _todoRepo = todoRepo;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<TodoItem> Get()
        {
            return _todoRepo.GetAllItems();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<TodoItem> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_todoRepo.GetItemById(key));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromODataUri] int key, [FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != item.Id)
            {
                return BadRequest();
            }

            await _todoRepo.Update(item);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = await _todoRepo.GetListById(item.ListId)
                .FirstOrDefaultAsync();

            if (list is null)
            {
                return BadRequest();
            }

            await _todoRepo.CreateItem(list, item);
            return Created(item);
        }
    }
}
