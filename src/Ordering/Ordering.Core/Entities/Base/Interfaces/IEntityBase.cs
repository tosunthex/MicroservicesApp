namespace Ordering.Core.Entities.Base.Interfaces
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }
    }
}