using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Tablero;

namespace FireWarriors.Personajes{
    internal class Caballero : Personaje{
        internal int NroPasos{get; set;} //Esta variable lleva recuento de cuantos espacios se mueve un personaje por turno

        internal Caballero(int idImagenDelPersonaje, bool esLocal) : base(idImagenDelPersonaje, esLocal, 1, 4){
            //adpatacion de las estadisticas base al las estadisticas del caballero
            NroPasos = 0;
            Salud += 50;
            SaludBase = Salud;
            Defensa += 30;
            Velocidad += 20;
        }

        internal override void atacar(Personaje objetivo){
            int daño;
            int dañoExtra = (Ataque - 10) + (NroPasos * 20); // Ataque del caballero

            if(objetivo is Caballero)
                ((Caballero)objetivo).NroPasos = 0;

            daño = dañoExtra - (objetivo.Defensa / 2); // daño que causa el caballero a su oponente
            daño = NroPasos == 4 ? daño + 80 : daño;
            daño = daño <= 0 ? 10 : daño; // Si el daño es menor o igual que cero se producira un Ataque muy pequeño

            objetivo.Salud = objetivo.Salud - daño > 0 ? objetivo.Salud - daño : 0;
            NroPasos = 0; // Reinicia el contador de pasos a 0
        }

        internal override int calcularTimerPersonaje(){
            return 2800;
        }

        internal override List<Coordenada> rangoAtaque(Coordenada coor){
            List<Coordenada> tmp = new List<Coordenada>();

            //ARRIBA
            for(int i = 1; i <= numeroEspaciosAtaque; i++){
                if(coor.Y - i < 0 || Tablero[coor.X, coor.Y - i].TipoDelSuelo.EsObstaculo)
                    break;

                tmp.Add(new Coordenada(coor.X, coor.Y - i));
            }

            //DERECHA
            for(int i = 1; i <= numeroEspaciosAtaque; i++){
                if(coor.X + i >= ConstructorTablero.X || Tablero[coor.X + i, coor.Y].TipoDelSuelo.EsObstaculo)
                    break;

                tmp.Add(new Coordenada(coor.X + i, coor.Y));
            }

            //ABAJO
            for(int i = 1; i <= numeroEspaciosAtaque; i++){
                if(coor.Y + i >= ConstructorTablero.Y || Tablero[coor.X, coor.Y + i].TipoDelSuelo.EsObstaculo)
                    break;
                
                tmp.Add(new Coordenada(coor.X, coor.Y + i));
            }

            //IZQUIERDA
            for(int i = 1; i <= numeroEspaciosAtaque; i++){
                if(coor.X - i < 0 || Tablero[coor.X - i, coor.Y].TipoDelSuelo.EsObstaculo)
                    break;

                tmp.Add(new Coordenada(coor.X - i, coor.Y));
            }

            return tmp;
        }

        internal override List<Coordenada> rangoMovimiento(Coordenada coor){
            List<Coordenada> tmp = new List<Coordenada>();

            //ARRIBA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.Y - i < 0 || Tablero[coor.X, coor.Y - i].TipoDelSuelo.EsObstaculo || Tablero[coor.X, coor.Y - i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X, coor.Y - i));
            }

            //DERECHA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X + i >= ConstructorTablero.X || Tablero[coor.X + i, coor.Y].TipoDelSuelo.EsObstaculo || Tablero[coor.X + i, coor.Y].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X + i, coor.Y));
            }

            //ABAJO
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.Y + i >= ConstructorTablero.Y || Tablero[coor.X, coor.Y + i].TipoDelSuelo.EsObstaculo || Tablero[coor.X, coor.Y + i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X, coor.Y + i));
            }

            //IZQUIERDA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X - i < 0 || Tablero[coor.X - i, coor.Y].TipoDelSuelo.EsObstaculo || Tablero[coor.X - i, coor.Y].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X - i, coor.Y));
            }

            return tmp;
        }
    }
}
