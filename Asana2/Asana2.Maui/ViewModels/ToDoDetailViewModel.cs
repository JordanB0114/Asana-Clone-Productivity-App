using Asana2.Library.Models;
using Asana2.Library.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Asana2.Maui.ViewModels
{
    public class ToDoDetailViewModel
    {
        public ToDoDetailViewModel()
        {
            Model = new ToDo();
        }

        public ToDoDetailViewModel(int id)
        {
            Model = ToDoServiceProxy.Current.GetById(id) ?? new ToDo();
        }
        public List<int> Priorities
        {
            get
            {
                return new List<int> { 1, 2, 3, 4, 5 };
            }
        }
        public int SelectedPriority 
        {
            get
            {
                return Model?.Priority ?? 4;
            }
            set
            {
                if(Model != null && Model.Priority != value)
                {
                    Model.Priority = value;
                    NotifyPropertyChanged(nameof(SelectedPriority));

                }
            }
        }
        public ToDo? Model { get; set; }
        
        public void AddOrUpdateToDo()
        {
            ToDoServiceProxy.Current.AddOrUpdate(Model);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
