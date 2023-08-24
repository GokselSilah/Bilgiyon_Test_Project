using Bilgiyon_Test_Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgiyon_Test_Project.Entity.Concrete
{
    public class User : IEntity
    {
        [Key]
        public string USR_CODE { get; set; }
        public string USR_DESC { get; set; }
    }
}
