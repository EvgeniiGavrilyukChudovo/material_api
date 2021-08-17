namespace Material.Core.Infrastructure.Database
{
    public interface IIdentity<TKey>
    {
        TKey Id { get; }
    }
}
