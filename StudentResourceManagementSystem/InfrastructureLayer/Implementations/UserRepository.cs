using Entities;
using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepoisotry
    {
        public UserRepository(StudentManagementContext context)
            : base(context)
        {
        }
    }
}
