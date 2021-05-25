﻿namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class ServiceType : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de servicio")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        public string Name { get; set; }
    }
}