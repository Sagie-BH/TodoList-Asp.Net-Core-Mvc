using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoList.DataContext
{
    public class DatabaseContext: DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppCongfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; } // Helps Configure the connection to the database
            public DbContextOptions<DatabaseContext> dbOptions { get; set; } // Database Configuration information - provider...

            private AppCongfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options) { }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TodoObjectModel> TodoTable { get; set; }
        public DbSet<AuthenticationLevel> AuthenticationLevels { get; set; }
    }
}
