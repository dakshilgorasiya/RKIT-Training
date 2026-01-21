using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

public class RoleAuthorizationFilter : AuthorizationFilterAttribute
{
    private readonly string _role;

    public RoleAuthorizationFilter(string role)
    {
        _role = role;
    }

    public override void OnAuthorization(HttpActionContext context)
    {
        var user = context.RequestContext.Principal;

        if (user == null || !user.Identity.IsAuthenticated)
        {
            context.Response = context.Request
                .CreateResponse(HttpStatusCode.Unauthorized);
            return;
        }

        if (!user.IsInRole(_role))
        {
            context.Response = context.Request
                .CreateResponse(HttpStatusCode.Forbidden, "Access denied");
        }
    }
}
