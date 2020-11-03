using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosCarga
{
    class Alumnos : Persona
    {

        public int pLegajo { set; get; } = 0;
        public int pSitLab { set; get; } = 0;
        public int pCarrera { set; get; } = 0;
        public int pCurso { set; get; } = 0;
        public int pNotas { set; get; } = 0;

        public string legajoNombre()
        {
            return $"{pLegajo} - {pApellido}, {pNombre}";
        }
    }
}
