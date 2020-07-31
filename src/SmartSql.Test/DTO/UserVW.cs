using System;

namespace SmartSql.Test.DTO
{
    public class UserVW
    {

        public UserVW()
        {
        }

        public UserVW(long id)
        {
            Id = id;
        }

        public UserVW(long id, string name)
        {
            Id = id;
            UserName = name;
        }

        public UserVW(long id, string name, UserStatusVW status)
        {
            Id = id;
            UserName = name;
            Status = status;
        }

        public virtual long Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual UserStatusVW Status { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

    }

    public enum UserStatusVW : Int16
    {
        Ok = 1
    }
}
