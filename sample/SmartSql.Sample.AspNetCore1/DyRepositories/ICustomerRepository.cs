using SmartSql.Test.Entities;

namespace SmartSql.Sample.AspNetCore1.DyRepositories
{
    public interface ICustomerRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(Customer entity);
    }
}
