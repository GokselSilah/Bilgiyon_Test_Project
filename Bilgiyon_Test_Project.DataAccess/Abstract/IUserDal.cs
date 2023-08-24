using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {        
        public User LoginUser(LogonUser user);
    }
}
