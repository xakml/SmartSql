using System;

namespace SmartSql.SimpleTest.Entities
{
    public class User
    {
        public User()
        {
        }

        public User(long id)
        {
            Id = id;
        }

        public User(long id, string name)
        {
            Id = id;
            User_Name = name;
        }

        public User(long id, string name, UserStatus status)
        {
            Id = id;
            User_Name = name;
            Status = status;
        }

        public virtual long Id { get; set; }
        public virtual String User_Name { get; set; }
        public virtual UserStatus Status { get; set; }
    }

    public enum UserStatus : Int16
    {
        Ok = 1
    }
}
