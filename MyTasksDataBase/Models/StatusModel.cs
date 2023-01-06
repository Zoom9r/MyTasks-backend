
namespace MyTasksDataBase.Models
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public int ListOfTasksId { get; set; }
        public ListOfTasksModel ListOfTasks { get; set; }
    }
}
