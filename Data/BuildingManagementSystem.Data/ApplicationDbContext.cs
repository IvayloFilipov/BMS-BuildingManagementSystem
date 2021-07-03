namespace BuildingManagementSystem.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Data.Models.BuildingExpenses;
    using BuildingManagementSystem.Data.Models.BuildingFunds;
    using BuildingManagementSystem.Data.Models.BuildingIncomes;
    using BuildingManagementSystem.Data.Models.Common;
    using BuildingManagementSystem.Data.Models.Debts;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // BuildingData
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Building> Building { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<CompanyOwner> CompanyOwners { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyFloor> PropertyFloors { get; set; }

        public DbSet<PropertyOwner> PropertiesOwners { get; set; }

        public DbSet<PropertyType> PropertyTypes { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        // BuildingExpenses
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public DbSet<Transaction> OutgoingPayments { get; set; }

        // BuildingFunds
        public DbSet<Account> BuildingAccounts { get; set; }

        // BuildingIncomes
        public DbSet<Payment> IncomingPayments { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        // Common
        public DbSet<ContactForm> ContactForms { get; set; }

        public DbSet<File> Files { get; set; }

        // Debts
        public DbSet<Fee> Fees { get; set; }

        public DbSet<PropertyDebt> PropertyDebtsMonthly { get; set; }

        public DbSet<PropertyStatus> PropertyStatusMonthly { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
