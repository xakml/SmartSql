﻿using SmartSql.Test.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SmartSql.Test.Unit.CUD
{
    [Collection("GlobalSmartSql")]
    public class CUDTest
    {
        protected ISqlMapper SqlMapper { get; }

        public CUDTest(SmartSqlFixture smartSqlFixture)
        {
            SqlMapper = smartSqlFixture.SqlMapper;
        }

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
                successed_count += recordsAffected;
            };
            Assert.Equal(7, successed_count);
        }

        [Fact]
        public void Insert_Return_Id()
        {
            AllPrimitive insertEntity = InsertReturnIdImpl(out long id);
            Assert.NotEqual(0, id);
            Assert.Equal(id, insertEntity.Id);
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

        [Fact]
        public void UpdateByTrack()
        {
            InsertReturnIdImpl(out long id0);
            var entity = SqlMapper.GetById<AllPrimitive, long>(id0, true);
            entity.String = "Updated";
            SqlMapper.Update(entity);
        }
    }
}