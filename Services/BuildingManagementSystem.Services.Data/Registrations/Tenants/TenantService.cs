﻿namespace BuildingManagementSystem.Services.Data.Registrations.Tenants
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data;
    using BuildingManagementSystem.Data.Models.BuildingData;
    using BuildingManagementSystem.Web.ViewModels.Tenants.ManagerModules;

    public class TenantService : ITenantService
    {
        private readonly ApplicationDbContext dbContext;

        public TenantService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddTenantAsync(string firstName, string middleName, string lastName, string email, string phone, string userId)
        {
            var ownerId = this.dbContext
                .Owners
                .Where(x => x.UserId == userId)
                .Select(x => x.Id)
                .FirstOrDefault();

            var currTenant = new Tenant
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                OwnerId = ownerId,
            };

            await this.dbContext.Tenants.AddAsync(currTenant);

            await this.dbContext.SaveChangesAsync();

            return currTenant.Id;
        }

        public IEnumerable<AllTenantsDataModel> GetAll()
        {
            var tenants = this.dbContext
                .Tenants
                .Select(x => new AllTenantsDataModel
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Phone = x.Phone,
                    OwnerId = x.UserId,
                })
                .ToList();

            return tenants;
        }

        public void RemoveTenant(string userId)
        {
            var currTenant = this.dbContext
                .Tenants
                .Where(x => x.UserId == userId && x.IsDeleted == false)
                .FirstOrDefault();

            if (currTenant == null)
            {
                return;
            }

            currTenant.IsDeleted = true;

            this.dbContext.SaveChanges();
        }

        public void SetUserToRoleTenant(string tenantId)
        {
            throw new System.NotImplementedException();
        }
    }
}