namespace Automapper10ExpressionTests
{
    public abstract class PersistenceDtoBase<T> : DtoBase<T> where T : PersistenceDtoBase<T>
    {
        public virtual int Id { get; set; }
    }
}
