using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoClient.Abstractions;
using TodoClient.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TodoClient.Services
{
    public class TodoRepo : ITodoRepo
    {
        const string URI = "https://localhost:7276/odata/";


        private readonly Container _context;

        public TodoRepo()
        {
            _context = new Container(new Uri(URI));
        }

        public async Task<IEnumerable<TodoList>> GetTodoLists()
        {
            return await _context.Lists
                .Expand("Items")
                .ExecuteAsync();
        }

        public async Task<TodoList> CreateList(string name)
        {
            var list = new TodoList()
            {
                Name = name,
                Items = new(),
            };
            _context.AddObject("TodoList", list);
            await _context.SaveChangesAsync();
            return list;
        }

        public async Task<TodoItem> AddItemToList(int id, string name)
        {
            var item = new TodoItem()
            {
                Name = name,
                ListId = id,
            };
            _context.AddObject("TodoItem", item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TodoItem> ChangeItemStatus(int id)
        {
            var item = _context.Items.Where(x => x.Id == id).SingleOrDefault();
            if (item is null)
            {
                return null;
            }
            item.IsComplete = !item.IsComplete;
            _context.UpdateObject(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<TodoList> DeleteList(int id)
        {
            var list = _context.Lists.Where(l => l.Id == id).SingleOrDefault();
            if (list is null)
            {
                return null;
            }
            _context.DeleteObject(list);
            await _context.SaveChangesAsync();
            return list;
        }
    }
}
