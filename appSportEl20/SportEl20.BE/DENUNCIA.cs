using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SportEl20.BE
{

    [DataContract]
    public class DENUNCIA
    {
        [DataMember]
        public int ID_DENUNCIA { get; set; }
        [DataMember]
        public int ID_USUARIO { get; set; }
        [DataMember]
        public string TIPODENUNCIA { get; set; }
        [DataMember]
        public DateTime FECHADENUNCIA { get; set; }
        [DataMember]
        public string DESCRIPCION { get; set; }
        [DataMember]
        public string ESTADO { get; set; }

        [DataMember]
        public USUARIO USUARIO { get; set; }
        [DataMember]
        public List<DETALLE_FOTO> DETALLE_FOTOS { get; set; }
    }
}
