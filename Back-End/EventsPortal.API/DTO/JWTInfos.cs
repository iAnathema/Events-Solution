using System.Linq;
using System.Security.Claims;

namespace EventsPortal.API.DTO
{
    public static class JWTInfos
    {
        public static string UserName { get; set; }
        public static string Name { get; set; }
        public static string[] Roles { get; set; }
        public static string Program { get; set; }
        public static string Office { get; set; }
        public static string Department { get; set; }
        public static string Account { get; set; }
        public static string Email { get; set; }

        public static void Init(ClaimsPrincipal User)
        {
            UserName = User.GetJWTValue("username");
            Name = User.GetJWTValue("name");
            Roles = User.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToArray();
            Program = User.GetJWTValue("program");
            Office = User.GetJWTValue("office");
            Department = User.GetJWTValue("department");
            Account = User.GetJWTValue("account");
            Email = User.GetJWTValue("email");
        }

        public static string GetJWTValue(this ClaimsPrincipal claim, string type)
        {
            return claim.Claims.Where(c => c.Type == type).Select(c => c.Value).FirstOrDefault();
        }

    }
}
