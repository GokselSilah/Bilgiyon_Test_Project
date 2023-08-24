using Bilgiyon_Test_Project.Business.Abstract;
using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.DataAccess.Abstract;
using Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework;
using Bilgiyon_Test_Project.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.Business.Concrete
{
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public List<Event> GetAll()
        {
            return _eventDal.GetAll();
        }

        public MobilResult<List<WorkOrderModel>> GetEvents(LogonUser logonUser)
        {
            IUserService userManager = new UserManager(new EfUserDal());
            var events = _eventDal.GetEvents(logonUser);
            List<WorkOrderModel> workOrders = new List<WorkOrderModel>();
            MobilResult<List<WorkOrderModel>> result = new MobilResult<List<WorkOrderModel>>();

            if (userManager.LoginUser(logonUser).IsSucceeded == false)
            {
                result.IsSucceeded = false;
                result.UserMessage = "Lütfen Kullanıcı Girişi Yapınız.";                
                return result;
            }
            else
            {
                foreach (var item in events)
                {
                    if (item.EVT_USER == logonUser.UserName)
                    {
                        WorkOrderModel workOrder = new WorkOrderModel();
                        workOrder.WorkOrderCode = item.EVT_CODE;
                        workOrder.WorkOrderDescription = item.EVT_DESC;
                        workOrders.Add(workOrder);
                    }
                }
                result.IsSucceeded = true;
                result.TransactionResult = workOrders;


                return result;
            }          

        }
    }
}
