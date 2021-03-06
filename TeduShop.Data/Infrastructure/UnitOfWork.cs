﻿namespace TeduShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private TeduShopDbContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public TeduShopDbContext DbContext => dbContext ?? (dbContext = new TeduShopDbContext());

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
