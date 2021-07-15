//namespace BuildingManagementSystem.Data.Seeding
//{
//    using System;
//    using System.Threading.Tasks;

//    using BuildingManagementSystem.Common;
//    using BuildingManagementSystem.Data.Models.BuildingData;

//    public class PropertyTypeSeeder : ISeeder
//    {
//        public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
//        {
//            var type = serviceProvider.GetRequiredService<RoleManager<PropertyType>>();

//            await SeedPropertyTypeAsync(type, GlobalConstants.ShopPropertyType);
//            await SeedPropertyTypeAsync(type, GlobalConstants.AppartmentPropertyType);
//            await SeedPropertyTypeAsync(type, GlobalConstants.StudioPropertyType);
//        }

//        private static async Task SeedPropertyTypeAsync(RoleManager<PropertyType> roleManager, string propertyType)
//        {
//            var role = await roleManager.FindByNameAsync(propertyType);
//            if (role == null)
//            {
//                var result = await roleManager.CreateAsync(new PropertyType(propertyType));
//                if (!result.Succeeded)
//                {
//                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
//                }
//            }
//        }
//    }
//}
