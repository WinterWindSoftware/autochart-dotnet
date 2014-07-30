﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoChart.Sdk;

namespace SdkTests
{
    [TestClass]
    public class VisitorServiceTests
    {
        private const string API_READ_KEY = "01234567890123456789";
        private const string TEST_API_URL = "http://dev.portal.autochart.io/api";

        [TestMethod]
        public void Test_GetVisitorById()
        {
            var visitorId = "53cf8ee65f9c61490c000001";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummary(visitorId);
            Assert.IsNotNull(visitor);
        }

        [TestMethod]
        public void Test_GetVisitorByEmail()
        {
            var email = "test@autochart.io";
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummaryByEmail(email);
            Assert.IsNotNull(visitor);
        }

        [TestMethod]
        public void Test_GetVisitorByIdFromContext()
        {
            var svc = new VisitorService(API_READ_KEY, TEST_API_URL);
            var visitor = svc.GetVisitorSummary(AutoChartHttpContext.Current().VisitorId);
            Assert.IsNotNull(visitor);
        }
    }
}
