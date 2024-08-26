using Domain.Entities.Base;

namespace Domain.Entities
{
    public  class TaskEntity : EntityBase<TaskEntity>
    {
        public string Name { get; set; }
        public bool Done { get; set; }
        
    }
}
