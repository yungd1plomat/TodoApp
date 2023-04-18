using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TodoApi.Abstractions;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class TodoListController : ODataController
    {
        private readonly ITodoRepo _todoRepo;

        public TodoListController(ITodoRepo todoRepo)
        {
            _todoRepo = todoRepo;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<TodoList> Get()
        {
            return _todoRepo.GetAllList();
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public SingleResult<TodoList> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_todoRepo.GetListById(key));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoList list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _todoRepo.CreateList(list);
            return Created(list);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromODataUri] int key)
        {
            var list = _todoRepo.GetListById(key);
            if (list is null)
            {
                return BadRequest();
            }
            await _todoRepo.DeleteList(list.First());
            return NoContent();
        }
    }
}
