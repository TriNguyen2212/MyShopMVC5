using MyClassShop.Data.Infrastructure;
using MyClassShop.Model.Models;

namespace MyClassShop.Data.Reponsitories
{
    public interface IErrorRepositoty : IRepository<Error>
    {
    }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepositoty
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}