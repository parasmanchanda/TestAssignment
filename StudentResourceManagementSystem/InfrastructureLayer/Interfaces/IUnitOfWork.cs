using System;
using System.Collections.Generic;
using System.Text;

namespace InfrastructureLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        IUserRepoisotry UserRepository { get; }
        ICountryCodeRepository CountryCodeRepository { get; }
        IResourceRepository ResourceRepository { get; }
        void Save();
    }
}
