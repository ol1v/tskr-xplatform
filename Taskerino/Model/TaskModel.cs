using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taskerino.Model
{
    public class TaskModel
    {
        private static TaskModel _instance;

        public static TaskModel GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TaskModel();
            }
            return _instance;
        }

        private List<Todo> _tasks = new List<Todo>();
        private DBHelper _dbHelper;
        
        private TaskModel()
        {
            _dbHelper = new DBHelper();
            LoadTasks();
        }

        private async void LoadTasks()
        {
            var tasks = await _dbHelper.GetAllTasks();
            _tasks = tasks;
        }

        public List<Todo> GetTasks()
        {
            return _tasks;
        }

        public async void AddTask(string title, string description)
        {
            Todo todo = new Todo()
            {
                Title = title,
                Description = description
            };
            var res = await _dbHelper.AddTask(todo);
            // TODO: Check error
            LoadTasks();
        }
    }
}