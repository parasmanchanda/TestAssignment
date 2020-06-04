using Entities;
using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class CountryCodeRepository : GenericRepository<CountryCode>, ICountryCodeRepository
    {
        public CountryCodeRepository(StudentManagementContext context) : base(context)
        {

        }
    }
}
