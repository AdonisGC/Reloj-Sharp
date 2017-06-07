using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reloj
{
    [Serializable()]
    public class DiferenciaHoraria
    {
        public string pais { get; set; }
        public int diferenciaHoraria { get; set; }

        public DiferenciaHoraria() { }

        public DiferenciaHoraria(string pais, int diferenciaHoraria)
        {
            this.pais = pais;
            this.diferenciaHoraria = diferenciaHoraria;
        }
    }
}
