
namespace Shop.Web.Data.Entities
{

    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Preventivo, correctivo, predictivo, parte o repuesto 
    /// </summary>
    //public enum ServiceType { preventive, corrective, predictive, part }

    public class PartMaster :IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ServiceTypeId { get; set; }
        public virtual ServiceType ServiceType { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Note { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Precio Minimo servicio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal MinPrice { get; set; }

        [Required]
        [Display(Name = "Precio Maximo servicio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal MaxPrice { get; set; }

        [Required]        
        public int Quantity { get; set; }

    }
}
