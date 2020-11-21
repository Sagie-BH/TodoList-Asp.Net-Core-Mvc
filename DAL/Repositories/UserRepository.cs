using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Repositories
{
    public class UserRepository : ISqlRepository<UserModel>
    {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Create(UserModel user)
        {
            context.UsersModel.Add(user);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context.UsersModel;
        }

        public UserModel GetById(int id)
        {
            return context.UsersModel.SingleOrDefault(user => user.ID == id);
        }

        public void Remove(int id)
        {
            context.UsersModel.Remove(GetById(id));
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

        public void Update(UserModel entity)
        {
            context.Update(entity);
        }
    }
}
