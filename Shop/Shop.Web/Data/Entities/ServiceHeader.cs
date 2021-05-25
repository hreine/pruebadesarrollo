namespace Shop.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum ServiceStatus { Programmed, Initiated, Finalized, Invoiced }

    public class ServiceHeader
    {
        
        public int Id { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Fecha de Inicio")]
        public DateTime InitDate { get; set; }

        [Display(Name = "Fecha Finalizado")]
        public DateTime? EndDate { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public Customer Customer { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        [MinLength(10, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Note { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public ServiceStatus ServiceStatus  { get; set; }

    }
}
