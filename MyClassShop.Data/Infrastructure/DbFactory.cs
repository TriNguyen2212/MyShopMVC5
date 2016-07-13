namespace MyClassShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private myClassShopDbContext dbContext;

        public myClassShopDbContext Init()
        {
            return dbContext ?? (dbContext = new myClassShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}