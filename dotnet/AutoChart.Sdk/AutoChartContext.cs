﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Loads data related to a website visitor from AutoChart cookies available in current HTTP context
    /// </summary>
    public class AutoChartVisitorContext
    {
        private AutoChartVisitorContext() { }

        public string VisitorId { get; set; }
        public string SessionId { get; set; }

        public static AutoChartVisitorContext Load()
        {
            //TODO: read from cookie
            return new AutoChartVisitorContext();
        }
    }
}
