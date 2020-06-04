using Entities;
using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
   public class ResourceRepository : GenericRepository<Resources>, IResourceRepository
    {
        public ResourceRepository(StudentManagementContext context)
            : base(context)
        {
        }
    }
}
