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
            
            SQLite.SQLiteConnection conn = new SQLiteConnection((App.DB_PATH));
            
            // DisplayAlert("Success!", "You did it", "Cancel")
        }
    }
}