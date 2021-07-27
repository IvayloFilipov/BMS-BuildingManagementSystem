namespace BuildingManagementSystem.Web.Infrastructure
{
    using System.Security.Claims;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public static class ClaimsPrincipalExtensions
    {
        // Getting currently logged User Id
        public static string GetId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
        }

        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            var result = user.IsInRole(AdministratorRoleName);

            return result;
        }

        public static bool IsOwner(this ClaimsPrincipal user)
        {
            var result = user.IsInRole(OwnerRoleName);

            return result;
        }

        public static bool IsTenant(this ClaimsPrincipal user)
        {
            var result = user.IsInRole(TenantRoleName);

            return result;
        }
    }
}
