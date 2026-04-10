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
    public class ProjectDetailViewModel
    {
        public ProjectDetailViewModel()
        {
            Model = new Project();
        }
        public ProjectDetailViewModel(int id)
        {
            Model = ProjectServiceProxy.Current.GetById(id) ?? new Project();
        }

        public Project? Model { get; set; }

        public void AddOrUpdateProject()
        {
            ProjectServiceProxy.Current.AddOrUpdateProject(Model);
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
                if (Model != null && Model.Priority != value)
                {
                    Model.Priority = value;
                    NotifyPropertyChanged(nameof(SelectedPriority));

                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
