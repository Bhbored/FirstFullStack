using System.Text.RegularExpressions;

namespace TaskFlow.Api.CustomeConstraints
{
    public class IdCustomeConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.TryGetValue(routeKey, out var value) || value == null)
                return false;

            var valueString = value.ToString();
            return Guid.TryParse(valueString, out _);
        }
    }
}
