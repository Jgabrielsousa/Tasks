using Application.UseCases.Base;

namespace Application.UseCases.MyTask.Create
{
    public class CreateTaskCommand : Command<CreateTaskCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CreateTaskCommand()
        {
                
        }

        public CreateTaskCommand(string name)
        {
            Name = name;
        }
    }
}
