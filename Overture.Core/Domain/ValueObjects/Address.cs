using System;
using System.Collections.Generic;
using System.Text;

namespace Overture.Core.Domain.ValueObjects
{
    public struct Address
    {
		public string StreetAddress1 { get; set; }
		public string StreetAddress2 { get; set; }
		public string StreetAddress3 { get; set; }
		public string CityTownOrSuburb { get; set; }
		public string StateRegionOrProvince { get; set; }
		public string CountryName { get; set; }
		public string PostCode { get; set; }
    }
}
