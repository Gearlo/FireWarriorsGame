using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarriors.Tablero{
    internal class TipoSuelo{
        internal bool EsObstaculo{get; private set;} // Esta variable booleana especifica si el terreno es un obstaculo que impide el movimiento en el
        internal int IdImagenSuelo{get; set;} // Esta varible de tipo entero almacena el identificador de la imagen del suelo
        internal string NombreSuelo{get; private set;} // Esta variable tipo cadena guarda el nombre del tipo del suelo

        internal TipoSuelo(string nombreSuelo, bool esObstaulo, int idImagenSuelo){
            NombreSuelo = nombreSuelo;
            EsObstaculo = esObstaulo;
            IdImagenSuelo = idImagenSuelo;
        }
    }
}
