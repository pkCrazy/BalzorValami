using Microsoft.AspNetCore.Mvc.Routing;

namespace BalzorValami.Server.Attributes;

[AttributeUsage(AttributeTargets.Class)]
internal class ApiRouteAttribute : Attribute, IRouteTemplateProvider
{
    public string? Template { get; }
    public int? Order { get; set; }
    public string? Name { get; set; }

    public ApiRouteAttribute(string area = "")
    {
        if (!string.IsNullOrEmpty(area))
        {
            area += "/";
        }

        Template = $"api/{area}[controller]/[action]";
    }
}
