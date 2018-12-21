using UPC.Intranet.Data.Interfaz;
using UPC.Intranet.Model.Dto.Request;
using UPC.Intranet.Model.Dto.Response;
using UPC.Intranet.Bussines.Interfaz;

namespace UPC.Intranet.Bussines.Implementacion
{
    public class DetalleSolicitudBl : IDetalleSolicitudBl
    {
        readonly IDetalleSolicitudDal iDetalleSolicitudDal;

        public DetalleSolicitudBl(IDetalleSolicitudDal IDetalleSolicitudDal)
        {
            iDetalleSolicitudDal = IDetalleSolicitudDal;
        }
        public Detalle_SolicitudDtoResponse ListDetailSolution(Detalle_SolicitudDtoRequest dto)
        {
            return iDetalleSolicitudDal.ListDetailSolution(dto);
        }
    }
}
