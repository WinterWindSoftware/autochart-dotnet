using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoChart.Sdk;

namespace SdkTests
{
    [TestClass]
    public class VisitorServiceTests
    {
        private const string API_READ_KEY = "rk_012345678901234567890123";
        private const string TEST_API_URL = "http://dev.portal.autochart.io/api/1";

        [TestMethod]
        public void Test_GetVisitorById()
        {
            var visitorId = "53cf8ee65f9c61490c000001";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummary(visitorId);
            Assert.IsNotNull(visitor);
            Assert.AreEqual(visitorId, visitor.VisitorId);
            var latestSearch = visitor.GetLatestSearch();
            Assert.IsNotNull(latestSearch);
            var latestLead = visitor.GetLatestLead();
            Assert.IsNotNull(latestLead);
        }

        [TestMethod]
        public void Test_GetVisitorByEmail()
        {
            var email = "test@example.com";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitors = svc.GetVisitorsByEmail(email);
            Assert.IsNotNull(visitors);
            Assert.IsTrue(visitors.Length > 0);
        }
    }
}
