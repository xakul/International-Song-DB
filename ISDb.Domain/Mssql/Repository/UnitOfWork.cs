using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISDb.Domain.Mssql.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext Context { get; }

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        //One of the most important methods. We can decide what this entity going to be by controlling its state status
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // In entries list we can reach entries which state is equals Added.
            var addedEntities = this.Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

            foreach (var item in addedEntities)
            {
                item.Property("CreatedBy").CurrentValue = "ati";
                item.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                item.Property("ChangedBy").CurrentValue = item.Property("CreatedBy").CurrentValue;
                item.Property("ChangedAt").CurrentValue = item.Property("CreatedAt").CurrentValue;
            }

            var editedEntities = this.Context.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

            foreach (var item in editedEntities)
            {
                if ((DateTime)item.Property("CreatedAt").OriginalValue == DateTime.MinValue)
                    item.Property("CreatedAt").CurrentValue = DateTime.UtcNow;

                if (item.Property("CreatedBy").OriginalValue == null)
                    item.Property("CreatedBy").CurrentValue = "ati";

                item.Property("ChangedBy").CurrentValue = "ati";
                item.Property("ChangedAt").CurrentValue = DateTime.UtcNow;
            }


            return await this.Context.SaveChangesAsync(cancellationToken);
        }

        public virtual int SaveChanges(CancellationToken cancellationToken = default)
           => this.Context.SaveChanges();
    }
}
