using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Api_Academico.Models
{
    public class Califications
    {
        public int Id { get; set; }
        public int Calification1 { get; set; }
        public int Calification2 { get; set; }
        public int Calification3 { get; set; }
        public int CalificationFinal { get; set; }
    }
}
