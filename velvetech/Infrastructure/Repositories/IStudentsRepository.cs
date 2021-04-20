using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace velvetech.Infrastructure
{
    public interface IStudentsRepository
    {
        Task<IStudent> SelectById(Guid id);

        Task<IEnumerable<IStudent>> SelectAll();

        Task<IEnumerable<IStudent>> SelectByAlias(string alias);

        Task Insert(IStudent entity);

        Task Update(IStudent entity);
    }
}
