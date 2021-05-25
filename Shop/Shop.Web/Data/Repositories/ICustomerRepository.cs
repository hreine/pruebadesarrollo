namespace Shop.Web.Data.Repositories
{
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        //IQueryable GetAllWithUsers();
        //IEnumerable<SelectListItem> GetComboProducts();

    }
}
