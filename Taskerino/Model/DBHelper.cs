using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Taskerino
{
    
    public class DBHelper
    {
        private static SQLiteAsyncConnection db;
        
        public DBHelper()
        {
            db = new SQLiteAsyncConnection(App.DB_PATH);
            db.CreateTableAsync<Todo>().Wait();
        }

        public Task<List<Todo>> GetAllTasks()
        {
            var tasks = db.Table<Todo>().ToListAsync();
            return tasks;
        }

        public Task<int> AddTask(Todo task)
        {
            return db.InsertAsync(task);
        }
    }
}
