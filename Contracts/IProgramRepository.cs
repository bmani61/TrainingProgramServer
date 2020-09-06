using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
namespace Contracts
{
    public interface IProgramRepository : IRepositoryBase<Programs>
    {
        IEnumerable<Programs> GetAllPrograms();

        Programs GetProgramById(Guid ID);

        void CreateProgram(Programs Program);
        void UpdateProgram(Programs Program);
    }
}
