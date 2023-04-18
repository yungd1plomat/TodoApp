using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TodoItem>? Items { get; set; }
    }
}
