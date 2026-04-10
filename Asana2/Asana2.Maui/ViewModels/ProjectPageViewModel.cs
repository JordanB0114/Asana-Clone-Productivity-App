using Asana2.Library.Models;
using Asana2.Library.Services;
using Asana2.Maui.Views;
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
    public class ProjectPageViewModel: INotifyPropertyChanged
    {
        private ProjectServiceProxy _projectSvc;

        public ProjectPageViewModel()
        {
            _projectSvc = ProjectServiceProxy.Current;
            FilterProjects();
        }

       
        private string _projectSearchText;
        private ObservableCollection<Project> _filteredProjects;

        public string ProjectSearchText
        {
            get => _projectSearchText;
            set
            {
                _projectSearchText = value;
                NotifyPropertyChanged();
                FilterProjects();
            }
        }
        public void SortProjectsByPriority()
        {
            if (FilteredProjects == null || !FilteredProjects.Any())
                return;

            var sorted = FilteredProjects
                .OrderBy(t => t.Priority)
                .ToList();

            FilteredProjects = new ObservableCollection<Project>(sorted);
        }
        public ObservableCollection<Project> FilteredProjects
        {
            get => _filteredProjects;
            set
            {
                _filteredProjects = value;
                NotifyPropertyChanged();
            }
        }
        private void FilterProjects()
        {
            var filtered = _projectSvc.Projects
                .Where(p => string.IsNullOrWhiteSpace(ProjectSearchText)
                    || p.Name.Contains(ProjectSearchText, StringComparison.OrdinalIgnoreCase))
                .ToList();

            FilteredProjects = new ObservableCollection<Project>(filtered);
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RefreshPage()
        {
            FilterProjects();
        }

        public Project SelectedProject { get; set; }
        public int SelectedProjectId
        {
            get
            {
                return SelectedProject.Id;
            }
        }

        public void DeleteProject()
        {
            if(SelectedProject == null)
            {
                return;
            }
            ProjectServiceProxy.Current.DeleteProject(SelectedProject);
            FilterProjects();
        }

        

    }
}
