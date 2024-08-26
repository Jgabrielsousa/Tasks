using Application.Results;
using Application.UseCases.Base;
using Domain.Interfaces.IRepository;

namespace Application.UseCases.MyTask.Delete
{
    public class DeleteTaskHandler : Handler<DeleteTaskCommand, DeleteTaskHandler>
    {


        private readonly ITaskRepository _repo;
        public DeleteTaskHandler(ITaskRepository repo)
        {
            _repo = repo;
        }


        public override Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _repo.Find(request.Id);

                if (entity == null)
                {
                    Result.AddNotification("Task not Found", Domain.Enums.ErrorCode.NotFound);
                    return Task.FromResult(Result);
                }


                _repo.Remove(entity);
            }
            catch (Exception)
            {

                Result.AddNotification("Somenting went wrong", Domain.Enums.ErrorCode.InternalError);

            }

            return Task.FromResult(Result);
        }
    }
}
