
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Net.Models.Products
{
    public class Product
    {
        [Key]
        public int IdPro {get; set;}

        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required]
        public string namePro { get; set;}

    }
}