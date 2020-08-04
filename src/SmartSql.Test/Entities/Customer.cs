using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSql.Test.Entities
{
    public class Customer
    {
        public Customer()
        {

        }
        public Customer(long id)
        {
            this.Id = id;
        }
        public Customer(long id, string name    ):this(id)
        {
            this.Name = name;
        }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
