using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireWarriors.Tablero{
    internal class Coordenada{
        internal int X{get; private set;}
        internal int Y{get; private set;}

        internal Coordenada(int x, int y){
            X = x;
            Y = y;
        }
    }
}
