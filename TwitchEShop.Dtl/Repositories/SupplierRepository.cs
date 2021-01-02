using System;
using System.Collections.Generic;
using System.Text;
using TwitchEShop.Domain.Interfaces;
using TwitchEShop.Domain.Models;

namespace TwitchEShop.Dal.Repositories
{
    public class SupplierRepository:BaseRepository<Supplier>,ISupplierRepository
    {
        public SupplierRepository(EShopDBContext context):base(context)
        {

        }
    }
}
