using System.Reflection;
using Microsoft.EntityFrameworkCore;
using src.WorkoutTracker.API.Helper;
using src.WorkoutTracker.API.Middlewares;
using src.WorkoutTracker.API.Repository;
using src.WorkoutTracker.API.Repository.Contracts;
using src.WorkoutTracker.API.Service;
using src.WorkoutTracker.API.Service.Contracts;

namespace src.WorkoutTracker.API.Extensions;
public static class WebApplicationExtensions
{
    public static void UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseMiddleware<GlobalErrorHandlingMiddleware>();
    }
}