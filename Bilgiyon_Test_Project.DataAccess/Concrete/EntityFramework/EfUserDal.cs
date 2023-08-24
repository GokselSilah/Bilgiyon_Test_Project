using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.DataAccess.Abstract;
using Bilgiyon_Test_Project.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {
        public List<User> GetAll()
        {
            using (BilgiyonDemoContext context = new BilgiyonDemoContext())
            {
                return context.Set<User>().ToList();
            }
        }

        public User LoginUser(LogonUser user)
        {
            using (BilgiyonDemoContext context = new BilgiyonDemoContext())
            {
                User loginingUser = context.Set<User>().SingleOrDefault(u=> u.USR_CODE == user.UserName && u.USR_DESC == user.Password);
                return loginingUser;
            }
        }
    }
}
