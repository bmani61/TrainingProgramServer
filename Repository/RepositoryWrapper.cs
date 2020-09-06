using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Contracts;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IProgramRepository _program;
        private IModuleRepository _module;

        public IProgramRepository Programs {
            get {
                if (_program == null)
                {
                    _program = new ProgramsRepository(_repoContext);
                }
                return _program;
            }
        }


        public IModuleRepository Module
        {
            get
            {
                if (_module == null)
                {
                    _module = new ModuleRepository(_repoContext);
                }
                return _module;
            }
        }
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
