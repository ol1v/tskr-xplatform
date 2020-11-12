using System;
using SQLite;
using Xamarin.Forms;

namespace Taskerino.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Task>();

                var tasks = conn.Table<Task>().ToList();
                tasksListView.ItemsSource = tasks;
            }
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTaskPage());
        }
    }
}