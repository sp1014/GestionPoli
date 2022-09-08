using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_Academico.Models
{
    public class Follow_upCourse
    {
       public int Id { get; set; }
        public DateTime DateFollowUp { get; set; }
    }
}
