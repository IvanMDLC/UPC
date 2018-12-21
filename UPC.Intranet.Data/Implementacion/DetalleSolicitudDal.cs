using System.Data.Entity;
using UPC.Intranet.Data.Interfaz;
using UPC.Intranet.Model.Dto.Request;
using UPC.Intranet.Model.Dto.Response;
using UPC.Intranet.Model.Model;

namespace UPC.Intranet.Data.Implementacion
{
    public class DetalleSolicitudDal : Repository<Detalle_Solicitud>, IDetalleSolicitudDal
    {
        readonly DbContext context;

        public DetalleSolicitudDal(UPC_BD_Context unitOfWork) : base(unitOfWork)
        {
            context = UnitOfWork as UPC_BD_Context;
        }

        public Detalle_SolicitudDtoResponse ListDetailSolution(Detalle_SolicitudDtoRequest dto)
        {
            var object_ = new UPC_BD_Context();
            return object_.ListDetailSolution(dto); 
        }
    }
}
