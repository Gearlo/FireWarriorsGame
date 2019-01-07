using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuartzTypeLib;
using System.Threading;

namespace FireWarriors.Multimedia{
    internal class Audio{
        internal Audio(){
            fondo = new DS_Audio(Juego.appPath() + "\\Sonido\\Musica_Fondo.mp3");  // Musica que se usa de fondo durante el juego en el tablero
            interfaz = new DS_Audio(Juego.appPath() + "\\Sonido\\NoSePuede.mp3"); // Este sonido se produce cuando el usuario intenta hcer una accion que no es permitida
        }
        
        // Metodos que reproduce la musica de fondo
        internal void musicaDeFondoIniciar(){
            fondo.reproducirLoop();
        }

        internal void musicaDeFondoDetener(){
            fondo.detenerLoop();
        }
        
        // Metodos que reproducen sonidos
        internal void sonidoNoPermitidoReproducir(){
            interfaz.reproducir();
        }

        private DS_Audio fondo;  //Reproduce la musica de fondo
        private DS_Audio interfaz; //Este arreglo tiene los sonidos de la interfaz y afines
    }

    //Clase para reproducir audio usando DirectShow
    class DS_Audio{
        internal DS_Audio(string Archivo){
            mediaControl = new QuartzTypeLib.FilgraphManager();
            mediaControl.RenderFile(Archivo);
            audioBasico = (QuartzTypeLib.IBasicAudio)mediaControl;
            mediaEvento = (QuartzTypeLib.IMediaEvent)mediaControl;
            mediaPosicion = (QuartzTypeLib.IMediaPosition)mediaControl;
        }

        internal void detenerLoop(){
            hiloLoop.Abort();
            mediaControl.Stop();
            mediaPosicion.CurrentPosition = 0;
        }
        
        private void loopMusic(){ // Hilo que se encarga de repetir el sonido una y otra vez
            mediaPosicion.CurrentPosition = 0;

            mediaControl.Run(); // reproducir el sonido por primera vez
            
            while(true){
                Thread.Sleep(1500);

                if(mediaPosicion.CurrentPosition >= mediaPosicion.Duration){
                    mediaPosicion.CurrentPosition = 0;
                    this.mediaControl.Run(); //reproducir la musica de nuevo
                }
            }
        }

        // Reproducir el sonido
        internal void reproducir(){
            mediaPosicion.CurrentPosition = 0;
            mediaControl.Run();
        }
        
        // Reproducir el sonido y repetirlo una y otra vez
        internal void reproducirLoop(){
            hiloLoop = new Thread(new ThreadStart(loopMusic));
            hiloLoop.Start();
        }

        private QuartzTypeLib.IBasicAudio audioBasico;
        private Thread hiloLoop;
        private QuartzTypeLib.IMediaControl mediaControl;
        private QuartzTypeLib.IMediaEvent mediaEvento;
        private QuartzTypeLib.IMediaPosition mediaPosicion;
    }
}
