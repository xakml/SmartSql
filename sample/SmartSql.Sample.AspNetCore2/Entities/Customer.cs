using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSql.Sample.AspNetCore2.Entities
{
    public class Customer
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Customer()
        {

        }
        public Customer(long id)
        {
            this.Id = id;
        }
        public Customer(long id, string name) : this(id)
        {
            this.Name = name;
        }

    }
}
