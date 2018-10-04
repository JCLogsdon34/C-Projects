using JCL.Banker.BLL;
using JCL.Banker.Model.Responses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCL.Banker.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {

        private const string _filePath = @"C:\Data\Banker\Accounts.txt";
        private const string _originalData = @"C:\Data\Banker\AccountsTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);

        }
    }
}
