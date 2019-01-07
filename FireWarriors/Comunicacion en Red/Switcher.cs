using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Tablero;

namespace FireWarriors.Comunicacion_en_Red{
    internal class Switcher{
        internal Switcher(Form1 form1){
            this.form1 = form1;
        }

        internal void getMessage(string mensaje){
            string[] submensaje = mensaje.Split(';');
            string[] coordenadas;
            Coordenada coor;

            switch(submensaje[0]){
                case "0": // Recibe los 5 personajes
                    string[] personajes = submensaje[1].Split(',');
                    form1.PersonajesRemotos =  personajes;
                break;
                case "1": // Recibe el nombre del tablero
                    form1.NombreTablero = submensaje[1];
                break;
                case "2": // Recibe accion
                    coordenadas = submensaje[1].Split(',');
                    coor = new Coordenada(int.Parse(coordenadas[0]), int.Parse(coordenadas[1]));
                    form1.Juego.formClickRemoto(coor, coordenadas[2]);
                break;
                case "3": // Recibe un movimiento
                    coordenadas = submensaje[1].Split(',');
                    coor = new Coordenada(int.Parse(coordenadas[0]), int.Parse(coordenadas[1]));
                    form1.Juego.formClickRemoto(coor, string.Empty);
                break;
                case "4": // Recibe un ataque simple
                    coordenadas = submensaje[1].Split(',');
                    coor = new Coordenada(int.Parse(coordenadas[0]), int.Parse(coordenadas[1]));
                    form1.Juego.formClickRemoto(coor, string.Empty); // <-- lleva el lado del jugador que ataco
                break;
                case "5": // Recibe un ataque completo
                    coordenadas = submensaje[1].Split(',');
                    coor = new Coordenada(int.Parse(coordenadas[0]), int.Parse(coordenadas[1]));
                    form1.Juego.modoBatallaCompletoRemoto(coor); // <-- lleva el lado del juegador que ataco
                break;
                case "6": // Recibe un cancelado
                    form1.Juego.formDoubleClickRemoto();
                break;
                case "7": // Recibe Cambio de turno
                    form1.Juego.cambiarTurno();
                break;
                case "8": // Recibe las coordenas del click
                    coordenadas = submensaje[1].Split(',');
                    coor = new Coordenada(int.Parse(coordenadas[0]), int.Parse(coordenadas[1]));
                    form1.Juego.seleccionarPersonaje(coor);
                break;
                case "9": // Recibe cancelado de Modo Batalla Completo
                    form1.Juego.salirModoBatallaCompleto();
                break;
            }
        }

        private Form1 form1;
    }
}
