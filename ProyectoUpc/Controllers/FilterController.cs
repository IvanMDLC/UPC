using System.Web.Mvc;
using UPC.Intranet.Bussines.Interfaz;
using UPC.Intranet.Model.Dto.Request;

namespace ProyectoUpc.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public readonly IDetalleSolicitudBl _IDetalleSolicitudBl;
        public FilterController(IDetalleSolicitudBl IDetalleSolicitudBl)
        {
            this._IDetalleSolicitudBl = IDetalleSolicitudBl;
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResponseData(Detalle_SolicitudDtoRequest objDetalleSolucion)
        {
            var Response = _IDetalleSolicitudBl.ListDetailSolution(objDetalleSolucion);

           
            ViewBag.Lista = Response.ListDetalle_SolicitudDtoResponse;
            return View();
        }
    }
}