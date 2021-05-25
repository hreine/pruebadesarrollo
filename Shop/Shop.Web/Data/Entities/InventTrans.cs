namespace Shop.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class InventTrans : IEntity
    {
        public int Id { get; set; }
        
        public int PartMasterId { get; set; }
        public virtual PartMaster PartMaster { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]        
        public int Quantity { get; set; }

    }
}
