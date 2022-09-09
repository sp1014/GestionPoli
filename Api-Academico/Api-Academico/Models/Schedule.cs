using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_Academico.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public int Friday { get; set; }

          [ForeignKey("AllocationLoad")]
        public int IdAllocationLoad { get; set; }
        public virtual AllocationLoad AllocationLoad { get; set; }


    }
}
