using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SportEl20.BE
{
    [DataContract]
    public class Email
    {
        [DataMember]
        public string EmailTo { get; set; }
        [DataMember]
        public string Asunto { get; set; }
        [DataMember]
        public string Cuerpo { get; set; }
    }
}
