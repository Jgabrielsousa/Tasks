using Application.Results;
using Application.UseCases.Base;
using Domain.Interfaces.IRepository;

namespace Application.UseCases.MyTask.Create
{
    public class UpdateTaskHandler : Handler<UpdateTaskCommand, UpdateTaskHandler>
    {
       
        private readonly ITaskRepository _repo;
        public UpdateTaskHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public override Task<Result> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _repo.Find(request.Id);
                entity.Name = request.task.Name;
                entity.Done = request.task.Done;
                _repo.Update(entity);
            }
            catch (Exception)
            {

                Result.AddNotification("Somenting went wrong", Domain.Enums.ErrorCode.InternalError);
            }
           

            return Task.FromResult(Result);
        }
    }
}
