using TodoApi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TodoApi.Abstractions
{
    public interface ITodoRepo
    {
        /// <summary>
        /// Получить все списки
        /// </summary>
        public IQueryable<TodoList> GetAllList();

        /// <summary>
        /// Получить списки по Id
        /// </summary>
        /// <param name="id">Id списка который нужно получить</param>
        public IQueryable<TodoList> GetListById(int id);

        /// <summary>
        /// Создать список
        /// </summary>
        /// <param name="todo">Создаваемый список</param>
        public Task CreateList(TodoList todo);

        /// <summary>
        /// Удалить список
        /// </summary>
        /// <param name="todo">Список который нужно удалить</param>
        public Task DeleteList(TodoList todo);

        /// <summary>
        /// Получить все задачи
        /// </summary>
        public IQueryable<TodoItem> GetAllItems();

        /// <summary>
        /// Получить задачу по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<TodoItem> GetItemById(int id);

        /// <summary>
        /// Отредактировать задачу
        /// </summary>
        /// <param name="todoItem">Задача которую нужно отредактировать</param>
        public Task Update(TodoItem todoItem);

        /// <summary>
        /// Создать задачу в списке
        /// </summary>
        /// <param name="listId"></param>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        public Task CreateItem(TodoList todoList, TodoItem todoItem);
    }
}
