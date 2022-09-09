using System.ComponentModel.DataAnnotations;

namespace Api_Academico.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        public string CodGrade { get; set; }
    }
}
