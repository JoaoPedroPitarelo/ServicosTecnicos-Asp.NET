using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicosTecnicos.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_funcionario { get; set; }

        [StringLength(60)]
        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        [Display(Name = "Nome do funcionário: ", Prompt = "Digite o nome do funcionário: ", Description = "nome funcionário")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo nascimento é obrigatório!")]
        [Display(Name = "Data de nascimento: ", Prompt = "Digite a data de nascimento: ", Description = "data nascimento funcionário")]
        public DateOnly data_nascimento { get; set; }

        [Required(ErrorMessage = "Endereço é um campo obrigatório!")]
        [Display(Name = "Endereço: ", Prompt = "Digite o endereço: ", Description = "endereço funconário")]
        [StringLength(80)]
        public string endereco { get; set; }

        [Required(ErrorMessage = "Campo departamento é obrigatório")]
        [Display(Name = "Departamento: ", Description = "departamento funcionário")]
        public int id_departamento { get; set; }

        [ForeignKey("id_departamento")]
        [Display(Name = "Departamento: ", Description = "departamento funcionário")]
        public Departamento departamento { get; set; }
    }
}
