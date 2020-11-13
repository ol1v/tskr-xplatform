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
            
            if (Device.RuntimePlatform == Device.Android)
                BackgroundColor = Color.BlanchedAlmond;
            else if (Device.RuntimePlatform == Device.iOS)
                BackgroundColor = Color.Bisque;
                
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