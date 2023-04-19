using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoClient.Models
{
    [Key("Id")]
    public class TodoList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ObservableCollection<TodoItem>? Items { get; set; }
    }
}
