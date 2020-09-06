using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IProgramRepository Programs { get; }
        IModuleRepository Module { get; }
        void Save();
    }
}
