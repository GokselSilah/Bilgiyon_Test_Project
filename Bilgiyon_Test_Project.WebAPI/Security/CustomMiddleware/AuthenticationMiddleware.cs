using Bilgiyon_Test_Project.Business.Abstract;
using Bilgiyon_Test_Project.Entity.Concrete;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Bilgiyon_Test_Project.WebAPI.Security.CustomMiddleware
{
    public class AuthenticationMiddleware
    {
        private readonly IUserService userService;
        private readonly IEventService eventService;
        LogonUser logonUser = new LogonUser();
        private readonly RequestDelegate _next;
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];


            if (authHeader == null)
            {
                await _next(context);
                return;
            }

            else if (authHeader != null && authHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    var token = authHeader.Substring("Basic ".Length).Trim();
                    var credentialString = JsonConvert.DeserializeObject<LogonUser>(Encoding.UTF8.GetString(Convert.FromBase64String(token)));



                    var claims = new[]
                    {
                                new Claim("username",credentialString.UserName),
                                new Claim("password",credentialString.Password)
                            };
                    var identity = new ClaimsIdentity(claims, "Basic");
                    context.User = new ClaimsPrincipal(identity);
                }
                catch
                {
                    context.Response.StatusCode = 401;
                    return;

                }



            }
            else
            {
                context.Response.StatusCode = 401;
            }


            await _next(context);
        }
    }
}
