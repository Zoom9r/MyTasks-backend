
namespace MyTasksDataBase.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public StatusModel Status { get; set; }
        public int ListOfTasksId { get; set; }
        public ListOfTasksModel ListOfTasks { get; set; }
    }
}
