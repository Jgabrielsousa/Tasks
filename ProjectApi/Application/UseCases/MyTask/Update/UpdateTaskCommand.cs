using Application.Dto;
using Application.UseCases.Base;

namespace Application.UseCases.MyTask.Create
{
    public class UpdateTaskCommand : Command<UpdateTaskCommand>
    {
        public int Id { get; set; }
        public TaskDto task { get; set; }


        public UpdateTaskCommand()
        {
        }
        public UpdateTaskCommand(int id, TaskDto author)
        {
            Id = id;
            task = author;
        }

    }
}
