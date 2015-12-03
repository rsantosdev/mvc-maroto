using System.Linq;
using Microsoft.AspNet.Mvc;

namespace MvcMaroto.Web.Controllers
{
    public class MarotoController : Controller
    {
        private readonly dynamic[] _data =
        {
            new {id = 1, name = "rafael"},
            new {id = 2, name = "foo bar"},
            new {id = 3, name = "xablau"},
            new {id = 4, name = "maroto"},
            new {id = 5, name = "xablauzado"}
        };


        public IActionResult List()
        {
            return Json(_data);
        }

        public IActionResult ListOne(int id)
        {
            return Json(new { id = id, method = "list-one" });
        }

        public IActionResult Create()
        {
            return Json(new { method = "create" });
        }

        public IActionResult Update(int id)
        {
            return Json(new { id = id, method = "update" });
        }

        public IActionResult Delete(int id)
        {
            return Json(new { id = id, method = "delete" });
        }
    }
}