using Asana2.Library.Services;
using Asana2.Maui.ViewModels;

namespace Asana2.Maui.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectsToDosView : ContentPage
{
    public ProjectsToDosView()
    {
        InitializeComponent();
    }

    private int _projectId;

    public int ProjectId
    {
        get => _projectId;
        set
        {
            _projectId = value;
            var selectedProject = ProjectServiceProxy.Current.GetById(_projectId);
            if (selectedProject != null)
            {
                BindingContext = new ProjectsToDosViewModel(selectedProject);
            }
        }
    }
    private void ProjectPageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectPage");
    }
}