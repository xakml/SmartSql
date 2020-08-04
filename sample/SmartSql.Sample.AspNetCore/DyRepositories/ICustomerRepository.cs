using SmartSql.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSql.Sample.AspNetCore.DyRepositories
{
    public interface ICustomerRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(Customer entity);
    }
}
