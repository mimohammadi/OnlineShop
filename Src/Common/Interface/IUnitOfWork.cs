namespace Common.Interface
{
    public interface IUnitOfWork
    {
        Task Begin();
        Task Commit();
        Task RollBack();
    }
}
