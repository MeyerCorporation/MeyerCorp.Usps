﻿using MeyerCorp.Usps.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using UspsXml = MeyerCorp.Usps.Core.Xml;

namespace Meyer.UspsCore.Test.Core
{
    public class TrackAndConfirmTest : Test
    {
        [Fact(DisplayName = "Track No Packages")]
        public async Task Test1Async()
        {
            var tracking = new TrackAndConfirm(ApiOptions);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new UspsXml.TrackID[]
            {
                new UspsXml.TrackID
                {
					Id = 0,
					TrackId = null,
                }
            }));

            Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The empty string &#39;&#39; is not a valid name.", ex.Message);
        }

        [Fact(DisplayName = "Track Bad Packages ID")]
        public async Task Test2Async()
        {
            var tracking = new TrackAndConfirm(ApiOptions);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(() => tracking.TrackAsync(new UspsXml.TrackID[]
            {
                new UspsXml.TrackID
                {
					TrackId = "9405 5036 9930 0333 4765 26",
                }
            }));

            Assert.Equal("The &#39;ID&#39; attribute is invalid - The value &#39;&#39; is invalid according to its datatype &#39;http://www.w3.org/2001/XMLSchema:NMTOKEN&#39; - The empty string &#39;&#39; is not a valid name.", ex.Message);
        }

        [Fact(DisplayName = "Single Address")]
        public async Task Test3Async()
        {
            var addresses = new Addresses(ApiOptions);

            var results = await addresses.ValidateAsync(1, new UspsXml.Address[]
            {
                new UspsXml.Address
                {
                    Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
                    State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}
            });

            var result = results.First();

            Assert.Equal("0", result.Id);
            Assert.Null(result.Address1);
            Assert.Equal("2001 MEYER WAY", result.Address2);
            Assert.True(result.Business);
            Assert.Equal("C037", result.CarrierRoute);
            Assert.False(result.CentralDeliveryPoint);
            Assert.Equal("FAIRFIELD", result.City);
            Assert.Null(result.CityAbbreviation);
            Assert.Equal("01", result.DeliveryPoint);
            Assert.False(result.DPVCMRA);
            //Assert.True(result.DPVConfirmation);
            Assert.Equal("AABB", result.DPVFootnotes.Raw);
            Assert.Null(result.Error);
            Assert.Null(result.FirmName);
            Assert.Equal("(N/A)", result.Footnotes.ToString());
            Assert.Equal("CA", result.State);
            Assert.Null(result.Urbanization);
            Assert.False(result.Vacant);
            Assert.Equal("6802", result.Zip4);
            Assert.Equal("94533", result.Zip5);
        }

        [Fact(DisplayName = "Double Address")]
        public async Task Test4Async()
        {
            var addresses = new Addresses(ApiOptions);

            var results = await addresses.ValidateAsync(1, new UspsXml.Address[]
            {
                new UspsXml.Address
                {
                    Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
                    State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				},
                new UspsXml.Address
                {
                    Address1 = "1 Meyer Plaza",
					//Address2 = "address2",
					City = "Vallejo",
					//FirmName = "firmname",
					Id = 0,
                    State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}

            });

            var result = results.First();

            Assert.Equal("0", result.Id);
            Assert.Null(result.Address1);
            Assert.Equal("2001 MEYER WAY", result.Address2);
            Assert.True(result.Business);
            Assert.Equal("C037", result.CarrierRoute);
            Assert.False(result.CentralDeliveryPoint);
            Assert.Equal("FAIRFIELD", result.City);
            Assert.Null(result.CityAbbreviation);
            Assert.Equal("01", result.DeliveryPoint);
            Assert.False(result.DPVCMRA);
            Assert.Equal("Y - Address was DPV confirmed for both primary and (if present) secondary numbers.", result.DPVConfirmation.ToString());
            Assert.Equal("AABB", result.DPVFootnotes.Raw);
            Assert.Null(result.Error);
            Assert.Null(result.FirmName);
            Assert.Equal("(N/A)", result.Footnotes.ToString());
            Assert.Equal("CA", result.State);
            Assert.Null(result.Urbanization);
            Assert.False(result.Vacant);
            Assert.Equal("6802", result.Zip4);
            Assert.Equal("94533", result.Zip5);
        }

        [Fact(DisplayName = "Double City State Lookup")]
        public async Task Test5Async()
        {
            var addresses = new Addresses(ApiOptions);

            var results = await addresses.LookupCityStateAsync(
                new UspsXml.CityState
                {
                    Zip5 = "95687",
                    Id = 1,
                },
                new UspsXml.CityState
                {
                    Zip5 = "95127",
                    Id = 1,
                });

            Assert.Equal(2, results.Count());
            Assert.Equal("VACAVILLE", results.First().City);
            Assert.Equal("CA", results.First().State);
            Assert.Equal("SAN JOSE", results.Last().City);
            Assert.Equal("CA", results.Last().State);
        }

        [Fact(DisplayName = "Double Zip Code Lookup")]
        public async Task Test6Async()
        {
            var addresses = new Addresses(ApiOptions);

            var results = await addresses.LookupZipCodeAsync(new UspsXml.ZipCode[]
            {
                new UspsXml.ZipCode
                {
                    Address1 = "2001 Meyer Way",
					//Address2 = "address2",
					City = "Fairfield",
					//FirmName = "firmname",
					Id = 0,
                    State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				},
                new UspsXml.ZipCode
                {
                    Address1 = "1 Meyer Plaza",
					//Address2 = "address2",
					City = "Vallejo",
					//FirmName = "firmname",
					Id = 0,
                    State = "CA",
					//Urbanization = "urbanization",
					//Zip4 = "9999",
					//Zip5 = "95687",
				}

            });

            var result = results.First();

            Assert.Equal("0", result.Id);
            Assert.Null(result.Address1);
            Assert.Equal("2001 MEYER WAY", result.Address2);
            Assert.Equal("FAIRFIELD", result.City);
            Assert.Null(result.Error);
            Assert.Null(result.FirmName);
            Assert.Equal("CA", result.State);
            Assert.Equal("6802", result.Zip4);
            Assert.Equal("94533", result.Zip5);
        }
    }
}