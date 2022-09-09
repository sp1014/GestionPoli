using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_Academico.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string NameCourse { get; set; }
        public int WeeklyHours { get; set;}
    }
}
