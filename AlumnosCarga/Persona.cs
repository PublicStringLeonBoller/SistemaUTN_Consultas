using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosCarga
{
    class Persona
    {
        public int pPersona { set; get; } = 0;
        public string pNombre { set; get; } = string.Empty;
        public string pApellido { set; get; } = string.Empty;
        public string pCalle { set; get; } = string.Empty;
        public DateTime pFechaNac { set; get; } = DateTime.Today;
        public int pSexo { set; get; } = 0;
        public int pTipoDoc { set; get; } = 0;
        public int pNroDoc { set; get; } = 0;
        public int pNroCalle { set; get; } = 0;
        public int pEstadoCiv { set; get; } = 0;
        public int pBarrios { set; get; } = 0;
        public string pEmail { set; get; } = string.Empty;
        public int pVivienda { set; get; } = 0;
        public int pLocalidad { set; get; } = 0;
        public int pProvincia { set; get; } = 0;
        public int pPais { set; get; } = 0;
        public long pTelefono { set; get; } = 0;
        public int pDpto { set; get; } = 0;
        public int pPiso { set; get; } = 0;
    }
}
