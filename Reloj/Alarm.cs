using System;

namespace Reloj
{
    [Serializable()]
    class Alarm
    {
        public string horas {get; set;}
        public string minutos {get; set;}
        public string segundos { get; set;}
        public bool enable {get; set;}

        public Alarm () {}

        public Alarm (string horas, string minutos, string segundos, bool enable)
        {
            this.horas = horas;
            this.minutos = minutos;
            this.segundos = segundos;
            this.enable = enable;
        }
    }
}
