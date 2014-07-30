using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoChart.Sdk;

namespace SdkTests
{
    [TestClass]
    public class VisitorServiceTests
    {
        [TestMethod]
        public void TestGetVisitor()
        {
            var context = AutoChartHttpContext.Load();
            var svc = new VisitorService();
            var visitor = svc.GetVisitorSummary(context.VisitorId);
        }
    }
}
