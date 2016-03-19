using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SportEl20.BE
{
    [DataContract]
    public class DETALLE_FOTO
    {
        [DataMember]
        public int ID_DETALLE_DENUNCIA { get; set; }
        [DataMember]
        public int ID_DENUNCIA { get; set; }
        [DataMember]
        public string FOTODENUNCIA { get; set; } 
    }
}
