﻿using FasTnT.Domain.Model.Events;
using FasTnT.Host.Communication.Xml.Formatters;
using FasTnT.Host.Endpoints.Interfaces;
using System.Xml.Linq;

namespace FasTnT.Host.Tests.Features.v1_2.Communication;

[TestClass]
public class WhenFormattingAnEmptyQueryResponse
{
    public QueryResult Result = new(new Domain.Model.Queries.QueryResponse("ExampleQueryName", new List<Event>()));
    public XElement Formatted { get; set; }

    [TestInitialize]
    public void When()
    {
        Formatted = SoapResponseFormatter.Format(Result);
    }

    [TestMethod]
    public void ItShouldReturnAnXElement()
    {
        Assert.IsNotNull(Formatted);
    }

    [TestMethod]
    public void TheXmlShouldBeCorrectlyFormatted()
    {
        Assert.IsTrue(Formatted.Name == XName.Get("QueryResults", "urn:epcglobal:epcis-query:xsd:1"));
        Assert.AreEqual(2, Formatted.Elements().Count());
        Assert.AreEqual(Result.Response.QueryName, Formatted.Element("queryName").Value);
        Assert.IsNotNull(Formatted.Element("resultsBody"));
    }

    [TestMethod]
    public void ThereShouldNotBeASubscriptionIDField()
    {
        Assert.IsNull(Formatted.Element("subscriptionID"));
    }
}
