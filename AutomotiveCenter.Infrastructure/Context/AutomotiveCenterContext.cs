using AutomotiveCenter.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomotiveCenter.Infrastructure.Context
{
    public class AutomotiveCenterContext : DbContext
    {
        #region Constants
        const string DATE_ADDED = "DateCreated";
        const string DATE_UPDATED = "DateUpdated";
        const string FLAG_DELETED = "IsDeleted";
        #endregion

        public AutomotiveCenterContext() : base() { }
        public AutomotiveCenterContext(DbContextOptions<AutomotiveCenterContext> options) : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                //Default connection string
                var connStr = "Server=localhost;Database=AutomotiveCenter;Trusted_Connection=True;";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

                //Use the connection in the appsettings if it exist, otherwise use default connection string
                if (File.Exists(path))
                {
                    var configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddJsonFile(path, false);
                    var root = configurationBuilder.Build();
                    connStr = root["AutoCenterDBConnection"];
                }

                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Query Filter to Ignore Softdeleted Rows
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // If is Shadow Type, ignore it.
                if (entityType.ClrType == null)
                {
                    continue;
                }

                entityType.GetOrAddProperty(FLAG_DELETED, typeof(bool?));

                // Create Query Filter
                var parameter = Expression.Parameter(entityType.ClrType);

                // EF.Property<DateTime?>(foo, "DateDeleted")
                var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool?));
                var FlagDeletedProp = Expression.Call(propertyMethodInfo, parameter, Expression.Constant(FLAG_DELETED));

                // EF.Property<DateTime?>(entity, "DateDeleted") == null
                var binaryExpression = Expression.MakeBinary(ExpressionType.Equal, FlagDeletedProp, Expression.Constant(null));

                // foo => EF.Property<DateTime?>(entity, "DateDeleted") == null
                var lambda = Expression.Lambda(binaryExpression, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
            #endregion

            #region Model Builder

            #endregion
        }

        public override int SaveChanges()
        {
            SetUpdateSoftDelete();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            SetUpdateSoftDelete();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

            return result;
        }

        #region DBSets
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        #endregion

        #region private methods
        private void SetUpdateSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:                        
                        entry.CurrentValues[DATE_ADDED] = DateTime.Now;
                        break;
                    case EntityState.Modified:                        
                        entry.CurrentValues[DATE_UPDATED] = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[FLAG_DELETED] = true;                        
                        break;
                }
            }
        }
        #endregion

    }
}
