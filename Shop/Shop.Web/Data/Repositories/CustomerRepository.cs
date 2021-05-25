namespace Shop.Web.Data.Repositories
{

    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly DataContext context;

        public CustomerRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
