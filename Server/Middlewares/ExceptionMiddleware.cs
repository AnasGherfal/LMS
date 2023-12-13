﻿using Common.Exceptions;
using Common.Wrappers;
using Serilog;
using ValidationException = Common.Exceptions.ValidationException;

namespace Server.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var bodyAsText = string.Empty;
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            var responseMessage = "";
            httpContext.Response.ContentType = "application/json";
            switch (ex)
            {
                case NotFoundException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    responseMessage = e.Message;
                    break;
                case ValidationException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    responseMessage = e.Message;
                    break;
                case BadRequestException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                    responseMessage = e.Message;
                    break;
                case NotAuthenticatedException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    responseMessage = e.Message;
                    break;
                case ForbiddenException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                    responseMessage = e.Message;
                    break;
                case UnauthorizedException e:
                    httpContext.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                    responseMessage = e.Message;
                    break;
                default:
                    Log.Fatal(ex, "{@protocol} {@scheme} {@method} {@path} {@queryString} {@body}",
                        httpContext.Request.Protocol,
                        httpContext.Request.Scheme,
                        httpContext.Request.Method,
                        httpContext.Request.Path.Value,
                        httpContext.Request.QueryString.Value,
                        bodyAsText);
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseMessage = "خطأ غير متوقع بالخادم، يرجى الاتصال بالدعم الفني";
                    break;
            }
            await httpContext.Response.WriteAsJsonAsync(new MessageResponse
            {
                Msg = responseMessage,
            });
        }
    }
}