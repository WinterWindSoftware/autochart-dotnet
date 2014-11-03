using System;
using NUnit.Framework;
using AutoChart.Sdk;

namespace SdkTests
{
    [TestFixture]
    public class VisitorServiceTests
    {
        private static readonly string API_READ_KEY = System.Configuration.ConfigurationManager.AppSettings["AutoChartReadKey"];
        private const string TEST_API_URL = "https://portal.autochart.io/api/1"; // "http://dev.portal.autochart.io/api/1";

        [Test]
        public void Test_GetVisitorById()
        {
            var visitorId = "53eb6f208074fd5c417b1620";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummary(visitorId);
            Assert.IsNotNull(visitor);
            Assert.AreEqual(visitorId, visitor.VisitorId);
            var latestSearch = visitor.GetLatestSearch();
            Assert.IsNotNull(latestSearch);
            var latestLead = visitor.GetLatestLead();
            Assert.IsNotNull(latestLead);
        }

        [Test]
        public void Test_GetVisitorByEmail()
        {
            var email = "lizziehaynes@zisis.com";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitors = svc.GetVisitorsByEmail(email);
            Assert.IsNotNull(visitors);
            Assert.IsTrue(visitors.Length > 0);
        }

        [Test]
        public void Test_LatestVehicleViews()
        {
            var visitorId = "53eb6f208074fd5c417b1620";
            var visitor = new VisitorService(API_READ_KEY, TEST_API_URL).GetVisitorSummary(visitorId);
            int limit = 4;
            var latestVehicleViews = visitor.LatestVehicleViews(limit);
            Assert.IsNotEmpty(latestVehicleViews);
            Assert.LessOrEqual(latestVehicleViews.Count, limit);
        }

        [Test]
        public void Test_LatestSearchCriteria()
        {
            var visitorId = "53eb6f208074fd5c417b1620";
            var visitor = new VisitorService(API_READ_KEY, TEST_API_URL).GetVisitorSummary(visitorId);
            var latestSearch = visitor.LatestSearch();
            Assert.IsNotNull(latestSearch);
        }
    }
}
