
namespace Shop.Web.Data.Entities
{      
    using System.ComponentModel.DataAnnotations;    
    
    public class Customer : IEntity
    {

        public int Id { get; set; }

        [Required]        
        [Display(Name = "Documento")]        
        [MaxLength(12, ErrorMessage = "The field {0} only can contain {1} characters length.")]        
        public string AccountNumber { get; set; }
        
        /*
        [Required]
        [Display(Name = "Tipo de documento")]
        */
        public int AccountTypeId { get; set; }
        public virtual DocType AccountType { get; set; }

        [Required]
        [Display(Name = "Nombre")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }

        [Display(Name = "Segundo Nombre")] 
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Apellido")]        
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string SurName { get; set; }
        
        [Display(Name = "Segundo Apellido")]        
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string  LastSurName { get; set; }

        [Required]
        [Display(Name = "Celular")]        
        [MaxLength(15, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Cellphonenumber { get; set; }

        [Required]
        [Display(Name = "Direccion")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]        
        [MaxLength(30, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Email { get; set; }        

        
        [Required]
        [Display(Name = "Presupuesto")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Budget { get; set; }        
        
    }
}
