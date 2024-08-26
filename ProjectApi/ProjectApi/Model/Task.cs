using Application.Dto;

namespace ProjectApi.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }

        public static implicit operator TaskDto(Task task)
        {

            return new TaskDto(task.Id, task.Name,task.Done);
        }
    }
}
