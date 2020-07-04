namespace Automapper10ExpressionTests
{
    public abstract class EntityDtoBase<T> : DtoBase<T> where T : EntityDtoBase<T>
    {
        public virtual int Id { get; set; }
    }
}
