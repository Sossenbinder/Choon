﻿namespace Choon.Api.Features.Common.Web.Auth.Middleware;

public class UserDetectionMiddleware(IUserContext userContext) : IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        return Task.CompletedTask;
    }
}