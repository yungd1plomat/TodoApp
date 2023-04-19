using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using TodoClient.Abstractions;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient.Viewmodels
{
    public class MainPageViewmodel : PropertyChangedBase
    {
        private ObservableCollection<TodoList> _todoLists;
        public ObservableCollection<TodoList> TodoLists
        {
            get { return _todoLists; }
            set
            {
                _todoLists = value;
                OnPropertyChanged();
            }
        }

        private bool isLoaded { get; set; }

        private ITodoRepo _todoRepo { get; set; }

        public MainPageViewmodel()
        {
            _todoRepo = new TodoRepo();
            _todoLists = new ObservableCollection<TodoList>();
            isLoaded = false;
            Initialize();
        }

        private async void Initialize()
        {
            var lists = await _todoRepo.GetTodoLists();
            foreach (var list in lists)
            {
                _todoLists.Add(list);
            }
        }

        public ICommand AddListCommand => new Command(async () =>
        {
            var name = await Application.Current.MainPage.DisplayPromptAsync("Добавление задачи", "Введите название:", "OK", "Отмена");
            if (!string.IsNullOrEmpty(name))
            {
                var list = await _todoRepo.CreateList(name);
                _todoLists.Add(list);
            }
        });

        public ICommand RemoveListCommand => new Command(async (Id) =>
        {
            var listId = (int)Id;
            var list = await _todoRepo.DeleteList(listId);
            _todoLists.Remove(list);
        });

        public ICommand AddItemCommand => new Command(async (Id) => {
            var listId = (int)Id;
            var name = await Application.Current.MainPage.DisplayPromptAsync("Добавление подзадачи", "Введите название:", "OK", "Отмена");
            if (!string.IsNullOrEmpty(name))
            {
                var item = await _todoRepo.AddItemToList(listId, name);
                var list = _todoLists.FirstOrDefault(x => x.Id == listId);
                list.Items.Add(item);
            }
        });

        public ICommand ChangeStatusCommand => new Command(async (Id) =>
        {
            if (isLoaded)
            {
                var itemId = (int)Id;
                await _todoRepo.ChangeItemStatus(itemId);
            }
        });

        public ICommand LoadedCommand => new Command(() => 
        {
            isLoaded = true;
        });
    }
}
