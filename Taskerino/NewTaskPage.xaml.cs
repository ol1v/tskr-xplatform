using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskerino
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTaskPage : ContentPage
    {
        public NewTaskPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
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
                DisplayAlert("Success!", "Task has been created", "OK");
            else
                DisplayAlert("Failure!", "Something went wrong. Try again!", "OK");
            }
            
        }
    }
}