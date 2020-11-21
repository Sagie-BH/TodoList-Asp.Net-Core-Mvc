using DAL.DataContext;
using DAL.Models;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Repositories
{
    public class UserRepository : ISqlRepository<ApplicationUser>
    {
        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Create(ApplicationUser entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ApplicationUser GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ApplicationUser entity)
        {
            throw new System.NotImplementedException();
        }

        //public void Create(ApplicationUser user)
        //{
        //    context.UsersModel.Add(user);
        //}

        //public IEnumerable<UserModel> GetAll()
        //{
        //    return context.UsersModel;
        //}

        //public UserModel GetById(int id)
        //{
        //    return context.UsersModel.SingleOrDefault(user => user.ID == id);
        //}

        //public void Remove(int id)
        //{
        //    context.UsersModel.Remove(GetById(id));
        //}

        //public async Task<bool> SaveChanges()
        //{
        //    var taskResult = await Task.Run(() =>
        //    {
        //        bool changesSaved;
        //        try { context.SaveChanges(); changesSaved = true; }
        //        catch { changesSaved = false; }
        //        return changesSaved;
        //    });
        //    return taskResult;
        //}

        //public void Update(UserModel entity)
        //{
        //    context.Update(entity);
        //}
    }
}
