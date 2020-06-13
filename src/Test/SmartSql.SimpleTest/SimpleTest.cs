/***
 *  2020-6-13 17:36:56
 *  ժҪ˵��: 
 *      �ٷ���demoʾ��Ĭ��ʹ�õ�SqlServer����,��������ѯ��ռλ������MySQL��ͬ,
 *      SqlServerʹ��"@"����; MySQLʹ��"?".
 *      �����Ǹ���, Ī������
 *      
 *      �ٷ��ĵ�����һ��� ��ʵû����
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
        /// ���Ա��浥��ʵ����
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
