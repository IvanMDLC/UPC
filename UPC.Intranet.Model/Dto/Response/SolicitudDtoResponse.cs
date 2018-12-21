using System.Runtime.Serialization;
namespace UPC.Intranet.Model.Dto.Response
{
    [DataContract]
    public class SolicitudDtoResponse
    {
        [DataMember]
        public int COD_UNICO { get; set; }

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

        [DataMember]
        public string COD_ALUMNO { get; set; }
    }
}
