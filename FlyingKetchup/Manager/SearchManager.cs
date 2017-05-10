using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlyingKetchup.Models;
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
            var results = CallGoogleApi();

            List<HolderObject> allFlights = new List<HolderObject>();
            int numberFlights = results.Trips.TripOption.Count;

            foreach (var result in results.Trips.TripOption)
            {
                HolderObject holderObject = new HolderObject
                {
                    SaleTotal = result.SaleTotal,
                    Origin = result.Pricing[1].Fare[1].Origin,
                    Destination = result.Pricing.First().Fare.First().Destination,
                    Carrier = result.Pricing.First().Fare.First().Carrier,
                    ArrivalTime = result.Slice.First().Segment.First().Leg.First().ArrivalTime,
                    DepartureTime = result.Slice.First().Segment.First().Leg.First().DepartureTime,
                    Duration = result.Slice.First().Segment.First().Leg.First().Duration,
                };

                allFlights.Add(holderObject);
            }

            // Hit repo layer to record price in general table of history of searches

            // return the google result
        }



        private TripsSearchResponse CallGoogleApi()
        {
            QPXExpressService service = new QPXExpressService(new BaseClientService.Initializer() { ApiKey = "AIzaSyCpjedj9wpLTgXxKMTquLYWtq0awsASYgQ", ApplicationName = "CodeFlyingKetchup", });

            TripsSearchRequest x = new TripsSearchRequest
            {
                Request = new TripOptionsRequest
                {
                    Passengers = new PassengerCounts {AdultCount = 2},
                    Slice = new List<SliceInput>
                    {
                        new SliceInput() {Origin = "TPA", Destination = "SEA", Date = "2017-10-29"}
                    },
                    Solutions = 10
                }
            };

            return service.Trips.Search(x).Execute();
        }
    }
}
