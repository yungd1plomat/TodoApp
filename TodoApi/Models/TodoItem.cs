using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApi.Models
{
    public class TodoItem
    {
        [Key]
        [ValidateNever]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        public int ListId { get; set; }

        [ValidateNever]
        public TodoList List { get; set; }
    }
}
