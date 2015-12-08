using System.Threading.Tasks;
using Microsoft.AspNet.Routing;

namespace MvcMaroto.Framework.Router
{
    public class RouterMaroto : IRouter
    {
        /// <summary>
        /// Default asp.net router
        /// </summary>
        private readonly IRouter _target;

        public RouterMaroto(IRouter target)
        {
            _target = target;
        }

        public async Task RouteAsync(RouteContext context)
        {
            //Invoke MVC controller/action
            var oldRouteData = context.RouteData;
            var newRouteData = new RouteData(oldRouteData);
            newRouteData.Routers.Add(_target);

            newRouteData.Values["controller"] = "Maroto";
            newRouteData.DataTokens["namespaces"] = "MvcMaroto.Framework.Controllers";

            //Defines the correct controller method
            var hasId = context.RouteData.Values.Keys.Contains("id");
            switch (context.HttpContext.Request.Method)
            {
                case "GET":
                    newRouteData.Values["action"] = hasId ? "ListOne" : "List";
                    break;

                case "POST":
                    newRouteData.Values["action"] = "Create";
                    break;

                case "PUT":
                    newRouteData.Values["action"] = "Update";
                    break;

                case "DELETE":
                    newRouteData.Values["action"] = "Delete";
                    break;

                default:
                    break;
            }

            try
            {
                context.RouteData = newRouteData;
                await _target.RouteAsync(context);
            }
            finally
            {
                // Restore the original values to prevent polluting the route data.
                if (!context.IsHandled)
                {
                    context.RouteData = oldRouteData;
                }
            }
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return null;
        }
    }
}