using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SportEl20.BE
{
    [DataContract]
    public class USUARIO
    {
        [DataMember]
        public int ID_USUARIO { get; set; }
        [DataMember]
        public string NOMBRE { get; set; }
        [DataMember]
        public string APE_PAT { get; set; }
        [DataMember]
        public string APE_MAT { get; set; }
        [DataMember]
        public string TIPOPROFESION { get; set; }
        [DataMember]
        public string SEXO { get; set; }
        [DataMember]
        public string EMAIL { get; set; }
        [DataMember]
        public string PASSWORD { get; set; }
        [DataMember]
        public string COD_PERFIL { get; set; }
    }
}
