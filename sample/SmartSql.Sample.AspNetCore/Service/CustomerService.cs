using SmartSql.AOP;
//using SmartSql.Sample.AspNetCore.DyRepositories;
using SmartSql.Sample.Repos;
using SmartSql.Test.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSql.Sample.AspNetCore.Service
{
    public class CustomerService
    {
        private readonly ICustomerRepository _userRepository;

        public CustomerService(ICustomerRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Transaction]
        public virtual long AddWithTranWrap(Customer customer)
        {
            return AddWithTran(customer);
        }
        [Transaction]
        public virtual long AddWithTran(Customer customer)
        {
            return _userRepository.Insert(customer);
        }

        public virtual Customer Get(long id)
        {
            return _userRepository.GetById(id);
        }
    }
}
