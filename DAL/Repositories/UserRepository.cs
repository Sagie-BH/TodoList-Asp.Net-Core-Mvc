using DAL.DataContext;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
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
            context.Users.Add(user);
        }

        public IEnumerable<UserModel> GetAll()
        {
            return context.Users;
        }

        public UserModel GetById(int id)
        {
            return context.Users.SingleOrDefault(user => user.ID == id);
        }

        public void Remove(int id)
        {
            context.Users.Remove(GetById(id));
        }

        public bool SaveChanges()
        {
            try { context.SaveChanges(); return true; }
            catch { return false; }
        }

        public void Update(UserModel entity)
        {
            context.Update(entity);
        }
    }
}
