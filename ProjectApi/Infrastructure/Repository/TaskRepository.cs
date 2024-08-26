using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using Infrastructure.Repository.Base;
using Domain.Entities;
using Domain.Interfaces.IRepository;

namespace Infrastructure.Repository
{
    public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(MyTasksDbContext context): base(context)
        {
                
        }

        
    }
}
