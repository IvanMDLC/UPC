using System.ComponentModel.DataAnnotations;
namespace UPC.Intranet.Model.Model
{
    public class Solicitud
    {
        [Key]
        public int COD_UNICO { get; set; }
        public string COD_LINEA_NEGOCIO { get; set; }
        public string COD_MODAL_EST { get; set; }
        public string COD_PERIODO { get; set; }
        public int? COD_TRAMITE { get; set; }
        public string ESTADO { get; set; }
        public string COD_ALUMNO { get; set; }

    }
}
