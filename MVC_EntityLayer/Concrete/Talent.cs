using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_EntityLayer.Concrete
{
    public class Talent
    {
        [Key]
        public int TalentID { get; set; }
        [StringLength(100)]
        public string TalentName { get; set; }
        public int TalentLevel { get; set; }
    }
}
