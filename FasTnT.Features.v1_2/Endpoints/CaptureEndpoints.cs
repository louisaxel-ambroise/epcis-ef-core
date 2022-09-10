﻿using FasTnT.Application.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using FasTnT.Features.v1_2.Endpoints.Interfaces;
using FasTnT.Domain.Infrastructure.Exceptions;

namespace FasTnT.Features.v1_2.Endpoints;

public class CaptureEndpoints
{
    protected CaptureEndpoints() { }

    public static IEndpointRouteBuilder AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("v1_2/capture", HandleCaptureRequest).RequireAuthorization(policyNames: nameof(ICurrentUser.CanCapture));

        return app;
    }

    private static async Task<IResult> HandleCaptureRequest(CaptureRequest request, IMediator mediator, ILogger<SoapEndpoints> logger, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Start capture request processing");
            await mediator.Send(request.Request, cancellationToken);

            return Results.NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to process capture request");

            return ex is FormatException or EpcisException
                ? Results.BadRequest()
                : Results.StatusCode(500);
        }
    }
}