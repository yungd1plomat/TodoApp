using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoClient.Viewmodels;

namespace TodoClient.Models
{
    [Key("Id")]
    public class TodoItem 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsComplete { get; set; }

        public int ListId { get; set; }

        public TodoList List { get; set; }
    }
}
