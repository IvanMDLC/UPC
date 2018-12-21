using System.Runtime.Serialization;
namespace UPC.Intranet.Model.Dto.Request
{
    [DataContract]
    public class Detalle_SolicitudDtoRequest
    {
        [DataMember]
        public string COD_LINEA_NEGOCIO { get; set; }

        [DataMember]
        public string COD_MODAL_EST { get; set; }

        [DataMember]
        public string COD_PERIODO { get; set; }

        [DataMember]
        public int? COD_TRAMITE { get; set; }

        [DataMember]
        public string ESTADO { get; set; }

    }
}
