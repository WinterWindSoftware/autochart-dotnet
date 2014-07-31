using System;
using System.Collections.Generic;

namespace AutoChart.Sdk
{
    /// <summary>
    /// Summary data of a visitor's history of actions.
    /// </summary>
    public class VisitorSummary
    {
        /// <summary>
        /// Unique ID of visitor
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Date visitor first visited site.
        /// </summary>
        public DateTime FirstSeen { get; set; }

        /// <summary>
        /// Time when visitor was last active on site.
        /// </summary>
        public DateTime LastActive { get; set;}

        /// <summary>
        /// History of all browsing sessions this visitor had on the site.
        /// </summary>
        public List<Session> Sessions { get; set; }

        /// <summary>
        /// Last search that this visitor performed
        /// </summary>
        public SearchCriteria LastSearch { get; set; }

        /// <summary>
        /// Tags which have been attributed to this visitor.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Purchase/visit intent actions which this visitor has taken, e.g. "Directions" or "Opening Hours"
        /// </summary>
        public List<string> VisitIntents { get; set; }

        /// <summary>
        /// Leads submitted by this visitor
        /// </summary>
        public List<LeadEnquiry> Leads { get; set; }

        /// <summary>
        /// List of different vehicles this visitor has viewed.
        /// </summary>
        public List<VehicleView> VehicleViews { get; set; }

        /// <summary>
        /// Email address provided in the most recent lead submitted by this visitor.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number provided in the most recent lead submitted by this visitor.
        /// </summary>
        public string PhoneNumber { get; set; }

    }

    /// <summary>
    /// Data relating to an enquiry the visitor has submitted
    /// </summary>
    public class LeadEnquiry
    {
        public string Id { get; set; }

        /// <summary>
        /// Time the enquiry was sent.
        /// </summary>
        public DateTime SentDate { get; set; }
        /// <summary>
        /// Subject of the enquiry, e.g
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of the enquiry
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// How the enquiry was sent, typically "WebForm" or "LiveChat".
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Vehicle which the enquiry was submitted about.
        /// Will be null if this is a general enquiry.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Contains data of a single browsing session of a visitor on the site.
    /// </summary>
    public class Session
    {
        public string Id { get; set; }
        /// <summary>
        /// Time session started.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Time of last action in session.
        /// </summary>
        public DateTime LastActionTime { get; set; }
        /// <summary>
        /// Number of different actions visitor took during this session.
        /// </summary>
        public int ActionCount { get; set; }

        /// <summary>
        /// Domain which referred user to the site (e.g. "google.co.uk"). 
        /// Will be "(direct)" if no referrer was set.
        /// </summary>
        public string ReferringDomain { get; set; }

        /// <summary>
        /// Geo-location of the session, if it could be determined.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Desktop/Tablet/Phone
        /// </summary>
        public string Device { get; set; }
    }

    /// <summary>
    /// Record of a visitor viewing a single vehicle (potentially more than once).
    /// </summary>
    public class VehicleView
    {
        /// <summary>
        /// Vehicle that was viewed.
        /// </summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>
        /// Number of times vehicle was viewed.
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Time this vehicle was last viewed
        /// </summary>
        public DateTime LastViewTime { get; set; }
    }

    /// <summary>
    /// Search criteria used to perform a search
    /// </summary>
    public class SearchCriteria
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string Condition { get; set; }
        public string FuelType { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public decimal FinanceDownPayment { get; set; }
        public decimal FinanceInterestRate { get; set; }
        public decimal FinanceMinMonthlyRepayment { get; set; }
        public decimal FinanceMaxMonthlyRepayment { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }
        public int OdometerMin { get; set; }
        public int OdometerMax { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string Color { get; set; }
        public string Location { get; set; }
        public decimal LocationRadius { get; set; }
    }

    public class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public int RegistrationYear { get; set; }
        public int RegistrationMonth { get; set; }

        /// <summary>
        /// Title of the vehicle as specified on the website Vehicle Details page
        /// </summary>
        public string Title { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// Trim/Version of the vehicle
        /// </summary>
        public string Trim { get; set; }

        /// <summary>
        /// New/NearlyNew/Used/etc
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Petrol/Diesel
        /// </summary>
        public string FuelType { get; set; }

        /// <summary>
        /// Mileage of the vehicle
        /// </summary>
        public int Odometer { get; set; }

        /// <summary>
        /// Automatic/Manual
        /// </summary>
        public string Transmission { get; set; }
        public string Color { get; set; }

        /// <summary>
        /// URL of the vehicle on the website
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// URL of main photo of the vehicle on the website (full size)
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// URL of thumbnail photo of the vehicle on the website
        /// </summary>
        public string ThumbnailUrl { get; set; }
    }

}
