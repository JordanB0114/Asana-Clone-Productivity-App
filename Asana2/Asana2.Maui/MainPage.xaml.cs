using Asana2.Library.Services;
using Asana2.Maui.ViewModels;

namespace Asana2.Maui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private void AddNewClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ToDoDetails");
        }

        private void EditClicked(object sender, EventArgs e)
        {
            var selectedId = (BindingContext as MainPageViewModel)?.SelectedToDoId ?? 0;
            Shell.Current.GoToAsync($"//ToDoDetails?toDoId={selectedId}");
        }

        private void DeleteClicked(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel)?.DeleteToDo();

        }
        private void OnToDoSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            (BindingContext as MainPageViewModel)?.FilterToDos();
        }
        private void SortClicked(object sender, EventArgs e)
        {
            (BindingContext as MainPageViewModel)?.SortToDosByPriority();
        }
        private async void OnExportToDosClicked(object sender, EventArgs e)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "todos.json");
            await ToDoServiceProxy.Current.ExportToFileAsync(filePath);
            await DisplayAlert("Export", $"Exported to {filePath}", "OK");
        }

        private async void OnImportToDosClicked(object sender, EventArgs e)
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "todos.json");
            await ToDoServiceProxy.Current.ImportFromFileAsync(filePath);
            await DisplayAlert("Import", $"Imported from {filePath}", "OK");
            (BindingContext as MainPageViewModel)?.RefreshPage();
        }
        private void ProjectPageClicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("//ProjectPage");
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            (BindingContext as MainPageViewModel)?.RefreshPage();
        }

        private void ContentPage_NavigatedFrom(object sender, NavigatedFromEventArgs e)
        {

        }
    }
}
