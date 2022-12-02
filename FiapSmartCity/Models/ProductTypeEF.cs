using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    [Table("PRODUCTTYPEEF")]
    public class ProductTypeEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeId { get; set; }

        [Column("TYPEDESCRIPTION")]
        [Required(ErrorMessage = "Descrição obrigatória!")]
        [StringLength(50,
                MinimumLength = 3,
                ErrorMessage = "A descrição deve ter, no mínimo 3 e, no máximo, 50 caracteres.")]
        [Display(Name = "Descrição:")]
        public string TypeDescription { get; set; }

        [Column("MARKETED")]
        [Display(Name = "Comercializado: ")]
        public bool Marketed { get; set; }
    }
}
