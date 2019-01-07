using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Personajes;

namespace FireWarriors.Tablero{
    internal class Suelo{
        internal Personaje Personaje{get; set;} //Esta variable almacena al personaje parado sobre esta seccion del suelo, si la variable tiene el valor null no hay ningun personaje sobre el
        internal TipoSuelo TipoDelSuelo{get; private set;} //esta variable tipo "TipoSuelo" guarda el tipo de suelo del que se compone esta seccion del tablero
        
        internal Suelo(string nombreSuelo, bool esObstaculo, int idImagenSuelo){
            TipoDelSuelo = new TipoSuelo(nombreSuelo, esObstaculo, idImagenSuelo);
        }
    }
}
