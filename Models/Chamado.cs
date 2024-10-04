using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicosTecnicos.Models
{
    [Table("chamado")]
    public class Chamado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_chamado { get; set; }

        [Required(ErrorMessage="Campo funcionário é obrigatório")]
        [Display(Name = "Nome do funcionário: ", Description = "nome funcionário")]
        public int id_funcionario { get; set; }

        [ForeignKey("id_funcionario")]
        [Display(Name = "Nome do funcionário: ", Description = "nome funcionário")]
        public Funcionario funcionario { get; set; }

        [Required(ErrorMessage = "O campo máquina é obrigatório!")]
        [Display(Name = "Modelo da máquina: ", Description = "máquina")]
        public int patrimonio { get; set; }

        [ForeignKey("patrimonio")]
        [Display(Name = "Modelo da máquina: ", Description = "máquina")]
        public Maquina maquina { get; set; }

        [Required(ErrorMessage = "O campo técnico é obrigatório!")]
        [Display(Name = "Nome do técnico: ", Description = "Nome técnico")]
        public int id_tecnico { get; set; }

        [ForeignKey("id_tecnico")]
        [Display(Name = "Nome do técnico: ", Description = "Nome técnico")]
        public Tecnico tecnico { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório!")]
        [StringLength(255)]
        [Display(Name = "Descrição do problema: ", Prompt = "Digite a descrição do problema: ", Description = "Descrição problema")]
        public string descricao { get; set; }
    }
}
