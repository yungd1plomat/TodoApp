using Microsoft.EntityFrameworkCore;
using TodoApi.Abstractions;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoRepo : ITodoRepo
    {
        private readonly AppDbContext _context;

        public TodoRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateList(TodoList todo)
        {
            await _context.Lists.AddAsync(todo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteList(TodoList todo)
        {
            _context.Lists.Remove(todo);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TodoList> GetAllList()
        {
            return _context.Lists
                .Include(x => x.Items)
                .AsQueryable();
        }

        public IQueryable<TodoList> GetListById(int id)
        {
            return _context.Lists
                .Include(x => x.Items)
                .AsQueryable()
                .Where(x => x.Id == id);
        }

        public IQueryable<TodoItem> GetAllItems()
        {
            return _context.Items
                .Include(x => x.List)
                .AsQueryable();
        }

        public IQueryable<TodoItem> GetItemById(int id)
        {
            return _context.Items
                .AsQueryable()
                .Where(x => x.Id == id);
        }

        public async Task Update(TodoItem todoItem)
        {
            if (!_context.Items.Contains(todoItem)) return;
            _context.Items.Update(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task CreateItem(TodoList todoList, TodoItem todoItem)
        {
            if (todoList.Items is null)
            {
                todoList.Items = new List<TodoItem>();
            }
            todoList.Items.Add(todoItem);
            _context.Lists.Update(todoList);
            await _context.SaveChangesAsync();
        }
    }
}
