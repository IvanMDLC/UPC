using UPC.Intranet.Model.Dto.Request;
using UPC.Intranet.Model.Dto.Response;

namespace UPC.Intranet.Data.Interfaz
{
    public interface IDetalleSolicitudDal
    {
        Detalle_SolicitudDtoResponse ListDetailSolution(Detalle_SolicitudDtoRequest dto);
    }
}
