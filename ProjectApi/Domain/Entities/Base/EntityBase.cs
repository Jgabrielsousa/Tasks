namespace Domain.Entities.Base
{
    public abstract class EntityBase<T> where T : class
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime AlterAt { get; set; }
    }
}
