using System;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Taskerino.ViewModel;


namespace Taskerino.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTaskPage : ContentPage
    {
        private NewTaskViewModel _newTaskViewModel;
        public NewTaskPage()
        {
            InitializeComponent();
            _newTaskViewModel = new NewTaskViewModel();
            // BindingContext = _newTaskViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Add new task
            var Title = titleEntry.Text;
            var Description = descriptionEntry.Text;
            _newTaskViewModel.AddTodo(Title, Description);
        }
    }
}