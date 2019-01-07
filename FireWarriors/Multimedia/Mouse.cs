using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using dx_lib32;

namespace FireWarriors.Multimedia{
    internal class Mouse{
        internal int MousePosX{get{return mouse.Mouse.X;}} // Esta propiedad devuelve la posicion x en la que se encuantra el tablero
        internal int MousePosY{get{return mouse.Mouse.Y;}} // Esta propiedad devuelve la posicion x en la que se encuantra el tablero
        
        internal Mouse(int FormHandle){
            mouse = new dx_Input_Class(); //Intanciar el objeto de captura
            mouse.Init(FormHandle); //Inicializar el capturador
        }

        internal void finalizarCapturaEntrada(){
            mouse.Terminate();
            mouse = null;
        }
        
        internal MouseClick mouseClick(){
            if(mouse.Mouse.Left_Button == -1)
                return MouseClick.izquierdo;
            else if (mouse.Mouse.Right_Button == -1)
                return MouseClick.derecho;
            else if (mouse.Mouse.Middle_Button == -1)
                return MouseClick.central;
            else
                return MouseClick.ninguno;
        }

        internal enum MouseClick{
            izquierdo,
            derecho,
            central,
            ninguno
        }

        private dx_Input_Class mouse; //objeto de entrada del motor
    }
}
