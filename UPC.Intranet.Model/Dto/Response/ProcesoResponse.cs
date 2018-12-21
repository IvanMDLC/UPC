using System.Runtime.Serialization;
namespace UPC.Intranet.Model.Dto.Response
{
    [DataContract]
    public class ProcesoResponse
    {
        public int Id { get; set; }
        public int TipoProceso { get; set; }
        public int Mensaje { get; set; }

    }
}
