using Application.UseCases.Base;

namespace Application.UseCases.MyTask.FindById
{
    public class FindTaskByIdCommand : Command<FindTaskByIdCommand>
    {
        public int Id { get; set; }


        public FindTaskByIdCommand()
        {
                
        }
        public FindTaskByIdCommand(int id)
        {
            Id = id;
        }

    }
}
