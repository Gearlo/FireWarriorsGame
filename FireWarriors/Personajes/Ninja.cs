using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Tablero;

namespace FireWarriors.Personajes{
    internal class Ninja : Personaje{
        private ConstructorTablero.LadoTablero ladoAtaca;
        internal Ninja(int idImagenDelPersonaje, bool esLocal, ConstructorTablero.LadoTablero ladoAtaca) : base(idImagenDelPersonaje, esLocal, 1, 5){
            this.ladoAtaca = ladoAtaca;

            //adpatacion de las estadisticas base al las estadisticas del ninja
            Salud -= 50;
            SaludBase = Salud;
            Ataque = 30;
            Defensa -= 50;
            Velocidad += 100;
        }

        internal override void atacar(Personaje objetivo){
            if(objetivo is Caballero)
                ((Caballero)objetivo).NroPasos = 0;

            objetivo.Salud = 0;
        }

        internal override int calcularTimerPersonaje(){
            return 2000;
        }

        internal override List<Coordenada> rangoAtaque(Coordenada coor){
            List<Coordenada> tmp = new List<Coordenada>();

            switch(ladoAtaca){
                case ConstructorTablero.LadoTablero.izquierda:
                    for(int i = 1; i <= numeroEspaciosAtaque; i++){
                        if(coor.X - i < 0 || Tablero[coor.X - i, coor.Y].TipoDelSuelo.EsObstaculo)
                            break;

                        tmp.Add(new Coordenada(coor.X - i, coor.Y));
                    }
                break;
                case ConstructorTablero.LadoTablero.derecha:
                    for(int i = 1; i <= numeroEspaciosAtaque; i++){
                        if(coor.X + i >= ConstructorTablero.X || Tablero[coor.X + i, coor.Y].TipoDelSuelo.EsObstaculo)
                            break;

                        tmp.Add(new Coordenada(coor.X + i, coor.Y));
                    }
                break;
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

            //ARRIBA DERECHA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X + i >= ConstructorTablero.X || coor.Y - i < 0 || Tablero[coor.X + i, coor.Y - i].TipoDelSuelo.EsObstaculo || Tablero[coor.X + i, coor.Y - i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X + i, coor.Y - i));
            }

            //DERECHA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X + i >= ConstructorTablero.X || Tablero[coor.X + i, coor.Y].TipoDelSuelo.EsObstaculo || Tablero[coor.X + i, coor.Y].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X + i, coor.Y));
            }

            //ABAJO DERECHA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X + i >= ConstructorTablero.X || coor.Y + i >= ConstructorTablero.Y || Tablero[coor.X + i, coor.Y + i].TipoDelSuelo.EsObstaculo || Tablero[coor.X + i, coor.Y + i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X + i, coor.Y + i));
            }

            //ABAJO
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.Y + i >= ConstructorTablero.Y || Tablero[coor.X, coor.Y + i].TipoDelSuelo.EsObstaculo || Tablero[coor.X, coor.Y + i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X, coor.Y + i));
            }

            //ABAJO IZQUIERDA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X - i < 0 || coor.Y + i >= ConstructorTablero.Y || Tablero[coor.X - i, coor.Y + i].TipoDelSuelo.EsObstaculo || Tablero[coor.X - i, coor.Y + i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X - i, coor.Y + i));
            }

            //IZQUIERDA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X - i < 0 || Tablero[coor.X - i, coor.Y].TipoDelSuelo.EsObstaculo || Tablero[coor.X - i, coor.Y].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X - i, coor.Y));
            }

            //ARRIBA IZQUIERDA
            for(int i = 1; i <= numeroEspaciosMovimiento; i++){
                if(coor.X - i < 0 || coor.Y - i < 0 || Tablero[coor.X - i, coor.Y - i].TipoDelSuelo.EsObstaculo || Tablero[coor.X - i, coor.Y - i].Personaje != null)
                    break;

                tmp.Add(new Coordenada(coor.X - i, coor.Y - i));
            }

            return tmp;
        }
    }
}
