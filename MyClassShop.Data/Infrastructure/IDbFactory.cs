using System;

namespace MyClassShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        myClassShopDbContext Init();
    }
}