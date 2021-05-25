
using System.Collections.Generic;
using SQLite;
using Taskerino.Model;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Taskerino.ViewModel
{
    public class NewTaskViewModel
    {
        private TaskModel _model;

        public NewTaskViewModel()
        {
            _model = TaskModel.GetInstance();
        }
        public static async System.Threading.Tasks.Task ReadTask()
        {
            await TextToSpeech.SpeakAsync("Added Task");
        }

        public List<Todo> GetTodos()
        {
            return _model.GetTasks();
        }

        public void AddTodo(string title, string description)
        {
            _model.AddTask(title, description);
        }
    }
}