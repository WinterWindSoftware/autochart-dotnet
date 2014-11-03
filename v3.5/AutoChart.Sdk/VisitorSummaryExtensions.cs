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

        public static VisitorBudget GetBudget(this VisitorSummary visitor)
        {
            foreach (var search in visitor.Searches.OrderByDescending(s => s.Timestamp))
            {
                if(search.HasBudgetCriteria())
                {
                    return new VisitorBudget()
                    {
                        PriceMin = search.Criteria.PriceMin,
                        PriceMax = search.Criteria.PriceMax,
                        FinanceDownPayment = search.Criteria.FinanceDownPayment,
                        FinanceInterestRate = search.Criteria.FinanceInterestRate,
                        FinanceMinMonthlyRepayment = search.Criteria.FinanceMinMonthlyRepayment,
                        FinanceMaxMonthlyRepayment = search.Criteria.FinanceMaxMonthlyRepayment
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// Whether or not specifed search has 1 or more budget-related search criteria fields specified.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static bool HasBudgetCriteria(this VehicleSearch search)
        {
            return search.Criteria.PriceMin.HasValue 
                || search.Criteria.PriceMax.HasValue
                || search.Criteria.FinanceDownPayment.HasValue
                || search.Criteria.FinanceMinMonthlyRepayment.HasValue
                || search.Criteria.FinanceMaxMonthlyRepayment.HasValue;
        }
    }
}
