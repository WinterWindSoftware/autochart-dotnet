using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Defines helper functions for selecting data from returned VisitorSummary object.
    /// </summary>
    public static class VisitorSummaryExtensions
    {
        /// <summary>
        /// Gets the last 5 vehicles the visitor viewed.
        /// </summary>
        /// <param name="visitor"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static List<VehicleView> LatestVehicleViews(this VisitorSummary visitor, int limit = 5)
        {
            return visitor.VehicleViews.OrderByDescending(v => v.Timestamp).Take(limit).ToList();
        }

        public static VehicleSearch LatestSearch(this VisitorSummary visitor)
        {
            return visitor.Searches.OrderByDescending(s => s.Timestamp).FirstOrDefault();
        }
    }
}
