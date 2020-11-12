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
        public NewTaskPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Task task = new Task()
            {
                Title = titleEntry.Text,
                Description = descriptionEntry.Text
            };
            
            // using automatically disposes the db connection.
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DB_PATH)) {
                conn.CreateTable<Task>();
                var numberOfRows = conn.Insert(task);

                if (numberOfRows > 0)
                {   
                    await DisplayAlert("Success!", "Task has been created", "OK");
                    await NewTaskViewModel.ReadTask();
                }
                else
                    await DisplayAlert("Failure!", "Something went wrong. Try again!", "OK");
            }
            
        }
    }
}