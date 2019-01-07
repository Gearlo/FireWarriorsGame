using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Tablero;

namespace FireWarriors.Personajes{
    internal class Paladin_Mazo : Personaje{
        internal Paladin_Mazo(int idImagenDelPersonaje, bool esLocal) : base(idImagenDelPersonaje, esLocal, 1, 3){
            //adpatacion de las estadisticas base al las estadisticas del paladín
            Salud += 70;
            SaludBase = Salud;
            Ataque += 50;
            Defensa += 70;
            Velocidad -= 50;
        }

        internal override void atacar(Personaje objetivo){
            int daño;

            if(objetivo is Caballero)
                ((Caballero)objetivo).NroPasos = 0;

            daño = Ataque - (objetivo.Defensa / 2);
            objetivo.Salud = objetivo.Salud - daño;
        }

        internal override int calcularTimerPersonaje(){
            return 3500;
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
