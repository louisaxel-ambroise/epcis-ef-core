﻿using FasTnT.Application.Store;
using FasTnT.Domain.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FasTnT.Features.v1_2.Subscriptions.Notifications;

public class SubscriptionCreatedNotificationHandler : INotificationHandler<SubscriptionCreatedNotification>
{
    private readonly EpcisContext _context;
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionCreatedNotificationHandler(EpcisContext context, ISubscriptionService subscriptionService)
    {
        _context = context;
        _subscriptionService = subscriptionService;
    }

    public async Task Handle(SubscriptionCreatedNotification notification, CancellationToken cancellationToken)
    {
        var subscription = await _context.Subscriptions
            .AsNoTracking()
            .Include(x => x.Parameters)
            .Include(x => x.Schedule)
            .SingleOrDefaultAsync(x => x.Id == notification.SubscriptionId, cancellationToken)
            .ConfigureAwait(false);

        _subscriptionService.Register(subscription);
    }
}