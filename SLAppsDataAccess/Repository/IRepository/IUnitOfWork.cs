using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLAppsDataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IClientRepository Client { get; }

        [ValidateNever]
        IProductRepository Product { get; }
        IRoleRepository Role { get; }
        void Save();
    }
}
