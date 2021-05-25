using System;
using SQLite;
using Taskerino.Model;
using Taskerino.ViewModel;
using Xamarin.Forms;

namespace Taskerino.View
{
    public partial class MainPage : ContentPage
    {
    
        private NewTaskViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            
            _viewModel = new NewTaskViewModel();
            
            if (Device.RuntimePlatform == Device.Android)
                BackgroundColor = Color.BlanchedAlmond;
            else if (Device.RuntimePlatform == Device.iOS)
                BackgroundColor = Color.Bisque;
                
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            tasksListView.ItemsSource = _viewModel.GetTodos();
        }

        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTaskPage());
        }
    }
}