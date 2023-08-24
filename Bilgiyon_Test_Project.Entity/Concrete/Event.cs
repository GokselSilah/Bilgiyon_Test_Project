using Bilgiyon_Test_Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.Entity.Concrete
{
    public class Event : IEntity
    {
        [Key]
        public string EVT_CODE { get; set; }
        public string EVT_DESC { get; set;}
        public string EVT_USER { get; set;}
    }
}
