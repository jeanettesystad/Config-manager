using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IAdminRepository
    {
        IEnumerable<Admin> Admins { get; }

        

    }
}
