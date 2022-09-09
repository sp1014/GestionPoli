using System.ComponentModel.DataAnnotations;

namespace Api_Academico.Models
{
    public class Lounge
    {
        [Key]
        public int Id { get; set; }
        public string NameLounge { get; set; }
        public string Location { get; set; }
    }
}
