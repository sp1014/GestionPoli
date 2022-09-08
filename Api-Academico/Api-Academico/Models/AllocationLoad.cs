using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_Academico.Models
{
    public class AllocationLoad
    {
        public int Id { get; set; }
        public DateTime DateAllocationLoad { get; set; }
    }
}
