namespace Shop.Web.Data.Entities
{

    using System.ComponentModel.DataAnnotations;

    
    public class Mechanical :IEntity
    {
       
        public int Id { get; set; }

        [Required]
        [Display(Name = "Documento")]        
        [MaxLength(12, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string AccountNumber { get; set; }

        public int AccountTypeId { get; set; }
        public virtual DocType AccountType { get; set; }

        [Required]
        [Display(Name = "Nombre")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Segundo Nombre")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Apellido")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string LastSurname { get; set; }

        [Required]
        [Display(Name = "Celular")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Cellphonenumber { get; set; }

        [Required]
        [Display(Name = "Direccion")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Email")]        
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Estado")]
        [MaxLength(1, ErrorMessage = "The field {0} only can contain {1} characters length.")]        
        public string Status { get; set; }

    }
}
