namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Store :IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Note { get; set; }


        [Required]
        [Display(Name = "Direccion")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Address { get; set; }

    }
}
