﻿using FasTnT.Features.v2_0.Communication.Json.Parsers;
using System.Reflection;
using System.Text.Json;

namespace FasTnT.Features.v2_0.Tests.Communication.Json;

public abstract class JsonParsingTestCase
{
    protected static JsonDocument ParseResource(string resourceName)
    {
        var manifest = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        using var resourceStream = JsonDocumentParser.Instance.ParseAsync(manifest, default);

        return resourceStream.Result;
    }
}