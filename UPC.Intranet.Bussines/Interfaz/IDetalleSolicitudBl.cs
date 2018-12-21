using UPC.Intranet.Model.Dto.Request;
using UPC.Intranet.Model.Dto.Response;

namespace UPC.Intranet.Bussines.Interfaz
{
    public interface IDetalleSolicitudBl
    {
        Detalle_SolicitudDtoResponse ListDetailSolution(Detalle_SolicitudDtoRequest dto);
    }
}
