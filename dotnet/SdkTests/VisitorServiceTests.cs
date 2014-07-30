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
            var context = AutoChartVisitorContext.Load();
            var svc = new VisitorService();
            var visitor = svc.GetVisitorSummary(context.VisitorId); 
        }
    }
}
