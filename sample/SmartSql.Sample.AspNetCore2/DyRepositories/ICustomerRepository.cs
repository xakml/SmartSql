using System.Collections.Generic;

namespace SmartSql.Sample.AspNetCore2.DyRepositories
{
    public interface ICustomerRepository
    {
        ISqlMapper SqlMapper { get; }
        long Insert(Entities.Customer entity);

        IEnumerable<Entities.Customer> SelectAll();

        IEnumerable<Entities.Customer> SelectByCondition(DTO.CustomerQueryConditon conditon);
    }
}
