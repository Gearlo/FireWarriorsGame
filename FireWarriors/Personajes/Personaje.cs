using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Tablero;

namespace FireWarriors.Personajes{
    internal abstract class Personaje{
        protected internal int Ataque{get; protected set;} // Estadisticas de ATAQUE del personaje
        protected internal int Defensa{get; protected set;} // Estadisticas de DEFENSA del personaje
        internal bool EsLocal{get; private set;} // Esta variable booleana define si el personaje es del jugador local o del jugador alojado
        internal int IdImagenDelPersonaje{get; private set;} // Esta variable guarda el identificador de la imagen del personaje
        protected internal int Salud{get; set;} // Estadisticas de SALUD del personaje
        protected internal int SaludBase{get; protected set;} // Estadisticas de SALUDBASE del personaje
        protected internal static Suelo[,] Tablero{protected get; set;}
        protected internal int Velocidad{get; protected set;} // Estadisticas de VELOCIDAD del personaje

        protected Personaje(int idImagenDelPersonaje, bool esLocal, int numeroEspaciosAtaque, int numeroEspaciosMovimiento){
            EsLocal = esLocal;
            IdImagenDelPersonaje = idImagenDelPersonaje;
            this.numeroEspaciosMovimiento = numeroEspaciosMovimiento;
            this.numeroEspaciosAtaque = numeroEspaciosAtaque;
            
            Salud = 100;
            Ataque = 50;
            Defensa = 50;
            Velocidad = 50;
        }

        abstract internal void atacar(Personaje objetivo); // Este metodo abstracto Ataca al objetivo del del personaje
        abstract internal int calcularTimerPersonaje();
        abstract internal List<Coordenada> rangoAtaque(Coordenada coor); // Este metodo abstracto devuelve la lista de coordenadas del rango de Ataque del personaje
        abstract internal List<Coordenada> rangoMovimiento(Coordenada coor); // Este metodo abstracto devuelve la lista de coordenadas del rango de Movimiento del personaje
        
        internal enum TipoPersonaje{ 
           Arquero,
           Caballero,
           Mago,
           Ninja,
           Paladin_Espada,
           Paladin_Lanza,
           Paladin_Mazo
        }

        protected readonly int numeroEspaciosAtaque; // Numero de pasos de rango de ataque
        protected readonly int numeroEspaciosMovimiento; // Numero de pasos de rango de movimiento
    }
}
