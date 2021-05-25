namespace Shop.Web.Data.Entities
{

    using System;
    using System.ComponentModel.DataAnnotations;

    public class InvoiceLines
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Factura")]
        public InvoiceHeader InvoiceHeader { get; set; }

        [Display(Name = "Linea de servicio")]
        public ServiceLine ServiceLine { get; set; }
                        
        [Required]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Descuento")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Discount { get; set; }

        [Required]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        

    }
}
