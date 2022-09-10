﻿using FasTnT.Domain.Queries.GetSubscriptionIds;
using FasTnT.Features.v1_2.Communication.Formatters;
using System.Xml.Linq;

namespace FasTnT.Features.v1_2.Tests;

[TestClass]
public class WhenFormattingAGetSubscriptionIdsResult
{
    public GetSubscriptionIdsResult Result = new(new[] { "Sub1", "Sub2", "Sub2" });
    public XElement Formatted { get; set; }

    [TestInitialize]
    public void When()
    {
        Formatted = XmlResponseFormatter.FormatSubscriptionIds(Result);
    }

    [TestMethod]
    public void ItShouldReturnAnXElement()
    {
        Assert.IsNotNull(Formatted);
    }

    [TestMethod]
    public void TheXmlShouldBeCorrectlyFormatter()
    {
        Assert.IsTrue(Formatted.Name == XName.Get("GetSubscriptionIdsResult", "urn:epcglobal:epcis-query:xsd:1"));
        Assert.AreEqual(3, Formatted.Elements().Count());
        CollectionAssert.AreEquivalent(Result.SubscriptionIDs.ToArray(), Formatted.Elements().Select(x => x.Value).ToArray());
    }
}