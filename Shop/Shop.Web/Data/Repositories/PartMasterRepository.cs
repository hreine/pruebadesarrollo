

namespace Shop.Web.Data.Repositories
{

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Helpers;
    using Shop.Web.Models;

    public class PartMasterRepository : GenericRepository<PartMaster>, IPartMasterRepository
    {

        private readonly DataContext context;

        public PartMasterRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
