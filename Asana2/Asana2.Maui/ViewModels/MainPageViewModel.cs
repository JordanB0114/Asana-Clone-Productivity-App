using Asana2.Library.Models;
using Asana2.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Asana2.Maui.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private ToDoServiceProxy _toDoSvc;

        public MainPageViewModel()
        {
            _toDoSvc = ToDoServiceProxy.Current;
            FilterToDos();
        }

        public ToDo SelectedToDo { get; set; }
        public ObservableCollection<ToDo> ToDos
        {
            get
            {
                var toDos = _toDoSvc.ToDos;
                if (!IsShowCompleted)
                {
                    toDos = _toDoSvc.ToDos.Where(t => !t.IsCompleted ?? false).ToList();
                }
                return new ObservableCollection<ToDo>(toDos);
            }
        }

        private string _toDoSearchText;
        public string ToDoSearchText
        {
            get => _toDoSearchText;
            set
            {
                _toDoSearchText = value;
                NotifyPropertyChanged();
                FilterToDos();
            }
        }

        private ObservableCollection<ToDo> _filteredToDos;
        public ObservableCollection<ToDo> FilteredToDos
        {
            get => _filteredToDos;
            set
            {
                _filteredToDos = value;
                NotifyPropertyChanged();
            }
        }

        public void FilterToDos()
        {
            var search = ToDoSearchText?.ToLower() ?? "";

            var filtered = _toDoSvc.ToDos
                .Where(t =>
                    (t.Name?.ToLower().Contains(search) ?? false) ||
                    (t.Description?.ToLower().Contains(search) ?? false))
                .ToList();

            if (!IsShowCompleted)
            {
                filtered = filtered.Where(t => !(t.IsCompleted ?? false)).ToList();
            }

            FilteredToDos = new ObservableCollection<ToDo>(filtered);
        }



        private bool isShowCompleted;
        public bool IsShowCompleted
        {
            get
            {
                return isShowCompleted;
            }
            set
            {
                if(isShowCompleted != value)
                {
                    isShowCompleted = value;
                    NotifyPropertyChanged(nameof(ToDos));
                    FilterToDos();
                }
            }
        }

        public void RefreshPage()
        {
            NotifyPropertyChanged(nameof(ToDos));
            FilterToDos();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void SortToDosByPriority()
        {
            if (FilteredToDos == null || !FilteredToDos.Any())
                return;

            var sorted = FilteredToDos
                .OrderBy(t => t.Priority)
                .ToList();

            FilteredToDos = new ObservableCollection<ToDo>(sorted);
        }
        public int SelectedToDoId
        {
            get
            {
                return SelectedToDo.Id;
            }
        }
        public void DeleteToDo()
        {
            if(SelectedToDo == null)
            {
                return;
            }
            ToDoServiceProxy.Current.DeleteToDo(SelectedToDo);
            FilterToDos();

        }
    }
}
