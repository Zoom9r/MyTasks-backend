using MyTasksDataBase.Repositories.Interfaces.Base;
using MyTasksDataBase.Repositories.Interfaces.MyTask;
using MyTasksDataBase.Repositories.Realizations.MyTask;

namespace MyTasksDataBase.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MyTasksDBContext _dbContext;
        private IMyTaskRepository _taskRepository;
        public RepositoryWrapper(MyTasksDBContext context)
        {
            _dbContext = context;
        }
        public IMyTaskRepository MyTaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new MyTaskRepository(_dbContext);
                }
                return _taskRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
