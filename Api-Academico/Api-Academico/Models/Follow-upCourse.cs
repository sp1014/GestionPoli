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
        [Key]
       public int Id { get; set; }
        public DateTime DateFollowUp { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Grade")]
        public int IdGrade { get; set; }
        public virtual Grade Grade { get; set; }




    }
}
