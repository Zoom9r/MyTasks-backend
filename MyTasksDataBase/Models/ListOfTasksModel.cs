
namespace MyTasksDataBase.Models
{
    public class ListOfTasksModel
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<StatusModel> Statuses { get; set; }
        public List<TaskModel> Tasks { get; set; }

    }
}
