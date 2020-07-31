/***
 *  2020-6-13 17:36:56
 *  摘要说明: 
 *      官方的demo示例默认使用的SqlServer数据,参数化查询的占位符和与MySQL不同,
 *      SqlServer使用"@"符号; MySQL使用"?".
 *      这里是个坑, 莫名其妙
 *      
 *      官方文档看着一大堆 其实没卵用
 *  
 * 
 * **/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SmartSql.SimpleTest
{
    [TestClass]
    public class SimpleTest
    {
        protected static ISqlMapper SqlMapper { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            var smartSqlBuilder = new SmartSqlBuilder().UseXmlConfig().Build();
            SqlMapper = smartSqlBuilder.SqlMapper;
        }
        /// <summary>
        /// 测试保存单个实体类
        /// </summary>
        [TestMethod]
        public void TestInsertUser()
        {
            Entities.User user = null;
            //user = this.GetUser();
            //if (user != null)
            //{
            //    user.UserName = user.UserName + DateTime.Now.ToShortTimeString();
            //}
            user = new Entities.User()
            {
                Status = Entities.UserStatus.Ok,
                User_Name = "chenger-" + DateTime.Now.ToLongTimeString()
            };
            int recordsAffected = SqlMapper.Insert<Entities.User>(user);
            System.Threading.Thread.Sleep(1000);
            user = new Entities.User()
            {
                Status = Entities.UserStatus.Ok,
                User_Name = "chenger-" + DateTime.Now.ToLongTimeString()
            };
            recordsAffected = SqlMapper.Insert<Entities.User>(user);
            Assert.AreEqual(1, recordsAffected);
        }

        private Entities.User GetUser()
        {
            var user = SqlMapper.QuerySingle<Entities.User>(new RequestContext
            {
                Scope = "User",
                SqlId = "GetUser",
                Request = new
                {
                    Id = 22
                },
            });
            return user;
        }

        [TestMethod]
        public void TestGetUser()
        {
            Entities.User user = this.GetUser();
            if (user != null)
                Console.WriteLine(user.User_Name);
            else
                Console.WriteLine("user is null");
        }
    }
}
