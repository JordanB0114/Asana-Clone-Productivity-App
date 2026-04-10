using Asana2.Library.Services;
using Asana2.Maui.ViewModels;

namespace Asana2.Maui.Views;

public partial class ProjectPage : ContentPage
{
	public ProjectPage()
	{
		InitializeComponent();
		BindingContext = new ProjectPageViewModel();
	}

    private void AddProjectClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ProjectDetails");
    }
    private void EditProjectClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as ProjectPageViewModel)?.SelectedProjectId ?? 0;
        Shell.Current.GoToAsync($"//ProjectDetails?projectId={selectedId}");
    }
    private void DeleteProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectPageViewModel)?.DeleteProject();
    }
    private void ShowToDosClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as ProjectPageViewModel)?.SelectedProjectId ?? 0;
        Shell.Current.GoToAsync($"//ProjectToDos?projectId={selectedId}");
    }
    private void SortClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectPageViewModel)?.SortProjectsByPriority();
    }
    private async void OnExportProjectsClicked(object sender, EventArgs e)
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "projects.json");
        await ProjectServiceProxy.Current.ExportToFileAsync(filePath);
        await DisplayAlert("Export", $"Exported to {filePath}", "OK");
    }

    private async void OnImportProjectsClicked(object sender, EventArgs e)
    {
        var filePath = Path.Combine(FileSystem.AppDataDirectory, "projects.json");
        await ProjectServiceProxy.Current.ImportFromFileAsync(filePath);
        await DisplayAlert("Import", $"Imported from {filePath}", "OK");
        (BindingContext as ProjectPageViewModel)?.RefreshPage();
    }
    private void HomePageClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
    private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
    {

    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as ProjectPageViewModel)?.RefreshPage();
    }
}