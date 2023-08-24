using Bilgiyon_Test_Project.Business.Concrete;
using Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework;
using Bilgiyon_Test_Project.Entity.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace Bilgiyon_Test_Project.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());

            LogonUser logonUser = new LogonUser()
            {
                UserName = "Alford.Bayer",
                Password = "Brice Pfeffer"
            };

            userManager.LoginUser(logonUser);
            //Console.WriteLine(userManager.LoginUser(logonUser).UserMessage);
            Console.WriteLine(userManager.LoginUser(logonUser).IsSucceeded);
            Console.WriteLine(logonUser.Token);

            


            //EventManager eventManager = new EventManager(new EfEventDal());
            //foreach (var @event in eventManager.GetAll())
            //{
            //    Console.WriteLine(@event.EVT_CODE + "-----" + @event.EVT_DESC);
            //}

            //foreach (var item in eventManager.GetEvents(new LogonUser() { UserName = "Alford.Bayer" }).TransactionResult)
            //{
            //    Console.WriteLine(item.WorkOrderCode + "-------" + item.WorkOrderDescription);
            //}







        }
    }
}