﻿using FasTnT.Application.Handlers;
using FasTnT.Application.Domain.Model.Events;
using FasTnT.Application.Domain.Enumerations;

namespace FasTnT.Application.Tests.Capture;

[TestClass]
public class WhenHandlingCaptureRequestGivenItExceedTheMaximumNumberOfEvents
{
    readonly static EpcisContext Context = EpcisTestContext.GetContext(nameof(WhenHandlingCaptureRequestGivenItExceedTheMaximumNumberOfEvents));
    readonly static ICurrentUser UserContext = new TestCurrentUser();
    readonly static TestSubscriptionListener SubscriptionListener = new();

    [ClassCleanup]
    public static void Cleanup()
    {
        if (Context != null)
        {
            Context.Database.EnsureDeleted();
        }
    }

    [ClassInitialize]
    public static void Initialize(TestContext _)
    {
        Constants.Instance = new Constants() { MaxEventsCapturePerCall = 1 };
    }

    [TestMethod]
    public void ItShouldThrowAnExceptionAnNotCaptureTheRequest()
    {
        var handler = new CaptureHandler(Context, UserContext, SubscriptionListener);
        var request = new Request { SchemaVersion = "1.0", Events = new() { new Event { Type = EventType.ObjectEvent }, new Event { Type = EventType.ObjectEvent } } };
        
        Assert.ThrowsExceptionAsync<EpcisException>(() => handler.StoreAsync(request, default));
        Assert.AreEqual(0, Context.Set<Request>().Count());
        Assert.IsFalse(SubscriptionListener.IsTriggered("stream"));
    }
}
