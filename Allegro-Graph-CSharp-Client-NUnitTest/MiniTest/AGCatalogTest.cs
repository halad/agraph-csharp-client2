﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Allegro_Graph_CSharp_Client.AGClient.Util;
using Allegro_Graph_CSharp_Client.AGClient.Mini;

namespace Allegro_Graph_CSharp_Client_NUnitTest.MiniTest
{
    /// <summary>
    /// 测试AGCatalog类
    /// </summary>
    
    [TestFixture]
    class AGCatalogTest
    {
        private AGServerInfo server;
        private AGCatalog catalog;

       [Test]
       [TestFixtureSetUp]
        public void Init()
        {
            string baseUrl = "http://172.16.2.21:10035"; 
            string username = "chainyi";
            string password = "chainyi123";
            server = new AGServerInfo(baseUrl, username, password); 
            catalog = new AGCatalog(server, "chainyi");
          
        }

        ///<summary>
        /// 测试构造函数以及同样的参数是否返回同样的对象
        ///<summary>
        [Test]
        public void SameObjectTest()
        {
            string catalogName = "chainyi";
            AGCatalog catalog1 = new AGCatalog(server,catalogName);
            AGCatalog catalog2 = new AGCatalog(server, catalogName);
            Assert.AreNotSame(catalog1, catalog2);
        }

        /// <summary>
        /// 测试 OpenRepository()
        /// </summary>
        [Test]
        public void OpenRepositoryTest()
        {
            string repName = "chainyi";
            bool result = catalog.OpenRepository(repName) is AGRepository;
            Assert.IsTrue(result);
        }

        /// <summary>
        /// 测试 CreateRepository()
        /// </summary>
        [Test]
        public void CreateRepositoryTest()
        {
            string newRepName = "blizzard";
            Console.WriteLine(catalog.Url);
            //Console.WriteLine(catalog.Url + "/repositories/" + newRepName);
            catalog.CreateRepository(newRepName);
        }
    }
}
