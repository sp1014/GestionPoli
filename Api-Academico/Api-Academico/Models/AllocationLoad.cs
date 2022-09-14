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
        [Key]
        public int Id { get; set; }
        public DateTime DateAllocationLoad { get; set; }

        [ForeignKey("Course")]
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("User")]
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Grade")]
        public int IdGrade { get; set; }
        public virtual Grade Grade { get; set; }

        [ForeignKey("Califications")]
        public int IdCalifications { get; set; }
        public virtual Califications Califications { get; set; }

    }
}
