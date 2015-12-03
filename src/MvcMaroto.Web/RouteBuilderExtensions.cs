using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.AspNet.Routing.Template;

namespace MvcMaroto.Web
{
    public static class RouteBuilderExtensions
    {
        public static IRouteBuilder MapResource(this IRouteBuilder routeBuilder, IApplicationBuilder app, string name, string path)
        {
            var routerMaroto = new RouterMaroto(routeBuilder.DefaultHandler);
            var constraintResolver =
                (IInlineConstraintResolver) app.ApplicationServices.GetService(typeof (IInlineConstraintResolver));

            routeBuilder.Routes.Add(new TemplateRoute(
                    routerMaroto,
                    path + "/{id?}",
                    constraintResolver
                ));

            return routeBuilder;
        }
    }
}