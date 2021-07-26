namespace BuildingManagementSystem.Web.Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        // Getting currently logged User Id
        public static string GetId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            return userId;
        }
    }
}
