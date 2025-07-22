using SmartSql.Annotations;
using System;


namespace SmartSql.Test.Entities
{
    [SmartSqlTable("t_user")]
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
            UserName = name;
        }

        public User(long id, string name, UserStatus status)
        {
            Id = id;
            UserName = name;
            Status = status;
        }

        [SmartSqlColumn("id",IsAutoIncrement = true,IsPrimaryKey =true)]
        public virtual long Id { get; set; }
        [SmartSqlColumn("user_name")]
        public virtual String UserName { get; set; }
        [SmartSqlColumn("status")]
        public virtual UserStatus Status { get; set; }
        [SmartSqlColumn("is_delete")]
        public virtual bool IsDelete { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(UserName)}={UserName}, {nameof(Status)}={Status.ToString()}, {nameof(IsDelete)}={IsDelete.ToString()}}}";
        }
    }

    public enum UserStatus : Int16
    {
        Ok = 1
    }
}