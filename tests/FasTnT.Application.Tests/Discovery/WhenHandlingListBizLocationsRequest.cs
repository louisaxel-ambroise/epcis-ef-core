﻿using FasTnT.Application.EfCore.Store;
using FasTnT.Application.EfCore.UseCases.TopLevelResources;
using FasTnT.Application.Tests.Context;
using FasTnT.Domain.Model.Events;
using FasTnT.Domain.Model.Queries;

namespace FasTnT.Application.Tests.Discovery;

[TestClass]
public class WhenHandlingListBizLocationsRequest
{
    readonly static EpcisContext Context = EpcisTestContext.GetContext(nameof(WhenHandlingListBizLocationsRequest));

    [TestInitialize]
    public void Initialize()
    {
        Context.Requests.Add(new Domain.Model.Request
        {
            CaptureDate = DateTime.Now,
            DocumentTime = DateTime.Now,
            SchemaVersion = "2.0",
            UserId = "TESTUSER",
            Events = new List<Event>
            {
                new Event
                {
                    BusinessLocation = "BL1"
                },
                new Event
                {
                    BusinessLocation = "BL2"
                }
            }
        });

        Context.SaveChanges();
    }

    [TestMethod]
    public void ItShouldReturnAllTheBizLocationsIfPageSizeIsGreaterThanNumberOfEpcs()
    {
        var handler = new TopLevelResourceUseCasesHandler(Context);
        var request = new Pagination(10, 0);

        var result = handler.ListBizLocations(request, default).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void ItShouldReturnTheRequestedNumberOfBizLocationsIfPageSizeIsLowerThanNumberOfEpcs()
    {
        var handler = new TopLevelResourceUseCasesHandler(Context);
        var request = new Pagination(1, 0);

        var result = handler.ListBizLocations(request, default).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void ItShouldReturnTheCorrectPageOfData()
    {
        var handler = new TopLevelResourceUseCasesHandler(Context);
        var request = new Pagination(10, 1);

        var result = handler.ListBizLocations(request, default).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count());
    }
}