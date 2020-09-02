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
        /// ���Ա��浥��ʵ����,ʹ��map�ļ����ֶ���д��sql�ű�,�ű�ID��Ҫ�ֶ�ָ��
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
                UserName = "chenger-" + DateTime.Now.ToLongTimeString()
            };
            long recordsAffected = SqlMapper.ExecuteScalar<long>(new RequestContext() 
            {
                Scope="User",
                SqlId = "Insert-1",
                Request = user
            });

            //System.Threading.Thread.Sleep(1000);
            //user = new Entities.User()
            //{
            //    Status = Entities.UserStatus.Ok,
            //    User_Name = "chenger-" + DateTime.Now.ToLongTimeString()
            //};
            //recordsAffected = SqlMapper.Insert<Entities.User>(user);
            Console.WriteLine($"recordsAffected={recordsAffected}");
            Assert.AreEqual(1, recordsAffected);
        }

        /// <summary>
        /// ����ʹ��Ĭ�ϵ�INSERT��䱣���¼�¼
        /// ��Ҫʹ��<code>SmartSql.Annotations.Table("ʵ�ʵı�����")</code>
        /// </summary>
        [TestMethod]
        public void TestInsertUseDefaultSql()
        {
          var user = new Entities.User()
            {
                Status = Entities.UserStatus.Ok,
                UserName = "chenger-" + DateTime.Now.ToLongTimeString()
            };
            int recordsAffected = SqlMapper.Insert<Entities.User>(user);
            Console.WriteLine($"recordsAffected={recordsAffected}");
            Assert.AreEqual(1, recordsAffected);
        }

        private Entities.User GetUser(long id)
        {
            var user = SqlMapper.QuerySingle<Entities.User>(new RequestContext
            {
                Scope = "User",
                SqlId = "GetUser",
                Request = new
                {
                    Id = id
                },
            });
            return user;
        }

        [TestMethod]
        public void TestGetUser()
        {
            Entities.User user = this.GetUser(6);
            if (user != null)
                Console.WriteLine(user.UserName);
            else
                Console.WriteLine("user is null");
        }
    }
}
