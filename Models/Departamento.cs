using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicosTecnicos.Models
{
    [Table("departamento")]
    public class Departamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_departamento { get; set; }

        [Display(Name = "Departamento: ", Prompt = "Digite o nome do departamento: ", Description = "Nome departamento")]
        [StringLength(80)]
        public string nome { get; set; }
    }
}
