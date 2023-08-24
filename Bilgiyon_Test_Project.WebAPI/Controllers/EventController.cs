using Bilgiyon_Test_Project.Business.Abstract;
using Bilgiyon_Test_Project.Business.Concrete;
using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework;
using Bilgiyon_Test_Project.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bilgiyon_Test_Project.WebAPI.Controllers
{
    [Route("Infor/Mobil/WorkOrder/Get")]
    [ApiController]
    public class EventController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public MobilResult<List<WorkOrderModel>> GetEvents(LogonUser logonUser)
        {
            IEventService eventManager = new EventManager(new EfEventDal());
            var result = eventManager.GetEvents(logonUser);
            return result;
        }
    }
}
