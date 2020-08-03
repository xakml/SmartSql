using SmartSql.Test.Entities;
using System.Collections.Generic;

namespace SmartSql.Sample.AspNetCore1.DyRepositories
{
    public interface ICustomerRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(Customer entity);

        IEnumerable<Customer> SelectAll();
    }
}
