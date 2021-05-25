namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    
    public class ServiceLine
    {

        [Key]
        public int Id { get; set; }
      
        [Required]        
        public ServiceHeader ServiceHeader { get; set; }
                
        [Display(Name = "Repuesto / Servicio")]
        public PartMaster PartMaster { get; set; }

        [Display(Name = "Mecanico")]
        public Mechanical Mechanical { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Note { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

    }
}
