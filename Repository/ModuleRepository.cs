using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class ModuleRepository : RepositoryBase<Module>,IModuleRepository
    {
        public ModuleRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
