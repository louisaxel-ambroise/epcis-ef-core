﻿using FasTnT.Application.Services.Users;
using FasTnT.Features.v1_2.Endpoints;
using FasTnT.Features.v1_2.Extensions;
using FasTnT.Features.v1_2.Subscriptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FasTnT.Features.v1_2;

public static class Epcis1_2Configuration
{
    public static IServiceCollection AddEpcis12SubscriptionService<T>(this IServiceCollection services)
        where T : class, ISubscriptionService, IHostedService
    {
        services.AddScoped<SubscriptionRunner>();
        services.AddScoped<SubscriptionRunner>();
        services.AddScoped<ISubscriptionResultSender, HttpSubscriptionResultSender>();
        services.AddSingleton<ISubscriptionService, T>();
        services.AddHostedService(s => s.GetRequiredService<ISubscriptionService>() as T);

        return services;
    }

    public static IEndpointRouteBuilder MapEpcis12Endpoints(this IEndpointRouteBuilder endpoints)
    {
        CaptureEndpoints.AddRoutes(endpoints);
        QueryEndpoints.AddRoutes(endpoints);
        SubscriptionEndpoints.AddRoutes(endpoints);

        endpoints.MapSoap("v1_2/query.svc", action =>
        {
            QueryEndpoints.AddSoapActions(action);
            SubscriptionEndpoints.AddSoapActions(action);
        }).RequireAuthorization(policyNames: nameof(ICurrentUser.CanQuery));

        return endpoints;
    }
}
