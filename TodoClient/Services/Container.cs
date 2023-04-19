using Microsoft.OData.Client;
using TodoClient.Models;

namespace TodoClient.Services
{
    public class Container : DataServiceContext
    {
        public DataServiceQuery<TodoList> Lists { get; set; }

        public DataServiceQuery<TodoItem> Items { get; set; }

        public Container(Uri serviceRoot) : base(serviceRoot)
        {
            Lists = CreateQuery<TodoList>("TodoList");
            Items = CreateQuery<TodoItem>("TodoItem");
        }
    }
}
