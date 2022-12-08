namespace MyTasksDataBase.Models
{
    public class StatusModelDto
    {
        public int Id { get; set; }
        public string StatusName { get; set; }
        public int ListOfTasksId { get; set; }
    }
}
