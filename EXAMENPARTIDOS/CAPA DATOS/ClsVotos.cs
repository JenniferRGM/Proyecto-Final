using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EXAMENPARTIDOS.CAPA_DATOS
{
    public class ClsVotos
    {
        public int idvoto { get; set; }
        public string idcandidato { get; set; }
       
        public string idvotante { get; set; }
       
        public virtual ClsCandidatos ClsCandidatos { get; set; }
    }
}
