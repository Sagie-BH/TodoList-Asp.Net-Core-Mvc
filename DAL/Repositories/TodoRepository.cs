using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Repositories
{
    public class TodoRepository : IRepository<TodoObjectModel>
    {
        private readonly DatabaseContext context;

        public TodoRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Create(TodoObjectModel todoObject)
        {
            context.TodoTable.Add(todoObject);
        }

        public IEnumerable<TodoObjectModel> GetAll()
        {
            return context.TodoTable;
        }

        public TodoObjectModel GetById(int id)
        {
            return context.TodoTable.SingleOrDefault(todo => todo.Id == id);
        }

        public void Remove(int id)
        {
            context.TodoTable.Remove(GetById(id));
        }

        public async Task<bool> SaveChanges()
        {
            var taskResult = await Task.Run(() =>
            {
                bool changesSaved;
                try { context.SaveChanges(); changesSaved = true; }
                catch { changesSaved = false; }
                return changesSaved;
            });
            return taskResult;
        }

        public void Update(TodoObjectModel todoObject)
        {
            context.Update(todoObject);
        }
    }
}
