/***
 * CURD
 * 在软件开发中，“CURD” 是对数据库操作中最基本、最核心的四种操作的缩写，分别代表：
    ​C - Create（创建）​​向数据库中插入（新增）数据记录。例如：添加一个新用户到用户表。

​    U - Update（更新）​​修改数据库中已存在的记录。例如：更新用户的邮箱地址。

​    R - Read（读取）​​从数据库中查询（检索）数据记录。例如：查询所有活跃用户的信息。

    ​D - Delete（删除）​​从数据库中移除数据记录。例如：删除一个已注销的用户账户。
 * 
 * **/

using SmartSql.Test.Entities;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace SmartSql.Test.Unit.CUD
{
    [Collection("GlobalSmartSql")]
    public class CUDTest
    {
        protected ISqlMapper SqlMapper { get; }
        private readonly ITestOutputHelper _output;

        public CUDTest(SmartSqlFixture smartSqlFixture, ITestOutputHelper output)
        {
            SqlMapper = smartSqlFixture.SqlMapper;
            _output = output;
        }

        #region Get
        [Fact]
        public void Get()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            var entity = SqlMapper.GetById<AllPrimitive, long>(id);
            Assert.NotNull(entity);
        }

        [Fact]
        public void GetWithPropertyTrack()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            var entity = SqlMapper.GetById<AllPrimitive, long>(id, true);
            Assert.NotNull(entity);
        }
        #endregion

        #region INSERT

        [Fact]
        public void Insert()
        {
            var insertEntity = new AllPrimitive
            {
                String = "Insert",
                DateTime = DateTime.Now
            };
            var recordsAffected = SqlMapper.Insert<AllPrimitive>(insertEntity);
            Assert.NotEqual(0, recordsAffected);
        }

        [Fact]
        public void InsertUser()
        {
            int successed_count = 0;
            for (int i = 3; i < 10; i++)
            {
                var insertEntity = new User
                {
                    //Id = i,// 若主键字段为自增时, 可不主动设置此属性值
                    Status = UserStatus.Ok,
                    UserName = "chenger-" + i.ToString()
                };
                var recordsAffected = SqlMapper.Insert<User>(insertEntity);
                Console.WriteLine($"主键值：{insertEntity.Id}");
                successed_count += recordsAffected;
            };
            Assert.Equal(7, successed_count);
        }
        /// <summary>
        /// 插入新记录，并返回自增字段的最新值
        /// </summary>
        [Fact]
        public void InsertUserSingle()
        {
            var insertEntity = new User
            {
                //Id = i,// 若主键字段为自增时, 可不主动设置此属性值
                Status = UserStatus.Ok,
                UserName = "uname-" + DateTime.Now.ToString("yyMMddHHmmss")
            };
            long id = SqlMapper.Insert<User,long>(insertEntity);
            //var recordsAffected = SqlMapper.ExecuteScalar<long>(new RequestContext() 
            //{
            //    Scope = "User",
            //     SqlId = "Insert",
            //     Request = insertEntity
            //});
            System.Diagnostics.Trace.WriteLine($"主键值：{id}");
            this._output.WriteLine($"主键值1：{id}");
        }

        [Fact]
        public void Insert_Return_Id()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            Assert.NotEqual(0, id);
            Assert.Equal(id, insertEntity.Id);
            Console.WriteLine(id);
        }

        private AllPrimitive InsertReturnIdImpl(out long id)
        {
            var insertEntity = new AllPrimitive
            {
                String = "Insert",
                DateTime = DateTime.Now
            };
            id = SqlMapper.Insert<AllPrimitive, long>(insertEntity);
            return insertEntity;
        }
        #endregion

        #region Read

        [Fact]
        public void ReadOneUser()
        {
            User u = SqlMapper.GetById<User,long>(1);
            Console.WriteLine(u.ToString());
        }
        #endregion

        #region update
        [Fact]
        public void Update()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);

            var recordsAffected = SqlMapper.Update<AllPrimitive>(new AllPrimitive
            {
                Id = id,
                String = "Update",
                Boolean = true,
                DateTime = DateTime.Now
            });
            Assert.NotEqual(0, recordsAffected);
        }

        [Fact]
        public void DyUpdate()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            var recordsAffected = SqlMapper.DyUpdate<AllPrimitive>(new {Id = id, Boolean = true});
            Assert.NotEqual(0, recordsAffected);
        }

        [Fact]
        public void DyUpdate_Dic()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            var recordsAffected = SqlMapper.DyUpdate<AllPrimitive>(new Dictionary<String, object>
            {
                {"Id", id},
                {"Boolean", true}
            });
            Assert.NotEqual(0, recordsAffected);
        }

        [Fact]
        public void UpdateByTrack()
        {
            InsertReturnIdImpl(out long id0);
            var entity = SqlMapper.GetById<AllPrimitive, long>(id0, true);
            entity.String = "Updated";
            SqlMapper.Update(entity);
        }

        #endregion

        #region Delete
        [Fact]
        public void DeleteById()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            var recordsAffected = SqlMapper.DeleteById<AllPrimitive, long>(id);
            Assert.NotEqual(0, recordsAffected);
        }

        [Fact]
        public void DeleteMany()
        {
            InsertReturnIdImpl(out long id0);
            InsertReturnIdImpl(out long id1);
            InsertReturnIdImpl(out long id2);
            var recordsAffected = SqlMapper.DeleteMany<AllPrimitive, long>(new long[] {id0, id1, id2});
            Assert.Equal(3, recordsAffected);
        }

        #endregion

        [Fact]
        public void QueryByExpression()
        {
            var list = this.SqlMapper.Queryable<User>().Select(o => new Obj1 { Name = o.UserName }).ToList<Obj1>();
            Assert.NotNull(list);
            //Assert.Equals
        }
    }

    public sealed class Obj1
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}}}";
        }
    }
}