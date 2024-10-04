using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicosTecnicos.Models
{
    [Table("tecnico")]
    public class Tecnico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tecnico { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório!")]
        [StringLength(80)]
        [Display(Name = "Nome do técnico: ", Prompt = "Digite o nome do técnico: ", Description = "nome técnico")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento é um campo obrigatório!")]
        [Display(Name = "Data de nascimento: ", Prompt = "Digite a data de nascimento: ", Description = "data nascimento técnico")]
        public DateOnly MyProperty { get; set; }

        [Required(ErrorMessage = "Endereço é um campo obrigatório!")]
        [Display(Name = "Endereço: ", Prompt = "Digite o endereço: ", Description = "endereço técnico")]
        [StringLength(80)]
        public string endereco { get; set; }
    }
}
