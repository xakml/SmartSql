using SmartSql.Test.Entities;
using System;

namespace SmartSql.Sample.Repos
{
    public interface ICustomerRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(Customer entity);
    }
}
