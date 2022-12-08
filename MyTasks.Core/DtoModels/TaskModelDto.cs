namespace MyTasks.Core.DtoModels
{
    public class TaskModelDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int ListOfTasksId { get; set; }
    }

}
