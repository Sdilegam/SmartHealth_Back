using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace SmartHealth_API;

public static class ControllerExtensions
{
    public static int getId(this ControllerBase controller)
    {
        return int.Parse(controller.User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}