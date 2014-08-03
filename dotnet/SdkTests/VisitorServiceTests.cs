using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoChart.Sdk;

namespace SdkTests
{
    [TestClass]
    public class VisitorServiceTests
    {
        private const string API_READ_KEY = "rk_012345678901234567890123";
        private const string TEST_API_URL = "http://dev.portal.autochart.io/api";

        [TestMethod]
        public void Test_GetVisitorById()
        {
            var visitorId = "53cf8ee65f9c61490c000001";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummary(visitorId);
            Assert.IsNotNull(visitor);
            Assert.AreEqual(visitorId, visitor.VisitorId);
        }

        [TestMethod]
        public void Test_GetVisitorByEmail()
        {
            var email = "test@autochart.io";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummaryByEmail(email);
            Assert.IsNotNull(visitor);
        }
    }
}
