using Application.Results;
using Application.UseCases.Base;
using Domain.Entities;
using Domain.Interfaces.IRepository;

namespace Application.UseCases.MyTask.Create
{
    public  class CreateTaskHandler : Handler<CreateTaskCommand, CreateTaskHandler>
    {
        private readonly ITaskRepository _repo;
        public CreateTaskHandler(ITaskRepository repo)
        {
            _repo= repo;
        }

        public override Task<Result> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _repo.Add(new TaskEntity() { Name = request.Name });

                request.Id = entity.Id;
                Result.Data = request;
            }
            catch (Exception)
            {

                Result.AddNotification("Somenting went wrong", Domain.Enums.ErrorCode.InternalError);
            }

         

            return Task.FromResult(Result);
        }
    }
}
