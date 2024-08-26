using Application.UseCases.Base;

namespace Application.UseCases.MyTask.Delete
{
    public class DeleteTaskCommand : Command<DeleteTaskCommand>
    {
        public int Id { get; set; }

        public DeleteTaskCommand() 
        {
                
        }
        public DeleteTaskCommand(int id)
        {
            Id = id;
        }
    }
}
