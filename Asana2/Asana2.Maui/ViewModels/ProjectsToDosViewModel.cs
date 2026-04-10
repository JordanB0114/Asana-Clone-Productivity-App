using Asana2.Library.Models;
using Asana2.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asana2.Maui.ViewModels
{
    public class ProjectsToDosViewModel : INotifyPropertyChanged
    {
        private Project _project;

        public ProjectsToDosViewModel(Project selectedProject)
        {
            _project = selectedProject;
        }

        public string ProjectName => _project.Name ?? "No Name";

        public ObservableCollection<ToDo> ToDos =>
            new ObservableCollection<ToDo>(
                ToDoServiceProxy.Current.ToDos
                    .Where(t => t.ProjectId == _project.Id)
            );

        public ToDo SelectedToDo { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
