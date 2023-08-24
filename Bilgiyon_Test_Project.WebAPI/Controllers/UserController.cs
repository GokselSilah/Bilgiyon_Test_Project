using Bilgiyon_Test_Project.Business.Abstract;
using Bilgiyon_Test_Project.Business.Concrete;
using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework;
using Bilgiyon_Test_Project.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Bilgiyon_Test_Project.WebAPI.Controllers
{
    [Route("Infor/Mobil/LoginUser")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]        
        public MobilResult<LogonUser> LoginUser(LogonUser logonUser)
        {
            IUserService userManager = new UserManager(new EfUserDal());
            var result = userManager.LoginUser(logonUser);
            return result;
        }
    }
}
