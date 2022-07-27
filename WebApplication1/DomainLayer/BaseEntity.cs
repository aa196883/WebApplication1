namespace WebApplication1.DomainLayer
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual bool IsValid() => Name != null;
    }
}

