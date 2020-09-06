using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProgramsRepository : RepositoryBase<Programs>, IProgramRepository
    {
        public ProgramsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProgram(Programs Program)
        {
            Create(Program);
        }

        public IEnumerable<Programs> GetAllPrograms()
        {
            return FindAll()
                  .OrderBy(Pr => Pr.ProgramCode)
                  .ToList();
        }

        public Programs GetProgramById(Guid ID)
        {
            return FindByCondition(Program => Program.Id.Equals(ID))
            .FirstOrDefault();
        }

        public void UpdateProgram(Programs Program)
        {
            Update(Program);
        }
    }
}
