using InfrastructureLayer.ContextClass;
using InfrastructureLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICountryCodeRepository _countryCodeRepository;
        private readonly IUserRepoisotry _userRepository;
        private readonly IResourceRepository _resourceRepository;
        private StudentManagementContext _studentManagementContext;

        public UnitOfWork(StudentManagementContext studentManagementContext)
        {
            _studentManagementContext = studentManagementContext;
        }

        public IStudentRepository StudentRepository => _studentRepository ?? new StudentRepository(_studentManagementContext);

        public IUserRepoisotry UserRepository => _userRepository ?? new UserRepository(_studentManagementContext);

        public ICountryCodeRepository CountryCodeRepository => _countryCodeRepository ?? new CountryCodeRepository(_studentManagementContext);

        public IResourceRepository ResourceRepository => _resourceRepository ?? new ResourceRepository(_studentManagementContext);

        public void Save()
        {
            _studentManagementContext.SaveChanges();
        }
    }
}
