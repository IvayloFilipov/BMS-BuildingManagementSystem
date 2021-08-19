namespace BuildingManagementSystem.Services.Data.Tests.Mock
{
    using System;

    using BuildingManagementSystem.Data;
    using Microsoft.EntityFrameworkCore;

    public static class DataBaseMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

                return new ApplicationDbContext(dbContextOptions);
            }
        }
    }
}
