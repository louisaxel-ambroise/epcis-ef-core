﻿using FasTnT.Application.Services.Subscriptions;
using FasTnT.Domain.Infrastructure.Exceptions;
using FasTnT.Domain.Model.Queries;
using FasTnT.Domain.Model.Subscriptions;
using FasTnT.Features.v2_0.Communication.Json.Formatters;
using FasTnT.Features.v2_0.Endpoints.Interfaces;
using System.Net.WebSockets;
using System.Text;

namespace FasTnT.Features.v2_0.Subscriptions;

public class WebSocketResultSender : IResultSender
{
    private readonly WebSocket _webSocket;

    public string Name => nameof(WebSocketResultSender);

    public WebSocketResultSender(WebSocket webSocket)
    {
        _webSocket = webSocket;
    }

    public async Task<bool> SendResultAsync(Subscription context, QueryResponse response, CancellationToken cancellationToken)
    {
        var formattedResponse = JsonResponseFormatter.Format(new QueryResult(response));
        var responseByteArray = Encoding.UTF8.GetBytes(formattedResponse);

        try
        {
            await _webSocket.SendAsync(responseByteArray, WebSocketMessageType.Text, true, cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> SendErrorAsync(Subscription context, EpcisException error, CancellationToken cancellationToken)
    {
        var formattedResponse = JsonResponseFormatter.FormatError(error);
        var responseByteArray = Encoding.UTF8.GetBytes(formattedResponse);

        try
        {
            await _webSocket.SendAsync(responseByteArray, WebSocketMessageType.Text, true, cancellationToken);

            return true;
        }
        catch
        {
            return false;
        }
    }
}
