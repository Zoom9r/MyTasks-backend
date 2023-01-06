using MyTasksDataBase.Repositories.Interfaces.Base;
using MyTasksDataBase.Repositories.Interfaces.ListOfTasks;
using MyTasksDataBase.Repositories.Interfaces.MyTask;
using MyTasksDataBase.Repositories.Interfaces.StatusType;
using MyTasksDataBase.Repositories.Realizations.ListOfTasks;
using MyTasksDataBase.Repositories.Realizations.MyTask;
using MyTasksDataBase.Repositories.Realizations.Status;

namespace MyTasksDataBase.Repositories.Realizations.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MyTasksDBContext _dbContext;
        private ITaskRepository _taskRepository;
        private IStatusRepository _statusRepository;
        private IListOfTasksRepository _listOfTasksRepository;

        public RepositoryWrapper(MyTasksDBContext context)
        {
            _dbContext = context;
        }

        public ITaskRepository TaskRepository
        {
            get
            {
                if (_taskRepository == null)
                {
                    _taskRepository = new TaskRepository(_dbContext);
                }
                return _taskRepository;
            }
        }

        public IStatusRepository StatusRepository
        {
            get
            {
                if (_statusRepository == null)
                {
                    _statusRepository = new StatusRepository(_dbContext);
                }
                return _statusRepository;
            }
        }

        public IListOfTasksRepository ListOfTasksRepository
        {
            get
            {
                if (_listOfTasksRepository == null)
                {
                    _listOfTasksRepository = new ListOfTasksRepository(_dbContext);
                }
                return _listOfTasksRepository;
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
