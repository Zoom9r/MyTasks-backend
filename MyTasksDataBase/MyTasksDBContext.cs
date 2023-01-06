using Microsoft.EntityFrameworkCore;
using MyTasksDataBase.Models;

namespace MyTasksDataBase
{
    public class MyTasksDBContext : DbContext
    {
        public DbSet<TaskModel> MyTasks { get; set; }
        public DbSet<StatusModel> StatusModels { get; set; }
        public DbSet<ListOfTasksModel> ListOfTasksModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(
                @"Server=.;Database=MyTasks;Integrated Security=True;");
        }
    }
}
