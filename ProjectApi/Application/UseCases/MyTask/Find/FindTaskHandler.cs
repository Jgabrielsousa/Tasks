using Application.Results;
using Application.UseCases.Base;
using Domain.Interfaces.IRepository;

namespace Application.UseCases.MyTask.Find
{
    public class FindTaskHandler : Handler<FindTaskCommand, FindTaskHandler>
    {
        private readonly ITaskRepository _repo;
        public FindTaskHandler(ITaskRepository repo)
        {
            _repo = repo;
        }


        public override Task<Result> Handle(FindTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Result.Data = _repo.GetAll();


            }
            catch (Exception)
            {

                Result.AddNotification("Somenting went wrong", Domain.Enums.ErrorCode.InternalError);
            }

            return Task.FromResult(Result);
        }
    }
}
