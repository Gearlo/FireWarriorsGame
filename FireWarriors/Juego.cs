using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Multimedia;
using FireWarriors.Personajes;
using FireWarriors.Tablero;
using System.Windows.Forms;

namespace FireWarriors{
    internal class Juego{
        internal EstadoDelJuego EstadoGeneralDelJuego{get; set;}

        internal Juego(Form1 form1, bool anfitrion){
            int formHandle;
            
            // Asigna variables del juego
            this.form1 = form1;
            this.anfitrion = anfitrion;

            // Setea lo esencial del juego
            formHandle = form1.Handle.ToInt32();
            ladoLocal = anfitrion ? ConstructorTablero.LadoTablero.izquierda : ConstructorTablero.LadoTablero.derecha;
            EstadoGeneralDelJuego = anfitrion ? EstadoDelJuego.EsperandoAccionLocal : EstadoDelJuego.EsperandoAccionRed; // Para saber quien inicia la partida
            
            // Setea el motor multimedia del juego
            audio = new Audio(); //instancia el sistema de audio
            grafico = new Grafico(formHandle, 800, 500, form1, this); //instancia el sistema grafico
            mouse = new Mouse(formHandle);
            
            // Desencadena el resto del juego
            tablero = form1.ConstructorTablero.obtenerTablero(form1.NombreTablero, grafico);//crear el arreglo que representa el tablero
            Personaje.Tablero = tablero;

            form1.cambiarTurno(anfitrion);

            setPersonajes(form1.PersonajesLocales, true);
            setPersonajes(form1.PersonajesRemotos, false);
            
            audio.musicaDeFondoIniciar(); // Reproduce la musica de fondo
            grafico.iniciarGraficas(tablero); // Inicia el renderizado
            grafico.crearTableroEnPantalla(); // Representar el arreglo que representa el tablero en pantalla
        }
        
        internal static string appPath(){
            return Application.StartupPath;
        }

        internal void cambiarTurno(){
            yaAtaco = yaMovio = false;

            switch(EstadoGeneralDelJuego){
                case EstadoDelJuego.EsperandoAccionLocal:
                    EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionRed;
                    form1.cambiarTurno(false);
                break;
                case EstadoDelJuego.EsperandoAccionRed:
                    EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionLocal;
                    form1.cambiarTurno(true);
                break;
            }
        }

        // Metodo que cierra el juego en ejecucion
        internal void close(){
            mouse.finalizarCapturaEntrada();
            audio.musicaDeFondoDetener();
            grafico.detenerGraficas();
        }

        // Este metodo retorna True si una coordenada dada pertenece a un rango especifico
        private bool comprobarRango(Coordenada coordenada, List<Coordenada> rango){
            foreach(Coordenada tmp in rango)
                if(coordenada.X == tmp.X & coordenada.Y == tmp.Y)
                    return true;

            return false;
        }

        // Metodo que recibe una cadena que describe el tipo de personaje y devuelve un obejeto
        private Personaje crearPersonaje(string TipoPersonaje, ConstructorTablero.LadoTablero ladoTablero){
            int img;
            bool lado = ladoTablero == ConstructorTablero.LadoTablero.derecha ^ anfitrion;
            Personaje personaje;

            switch(TipoPersonaje){
                case "Arquero":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_Arquero_Derecha : grafico.idImagen_Arquero_Izquierda;
                    
                    personaje = new Arquero(img, lado);
                break;
                case "Caballero":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_Caballero_Derecha : grafico.idImagen_Caballero_Izquierda;
                    
                    personaje = new Caballero(img, lado);
                break;
                case "Mago":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_Mago_Derecha : grafico.idImagen_Mago_Izquierda;
                    
                    personaje = new Mago(img, lado);
                break;
                case "Ninja":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_Ninja_Derecha : grafico.idImagen_Ninja_Izquierda;
                    
                    personaje = new Ninja(img, lado, ladoTablero);
                break;
                case "Paladin Espada":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_PaladinEspada_Derecha : grafico.idImagen_PaladinEspada_Izquierda;
                    
                    personaje = new Paladin_Espada(img, lado);
                break;
                case "Paladin Lanza":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_PaladinLanza_Derecha : grafico.idImagen_PaladinLanza_Izquierda;
                    
                    personaje = new Paladin_Lanza(img, lado);
                break;
                case "Paladin Mazo":
                    img = ladoTablero == ConstructorTablero.LadoTablero.derecha ? grafico.idImagen_PaladinMazo_Derecha : grafico.idImagen_PaladinMazo_Izquierda;
                    
                    personaje = new Paladin_Mazo(img, lado);
                break;
                default:
                    throw new Exception("El tipo de personaje no existe");
            }

            return personaje;
        }

        private void deseleccionarPersonaje(){
            personajeSeleccionado = null;
            personajeSeleccionadoCoor = null;
            grafico.deseleccionarPersonaje();
        }
        
         //Metodo que verifica si el personaje que esta atacando entrara al modo batalla completo
        private bool siEntraModoBatallaCompleta(Coordenada coorAtacante, Coordenada coorVictima){
            bool comp1 = comprobarRango(coorVictima, tablero[coorAtacante.X, coorAtacante.Y].Personaje.rangoAtaque(coorAtacante));
            bool comp2 = comprobarRango(coorAtacante, tablero[coorVictima.X, coorVictima.Y].Personaje.rangoAtaque(coorVictima));

            return comp1 && comp2;
        }

        internal void formClick(){ // Este metodo se recibe cuando el usuario da click en el formulario
            Coordenada coor = grafico.bloqueDelTableroSeleccionado(mouse.MousePosX, mouse.MousePosY); // Obtiene el bloque que se selecciono con el mouse

            if(coor == null)
                return;

            switch(EstadoGeneralDelJuego){
                case EstadoDelJuego.EsperandoAccionLocal:
                    if(seleccionarPersonaje(coor)) // Se marca como personaje seleccionado al que se le dio click
                        form1.Conexion.enviarDatos("8;" + coor.X + "," + coor.Y);
                    else
                        break;

                    if(tablero[coor.X, coor.Y].Personaje.EsLocal){
                        Mouse.MouseClick clic = mouse.mouseClick(); // Obtiene cual de los tres botones del mouse fue presionado
                        
                        switch(clic){
                            case Mouse.MouseClick.izquierdo:
                                if(!yaMovio){
                                    grafico.mostrarRango(personajeSeleccionado.rangoMovimiento(coor), grafico.idImagen_interfaz_CuadroRangoMover);

                                    EstadoGeneralDelJuego = EstadoDelJuego.PersonajeSeleccionadoMoverLocal; //cambia el estado del juego

                                    form1.Conexion.enviarDatos("2;" + coor.X + "," + coor.Y + "," + clic.ToString());
                                }
                            break;
                            case Mouse.MouseClick.derecho:
                                if(!yaAtaco){
                                    grafico.mostrarRango(personajeSeleccionado.rangoAtaque(coor), grafico.idImagen_interfaz_CuadroRangoAtacar);

                                    EstadoGeneralDelJuego = EstadoDelJuego.PersonajeSeleccionadoAtacarLocal; //cambia el estado del juego a... personaje seleccionado para mover

                                    form1.Conexion.enviarDatos("2;" + coor.X + "," + coor.Y + "," + clic.ToString());
                                }
                            break;
                        }
                    }
                break;
                case EstadoDelJuego.PersonajeSeleccionadoMoverLocal:
                    if(comprobarRango(coor, personajeSeleccionado.rangoMovimiento(personajeSeleccionadoCoor))){ // Comprueba si el cuadro al que se le dio click esta dentro del rango de movimiento del personaje seleccionado
                        grafico.ocultarRango();
                        moverPersonaje(personajeSeleccionadoCoor, coor); // Mover personaje
                        seleccionarPersonaje(coor);
                        
                        yaMovio = !yaMovio;
                        EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionLocal; // Cambiando estado a esperando accion

                        form1.Conexion.enviarDatos("3;" + coor.X + "," + coor.Y);

                        if(yaAtaco){
                            cambiarTurno();
                            form1.Conexion.enviarDatos("7");
                        }
                    }
                break;
                case EstadoDelJuego.PersonajeSeleccionadoAtacarLocal:
                    if(tablero[coor.X, coor.Y].Personaje != null && !tablero[coor.X, coor.Y].Personaje.EsLocal){ // Verifica si hay un personaje en las coordenadas en las que se va a atacar
                        if(comprobarRango(coor, personajeSeleccionado.rangoAtaque(personajeSeleccionadoCoor))){ // Verifica si las coordenadas que se seleccionaron estan dentro del rango
                            int codigo;

                            grafico.ocultarRango();

                            if(siEntraModoBatallaCompleta(personajeSeleccionadoCoor, coor) && System.Windows.Forms.MessageBox.Show("Desea entrar en modo batalla completo?", "Mensaje", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes){
                                codigo = 5;
                                victimaSeleccionadaMBC = tablero[coor.X, coor.Y].Personaje;

                                personajeSeleccionadoDerecho();
                                
                                form1.timerModoBatallaCompleto.Enabled = true;
                                teclaMBC_huir = true;
                                
                                grafico.ataqueCompleto(personajeSeleccionado, victimaSeleccionadaMBC, ladoLocal);
                            }else{
                                codigo = 4;

                                grafico.ataqueSimple(personajeSeleccionado, tablero[coor.X, coor.Y].Personaje, ladoLocal);
                                
                                seleccionarPersonaje(coor);
                            }

                            yaAtaco = !yaAtaco;
                            EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionLocal; //Cambiando estado a esperando accion

                            form1.Conexion.enviarDatos(codigo + ";" + coor.X + "," + coor.Y);

                            if(yaMovio){
                                cambiarTurno();
                                form1.Conexion.enviarDatos("7");
                            }
                        }
                    }
                break;
            }
        }

        internal void formClickRemoto(Coordenada coor, string boton){
            ConstructorTablero.LadoTablero lado;
            lado = ladoLocal == ConstructorTablero.LadoTablero.derecha ? ConstructorTablero.LadoTablero.izquierda : ConstructorTablero.LadoTablero.derecha;

            switch(EstadoGeneralDelJuego){
                case EstadoDelJuego.EsperandoAccionRed:
                    switch(boton){
                        case "izquierdo":
                            grafico.mostrarRango(personajeSeleccionado.rangoMovimiento(coor), grafico.idImagen_interfaz_CuadroRangoMover);
                            
                            EstadoGeneralDelJuego = EstadoDelJuego.PersonajeSeleccionadoMoverRed;
                        break;
                        case "derecho":
                            grafico.mostrarRango(personajeSeleccionado.rangoAtaque(coor), grafico.idImagen_interfaz_CuadroRangoAtacar);
                            
                            EstadoGeneralDelJuego = EstadoDelJuego.PersonajeSeleccionadoAtacarRed;
                        break;
                    }
                break;
                case EstadoDelJuego.PersonajeSeleccionadoMoverRed:
                    grafico.ocultarRango();
                    moverPersonaje(personajeSeleccionadoCoor, coor);
                    seleccionarPersonaje(coor);
                    
                    EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionRed;
                break;
                case EstadoDelJuego.PersonajeSeleccionadoAtacarRed:
                    grafico.ocultarRango();
                    
                    grafico.ataqueSimple(personajeSeleccionado, tablero[coor.X, coor.Y].Personaje, lado);
                    
                    seleccionarPersonaje(coor);
                    
                    EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionRed;
                break;
            }
        }
        
        internal void formDoubleClick(){
            switch(EstadoGeneralDelJuego){
                case EstadoDelJuego.PersonajeSeleccionadoMoverLocal:
                case EstadoDelJuego.PersonajeSeleccionadoAtacarLocal:
                    deseleccionarPersonaje();
                    grafico.ocultarRango();
                    EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionLocal;
                    form1.Conexion.enviarDatos("6");
                break;
            }
        }

        internal void formDoubleClickRemoto(){
            deseleccionarPersonaje();
            grafico.ocultarRango();
            EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionRed;
        }

        internal void formKeyPress(char keyChar){
            switch(EstadoGeneralDelJuego){
                case EstadoDelJuego.EsperandoAccionLocal:
                    if(keyChar == ' '){ // Osea que se presiona la tecla Espacio
                        cambiarTurno();
                        form1.Conexion.enviarDatos("7");
                    }else if(teclaMBC_huir && keyChar == '\b'){ // Osea se presiono la tecla Backspace
                        salirModoBatallaCompleto();
                        form1.Conexion.enviarDatos("9");
                    }
                break;
            }
        }

        internal void matarPersonaje(Personaje futuroDifunto){
            Coordenada coordenadaEnTablero = localizarPersonaje(futuroDifunto);

            tablero[coordenadaEnTablero.X, coordenadaEnTablero.Y].Personaje = null;
            
            for(int i = 0; i < 5; i++)
                if(personajesLocales[i] != null && personajesLocales[i].Equals(futuroDifunto)){
                    personajesLocales[i] = null;
                    contadorLocales++;
                }else if (personajesRemotos[i] != null && personajesRemotos[i].Equals(futuroDifunto)){
                    personajesRemotos[i] = null;
                    contadorRemotos++;
                }

            // ----Declara un ganador
            if(contadorRemotos == 5){
                MessageBox.Show("Gano");
                EstadoGeneralDelJuego = EstadoDelJuego.PersonajeGano;
                grafico.declaracion(true);
            }else if(contadorLocales == 5){
                MessageBox.Show("Perdio");
                EstadoGeneralDelJuego = EstadoDelJuego.PersonajePerdio;
                grafico.declaracion(false);
            }
            // ---- | -----

            if(form1.timerModoBatallaCompleto.Enabled){
                victimaSeleccionadaMBC = null;
                personajeSeleccionadoDerecho();
                form1.timerModoBatallaCompleto.Enabled = false;
            }else
                deseleccionarPersonaje();
        }

        internal void modoBatallaCompletoRemoto(Coordenada coor){
            ConstructorTablero.LadoTablero lado;
            lado = ladoLocal == ConstructorTablero.LadoTablero.derecha ? ConstructorTablero.LadoTablero.izquierda : ConstructorTablero.LadoTablero.derecha;

            grafico.ocultarRango();

            victimaSeleccionadaMBC = tablero[coor.X, coor.Y].Personaje;

            personajeSeleccionadoDerecho();
            
            form1.timerModoBatallaCompleto.Enabled = true;
            teclaMBC_huir = true;
            
            grafico.ataqueCompleto(personajeSeleccionado, victimaSeleccionadaMBC, lado);

            EstadoGeneralDelJuego = EstadoDelJuego.EsperandoAccionRed;
        }

        // Metodo que mueve al personaje de un bloque a otro
        private void moverPersonaje(Coordenada posicionI, Coordenada posicionF){
            tablero[posicionF.X, posicionF.Y].Personaje = tablero[posicionI.X, posicionI.Y].Personaje;
            tablero[posicionI.X, posicionI.Y].Personaje = null;
            
            if(tablero[posicionF.X, posicionF.Y].Personaje is Caballero){
                if(posicionI.X != posicionF.X)
                    ((Caballero)tablero[posicionF.X, posicionF.Y].Personaje).NroPasos = Math.Abs(posicionI.X - posicionF.X); // Asigna al contador el numero de espacios recorridos en X
                else if(posicionI.Y != posicionF.Y)
                    ((Caballero)tablero[posicionF.X, posicionF.Y].Personaje).NroPasos = Math.Abs(posicionI.Y - posicionF.Y); // Asigna al contador el numero de espacios recorridos en Y
            }
        }
        
        internal void personajeSeleccionadoDerecho(){
            if(form1.InvokeRequired){
                LlamadoSeguroDerecho lsd = new LlamadoSeguroDerecho(personajeSeleccionadoDerecho);
                form1.Invoke(lsd);
            }else{
                if(victimaSeleccionadaMBC != null){
                    string path = appPath() + "\\Imagenes\\Personajes\\Pj-";
                    
                    path += victimaSeleccionadaMBC.GetType().Name.Replace("_", string.Empty);
                    path += ladoLocal == ConstructorTablero.LadoTablero.derecha ^ !victimaSeleccionadaMBC.EsLocal ? "Der" : "Izq";
                    path += ".png";

                    form1.groupPersonajeSeleccionadoInfoDerecho.Visible = true;
                    form1.lblNombrePersonjeDerecho.Text = "Nombre: " + victimaSeleccionadaMBC.GetType().Name.Replace('_', ' ');
                    form1.lblSaludPersonajeDerecho.Text = "Salud: " + (victimaSeleccionadaMBC.Salud < 0 ? 0 : victimaSeleccionadaMBC.Salud) + "/" + victimaSeleccionadaMBC.SaludBase;
                    form1.lblAtaquePersonajeDerecho.Text = "Ataque: " + victimaSeleccionadaMBC.Ataque;
                    form1.lblDefensaPersonajeDerecho.Text = "Defensa: " + victimaSeleccionadaMBC.Defensa;
                    form1.lblVelocidadPersonajeDerecho.Text = "Velocidad: " + victimaSeleccionadaMBC.Velocidad;
                    int valor = (int)Math.Round((double)((victimaSeleccionadaMBC.Salud * 100) / victimaSeleccionadaMBC.SaludBase));
                    form1.BarraSaludPersonajeDerecho.Value = (valor < 0 ? 0 : valor);
                    form1.picPersonajeDerecho.ImageLocation = path;
                }else
                    form1.groupPersonajeSeleccionadoInfoDerecho.Visible = false;
            }
        }

        internal void personajeSeleccionadoIzquierdo(){
            if(form1.InvokeRequired){
                LlamadoSeguroIzquierdo lsi = new LlamadoSeguroIzquierdo(personajeSeleccionadoIzquierdo);
                form1.Invoke(lsi);
            }else{
                if(personajeSeleccionado != null){
                    string path = appPath() + "\\Imagenes\\Personajes\\Pj-";

                    path += personajeSeleccionado.GetType().Name.Replace("_", string.Empty);
                    path += ladoLocal == ConstructorTablero.LadoTablero.derecha ^ !personajeSeleccionado.EsLocal ? "Der" : "Izq";
                    path += ".png";

                    form1.groupPersonajeSeleccionadoInfoIzquierdo.Visible = true;
                    form1.lblNombrePersonjeIzquierdo.Text = "Nombre: " + personajeSeleccionado.GetType().Name.Replace('_', ' ');
                    form1.lblSaludPersonajeIzquierdo.Text = "Salud: " + (personajeSeleccionado.Salud < 0 ? 0 : personajeSeleccionado.Salud) + "/" + personajeSeleccionado.SaludBase;
                    form1.lblAtaquePersonajeIzquierdo.Text = "Ataque: " + personajeSeleccionado.Ataque;
                    form1.lblDefensaPersonajeIzquierdo.Text = "Defensa: " + personajeSeleccionado.Defensa;
                    form1.lblVelocidadPersonajeIzquierdo.Text = "Velocidad: " + personajeSeleccionado.Velocidad;
                    int valor = (int)Math.Round((double)((personajeSeleccionado.Salud * 100) / personajeSeleccionado.SaludBase));
                    form1.BarraSaludPersonajeIzquierdo.Value = valor < 0 ? 0 : valor;

                    form1.picPersonajeIzquierdo.ImageLocation = path;
                }else
                    form1.groupPersonajeSeleccionadoInfoIzquierdo.Visible = false;
            }
        }

        internal void salirModoBatallaCompleto(){
            grafico.Play = false;
            teclaMBC_huir = false;
            victimaSeleccionadaMBC = null;
            personajeSeleccionadoDerecho();
            form1.timerModoBatallaCompleto.Enabled = false;
        }

        internal bool seleccionarPersonaje(Coordenada coor){
            if(coor != null && tablero[coor.X, coor.Y].Personaje != null){
                    personajeSeleccionado = tablero[coor.X, coor.Y].Personaje;
                    personajeSeleccionadoCoor = coor;
                    grafico.seleccionarPersonaje(coor);

                    return true;
                }

            return false;
        }

        private void setPersonajes(string[] personajes, bool EsLocal){
            ConstructorTablero.LadoTablero ladoTablero = anfitrion ^ EsLocal ? ConstructorTablero.LadoTablero.derecha : ConstructorTablero.LadoTablero.izquierda;
            Coordenada[] coordenadasPersonajes = form1.ConstructorTablero.obtenerCoordenadasPersonajes(form1.NombreTablero, ladoTablero); // Obtener las coordenadas donde se colocará a los personajes
            
            if(EsLocal){
                personajesLocales[0] = crearPersonaje(personajes[0], ladoTablero);
                personajesLocales[1] = crearPersonaje(personajes[1], ladoTablero);
                personajesLocales[2] = crearPersonaje(personajes[2], ladoTablero);
                personajesLocales[3] = crearPersonaje(personajes[3], ladoTablero);
                personajesLocales[4] = crearPersonaje(personajes[4], ladoTablero);

                //colocar a los personajes locales en el tablero
                for(int i = 0; i < coordenadasPersonajes.Length; i++)
                    tablero[coordenadasPersonajes[i].X, coordenadasPersonajes[i].Y].Personaje = personajesLocales[4 - i];
            }else{
                personajesRemotos[0] = crearPersonaje(personajes[0], ladoTablero);
                personajesRemotos[1] = crearPersonaje(personajes[1], ladoTablero);
                personajesRemotos[2] = crearPersonaje(personajes[2], ladoTablero);
                personajesRemotos[3] = crearPersonaje(personajes[3], ladoTablero);
                personajesRemotos[4] = crearPersonaje(personajes[4], ladoTablero);

                //colocar a los personajes remotos en el tablero
                for(int i = 0; i < coordenadasPersonajes.Length; i++)
                    tablero[coordenadasPersonajes[i].X, coordenadasPersonajes[i].Y].Personaje = personajesRemotos[4 - i];
            }
        }

        // ------------------------------------ Inicio Metodos por desaparecer -------------------------------------------

        // Metodo que recorre el tablero buscando a un personaje especifico
        private Coordenada localizarPersonaje(Personaje Personaje) {
            Coordenada coordenada = null;

            for(int i = 0; i < ConstructorTablero.X; i++)
                for(int j = 0; j < ConstructorTablero.Y; j++)
                    if(tablero[i, j].Personaje != null) // Ignora los cuadros donde no haya personajes
                        if(tablero[i, j].Personaje == Personaje) { // Compara las referencias para ver si ambos son el mismo personaje
                            coordenada = new Coordenada(i, j); // Asigna coordenadas
                            break;
                        }

            return coordenada;
        }
        // ------------------------------------ Fin Metodos por desaparecer -------------------------------------------

        //Esta enumeracion contiene los posibles estados del juego, dependiendo del estado del juego son las operaciones que se van a ralizar con cada click que haga el usuario
        internal enum EstadoDelJuego{
            Iniciando,                        //Este estado es el que tiene el juego cuando se esta iniciando
            EsperandoAccionLocal,             //Este estado es en el que se espera que el jugador haga su acciones
            EsperandoAccionRed,
            PersonajeSeleccionadoMoverLocal,  //Estado del juego cuando se ha selleccionado a un personaje para moverlo
            PersonajeSeleccionadoMoverRed,
            PersonajeSeleccionadoAtacarLocal, //Estado del juego cuando se ha selleccionado a un personaje para atacar
            PersonajeSeleccionadoAtacarRed,
            PersonajeGano,
            PersonajePerdio,
            JuegoTerminado
        }

        private delegate void LlamadoSeguroIzquierdo();
        private delegate void LlamadoSeguroDerecho();
        private bool anfitrion;
        private Audio audio; // Clase que maneja el audio del juego
        private int contadorLocales = 0;
        private int contadorRemotos = 0;
        private Mouse mouse; // Clase que se encarga de capturar los dispositivos de entrada y operar con ellos
        private Form1 form1;
        private Grafico grafico; // Clase que se encarga de procesar y mostrar graficos
        private ConstructorTablero.LadoTablero ladoLocal;
        private Personaje personajeSeleccionado;  // Esta variable tipo personaje almacena al personaje que se haya selleccionado si se esta en el estado: PersonajeSeleccionado sino la referencia será null
        private Coordenada personajeSeleccionadoCoor;
        private Personaje[] personajesLocales = new Personaje[5]; // Arreglo de personajes que maneja el jugador local
        private Personaje[] personajesRemotos = new Personaje[5]; // Arreglo de personajes que maneja el jugador remoto
        private Suelo[,] tablero; // Este es un arreglo bidimensional de tipo suelo que representa el tablero del juego
        private bool teclaMBC_huir = false;
        private bool yaMovio = false;
        private bool yaAtaco = false;
        private Personaje victimaSeleccionadaMBC;
    }
}
