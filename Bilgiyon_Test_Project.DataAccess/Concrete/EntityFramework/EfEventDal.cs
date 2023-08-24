using Bilgiyon_Test_Project.DataAccess.Abstract;
using Bilgiyon_Test_Project.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework
{
    public class EfEventDal : IEntityRepository<Event> , IEventDal
    {
        public List<Event> GetEvents(LogonUser logonUser)
        {
            using (BilgiyonDemoContext context = new BilgiyonDemoContext())
            {
                List<Event> events = context.Set<Event>().Where(e => e.EVT_USER == logonUser.UserName).ToList();
                return events;
            }
        }

        public List<Event> GetAll()
        {
            using (BilgiyonDemoContext context = new BilgiyonDemoContext())
            {
                return context.Set<Event>().ToList();
            }
        }
    }
}
