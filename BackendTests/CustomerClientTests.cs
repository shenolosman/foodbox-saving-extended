﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Backend;
using Xunit;

namespace BackendTests
{
    public class CustomerClientTests
    {
      //public AdminBackend adminBackend = new AdminBackend();

        [Fact]
        public void ClientFrontendTest()
        {
            AdminBackend.PrepDatabase();

            var UserList = AdminBackend.AllUsers();
            var UserNameList = new List<string>();
            string username = "Emmy";

            foreach (var user in UserList)
            {
                UserNameList.Add(user.Username);
            }

            bool loggedin = UserNameList.Contains(username);
            Assert.True(loggedin);
        }
    }
}
