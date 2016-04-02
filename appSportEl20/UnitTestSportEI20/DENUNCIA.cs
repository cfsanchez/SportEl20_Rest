using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSportEI20
{
   public class Denuncia
    {
        public int ID_DENUNCIA { get; set; }
        
        public int ID_USUARIO { get; set; }
        
        public string TIPODENUNCIA { get; set; }
        
        public DateTime FECHADENUNCIA { get; set; }
        
        public string DESCRIPCION { get; set; }
        
        public string ESTADO { get; set; }

        
        public List<DETALLE_FOTO> DETALLE_FOTOS { get; set; } 
    }
}
