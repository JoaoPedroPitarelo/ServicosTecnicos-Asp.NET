using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServicosTecnicos.Models
{
    [Table("maquina")]
    public class Maquina
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int patrimonio { get; set; }

        [Required(ErrorMessage = "A marca é um campo obrigatório!")]
        [StringLength(50)]
        [Display(Name = "Marca da máquina: ", Prompt = "Digite a marca da máquina: ", Description = "Marca da máquina")]
        public string marca { get; set; }

        [Required(ErrorMessage = "O modelo é um campo obrigatório!")]
        [StringLength(50)]
        [Display(Name = "Modelo da máquina: ", Prompt = "Digite o modelo da máquina: ", Description = "Modelo da máquina")]
        public string modelo { get; set; }
    }
}
