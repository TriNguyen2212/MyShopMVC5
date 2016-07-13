using MyClassShop.Data.Infrastructure;
using MyClassShop.Model.Models;

namespace MyClassShop.Data.Reponsitories
{
    public interface IProductResository
    {
    }

    public class ProductResository : RepositoryBase<Product>
    {
        public ProductResository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}