namespace Shop.Web.Data.Entities
{

    using System;
    using System.ComponentModel.DataAnnotations;

    public class InvoiceHeader : IEntity
    {
        
        public int Id { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Display(Name = "Fecha")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }


        [Required]
        [Display(Name = "Sub Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal { get; set; }


        [Required]
        [Display(Name = "Descuento")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TotalDiscount { get; set; }

        [Required]
        [Display(Name = "IVA")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TotalIVA { get; set; }

        [Required]
        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Total { get; set; }


    }
}
