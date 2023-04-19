using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoClient.Models;

namespace TodoClient.Abstractions
{
    public interface ITodoRepo
    {
        /// <summary>
        /// Получить все списки задач
        /// </summary>
        Task<IEnumerable<TodoList>> GetTodoLists();

        /// <summary>
        /// Создать список задач с указанным названием
        /// </summary>
        /// <param name="name"></param>
        Task<TodoList> CreateList(string name);

        /// <summary>
        /// Добавить подзадачу в задачу
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<TodoItem> AddItemToList(int id, string name);

        /// <summary>
        /// Изменить статус подзадачи
        /// </summary>
        /// <param name="id"></param>
        Task<TodoItem> ChangeItemStatus(int id);

        /// <summary>
        /// Удалить список задач
        /// </summary>
        /// <param name="id"></param>
        Task<TodoList> DeleteList(int id);
    }
}
