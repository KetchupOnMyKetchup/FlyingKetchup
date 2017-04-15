using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.QPXExpress.v1;
using Google.Apis.QPXExpress.v1.Data;
using Google.Apis.Services;

namespace FlyingKetchup.Manager
{
    public class SearchManager
    {

        public void GetLowestRoundTripPrice(string departDate, string departLocation, string arrivalDate, string arrivalLocation)
        {
            // Call google API
            var result = CallGoogleApi();

            // Hit repo layer to record price in general table of history of searches

            // return the google result
        }

        private TripsSearchResponse CallGoogleApi()
        {
            QPXExpressService service = new QPXExpressService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCpjedj9wpLTgXxKMTquLYWtq0awsASYgQ", ApplicationName = "CodeFlyingKetchup", });

            TripsSearchRequest x = new TripsSearchRequest();
            x.Request = new TripOptionsRequest();
            x.Request.Passengers = new PassengerCounts { AdultCount = 2 };
            x.Request.Slice = new List<SliceInput>();
            x.Request.Slice.Add(new SliceInput() { Origin = "JFK", Destination = "BOS", Date = "2017-10-29" });
            x.Request.Solutions = 10;

            return service.Trips.Search(x).Execute();
        }
    }
}
