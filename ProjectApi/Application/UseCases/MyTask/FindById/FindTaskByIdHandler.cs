using Application.Results;
using Application.UseCases.Base;
using Domain.Interfaces.IRepository;

namespace Application.UseCases.MyTask.FindById
{
    public class FindTaskByIdHandler : Handler<FindTaskByIdCommand, FindTaskByIdHandler>
    {

        private readonly ITaskRepository _repo;
        public FindTaskByIdHandler(ITaskRepository repo)
        {
            _repo = repo;
        }

        public override Task<Result> Handle(FindTaskByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result.Data = _repo.Find(request.Id);

            }
            catch (Exception)
            {

                Result.AddNotification("Somenting went wrong", Domain.Enums.ErrorCode.InternalError);
            }

            return Task.FromResult(Result);
        }
    }
}
