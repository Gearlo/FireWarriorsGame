using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Personajes;
using FireWarriors.Tablero;
using System.Threading;
using dx_lib32;

// Los metodos y variables que contengan ** no estan completamente optimizados
namespace FireWarriors.Multimedia{
    internal class Grafico{
        internal bool Play{set{play = value;}}

        //** id de las imagenes de los personajes
            public int idImagen_Arquero_Izquierda { set; get; }
            public int idImagen_Caballero_Izquierda { set; get; }
            public int idImagen_Mago_Izquierda { set; get; }
            public int idImagen_Ninja_Izquierda { set; get; }
            public int idImagen_PaladinEspada_Izquierda { set; get; }
            public int idImagen_PaladinLanza_Izquierda { set; get; }
            public int idImagen_PaladinMazo_Izquierda { set; get; }

            public int idImagen_Arquero_Derecha { set; get; }
            public int idImagen_Caballero_Derecha { set; get; }
            public int idImagen_Mago_Derecha { set; get; }
            public int idImagen_Ninja_Derecha { set; get; }
            public int idImagen_PaladinEspada_Derecha { set; get; }
            public int idImagen_PaladinLanza_Derecha { set; get; }
            public int idImagen_PaladinMazo_Derecha { set; get; }

        //** id imagenes de la interfaz
            public int idImagen_interfaz_CuadroRangoMover { set; get; }
            public int idImagen_interfaz_CuadroRangoAtacar { set; get; }
            int idImagen_Interfaz_CuadroSeleccion { set; get; }
            int idImagen_Interfaz_FondoBatallaIzquierdo { set; get; }
            int idImagen_Interfaz_FondoBatallaDerecho { set; get; }
            int idImagen_Interfaz_FondoBatalla { set; get; }
        

        internal Grafico(int formHandle, int width, int height, Form1 form1, Juego juego){
            this.form1 = form1;
            this.juego = juego;

            bloque = new Bloque(height / ConstructorTablero.Y, width / ConstructorTablero.X);
            graficas = new dx_GFX_Class(); // Instancia el objeto grafico del motor
            render = graficas.Init(formHandle, width, (height + 100), 32, true);
            
            cargarImagenesGuerreros();
            cargarImagenesInterfaz();
        }

        private void activarTimer(int duracion){
            form1.iniciarTimer(duracion, orientacionAgresor);
        }

        // Este metodo abre el modo batalla completa
        internal void ataqueCompleto(Personaje agresor, Personaje victima, ConstructorTablero.LadoTablero orientacionAgresor){
            // Estas variables se usan en varios metodos durante el ataque
            // Estas variables deben intercambiarse cada vez que se ejecuta un ataque ataca
            this.agresor = agresor;
            this.victima = victima;

            spritesBatalla = new Sprite[3]; // Se crea un nuevo arreglo con los sprites que se van a ver durante la batalla

            //se cargan los sprites que se van a mostrar durante la batalla
            spritesBatalla[0] = new Sprite(idImagen_Interfaz_FondoBatalla, 0, 0, 5);

            switch(orientacionAgresor){
                case ConstructorTablero.LadoTablero.derecha:
                spritesBatalla[1] = new Sprite(victima.IdImagenDelPersonaje, -300, 100, 0, 300, 300);
                spritesBatalla[2] = new Sprite(agresor.IdImagenDelPersonaje, 800, 100, 0, 300, 300);
                break;
                case ConstructorTablero.LadoTablero.izquierda:
                spritesBatalla[1] = new Sprite(agresor.IdImagenDelPersonaje, -300, 100, 0, 300, 300);
                spritesBatalla[2] = new Sprite(victima.IdImagenDelPersonaje, 800, 100, 0, 300, 300);
                break;
            }

            hiloBatalla = new Thread(new ThreadStart(batallaCompleta)); // Se crea un nuevo hilo que sera la que mostrará la animacion en pantalla, y en el instante dado ejecurtará el ataque

            // Oculta el tablero y mostrar la batalla
            mostrarElTablero = false;
            mostrarBatalla = true;

            hiloBatalla.Start(); // Inicia el hilo
        }
        
        // Este metodo abre el modo batalla simple
        internal void ataqueSimple(Personaje agresor, Personaje victima, ConstructorTablero.LadoTablero orientacionAgresor){
            // Estas variables se usan en varios metodos durante el ataque
            this.agresor = agresor;
            this.victima = victima;
            this.orientacionAgresor = orientacionAgresor;

            spritesBatalla = new Sprite[3]; // Se crea un nuevo arreglo con los sprites que se van a ver durante la batalla

            // Se carga los sprites que se van a mostrar durante la batalla
            spritesBatalla[0] = new Sprite(idImagen_Interfaz_FondoBatallaDerecho, 0, 0, 5); // Se carga los sprites que se van a mostrar durante la batalla

            switch(orientacionAgresor){
                case ConstructorTablero.LadoTablero.derecha:
                    spritesBatalla[1] = new Sprite(victima.IdImagenDelPersonaje, -300, 100, 0, 300, 300);
                    spritesBatalla[2] = new Sprite(agresor.IdImagenDelPersonaje, 800, 100, 0, 300, 300);
                break;
                case ConstructorTablero.LadoTablero.izquierda:
                    spritesBatalla[1] = new Sprite(agresor.IdImagenDelPersonaje, -300, 100, 0, 300, 300);
                    spritesBatalla[2] = new Sprite(victima.IdImagenDelPersonaje, 800, 100, 0, 300, 300);
                break;
            }

            hiloBatalla = new Thread(new ThreadStart(batallaSimple)); // Se crea un nuevo hilo que sera la que mostrara la animacion en pantalla, y en el instante dado ejecurtara el ataque

            // Oculta el tablero y mostrar la batalla
            mostrarElTablero = false;
            mostrarBatalla = true;

            hiloBatalla.Start(); // Incia el hilo
        }
        
        //**
        private void batallaCompleta(){
            encontrarPersonajes();
            Thread.Sleep(500);
            Personaje temp;
            
            while((agresor.Salud > 0 && victima.Salud > 0) & play){
                ejecutarAtaque();
                form1.Juego.personajeSeleccionadoDerecho();
                Thread.Sleep(2000);

                Thread.Sleep(agresor.calcularTimerPersonaje()); // Aqui duerme la hebra mientras carga el timer
                
                if(form1.InvokeRequired){
                    TimerAtk tim = new TimerAtk(activarTimer);
                    form1.Invoke(tim, new object[]{agresor.calcularTimerPersonaje()});
                }

                //agresor y atacante intercambian papeles
                temp = agresor;
                agresor = victima;
                victima = temp;

                switch(orientacionAgresor){
                    case ConstructorTablero.LadoTablero.derecha:
                        orientacionAgresor = ConstructorTablero.LadoTablero.izquierda;
                    break;
                    case ConstructorTablero.LadoTablero.izquierda:
                        orientacionAgresor = ConstructorTablero.LadoTablero.derecha;
                    break;
                }

                if(!(agresor.Salud > 0 && victima.Salud > 0) | !play)
                    break;

                ejecutarAtaque();
                form1.Juego.personajeSeleccionadoDerecho();
                Thread.Sleep(2000);

                Thread.Sleep(agresor.calcularTimerPersonaje()); //aqui duerme la hebra mientras carga el timer
                
                if(form1.InvokeRequired){
                    TimerAtk tim = new TimerAtk(activarTimer);
                    form1.Invoke(tim, new object[]{agresor.calcularTimerPersonaje()});
                }

                //agresor y atacante intercambian papeles
                temp = agresor;
                agresor = victima;
                victima = temp;

                switch(orientacionAgresor){
                    case ConstructorTablero.LadoTablero.derecha:
                        orientacionAgresor = ConstructorTablero.LadoTablero.izquierda;
                    break;
                    case ConstructorTablero.LadoTablero.izquierda:
                        orientacionAgresor = ConstructorTablero.LadoTablero.derecha;
                    break;
                }
            }

            play = true;
            mostrarBatalla = false;
            spritesBatalla = null;
            mostrarElTablero = true;
        }

        // Este metodo muestra la animacion de un personaje atacando a otro
        private void batallaSimple(){
            encontrarPersonajes(); // Hace que los personajes se encuentren
            Thread.Sleep(500); // Espera un poco antes de inciar el ataque
            ejecutarAtaque(); // Ataca
            Thread.Sleep(4000); // Espera 4 segundos antes de quitar la pantalla

            // Quita la pantalla de batalla y volver a mostrar el tablero
            mostrarBatalla = false;
            spritesBatalla = null;
            mostrarElTablero = true;
        }

        // Metodo que indica que parte del suelo fue seleccionado
        internal Coordenada bloqueDelTableroSeleccionado(int x, int y){
            return new Coordenada(x / bloque.Width, y / bloque.Height);
        }

        //** Bucle del Render
        private void bucleRender(){
            while(render){
                if(tablero != null)
                    mostrarPersonajes();

                //Ciclos que leen todos los sprites a mostrarse en pantalla que estan en las listas
                try{
                    if(mostrarElTablero){  //verifica si hay que mostrar el tablero en pantalla
                        foreach(Sprite tmp in spriteTablero)
                            graficas.DRAW_Map(tmp.IdImagen, tmp.X, tmp.Y, tmp.Z, tmp.Width, tmp.Width);

                        foreach (Sprite tmp in spriteRangos)
                            graficas.DRAW_Map(tmp.IdImagen, tmp.X, tmp.Y, tmp.Z, tmp.Height, tmp.Width);

                        if(spriteSeleccion != null)
                            graficas.DRAW_Map(spriteSeleccion.IdImagen, spriteSeleccion.X, spriteSeleccion.Y, spriteSeleccion.Z, spriteSeleccion.Height, spriteSeleccion.Width);

                        foreach (Sprite tmp in spritePersonajes)
                            graficas.DRAW_Map(tmp.IdImagen, tmp.X, tmp.Y, tmp.Z, tmp.Height, tmp.Width);
                    }

                    if(mostrarBatalla)
                        foreach(Sprite tmp in spritesBatalla)
                            graficas.DRAW_Map(tmp.IdImagen, tmp.X, tmp.Y, tmp.Z, tmp.Height, tmp.Width);

                    graficas.Frame();//Renderizar el fotograma 
                }catch(Exception){
                }
            }
        }

        // Metodo para cargar una imagen para crear un sprite y devuelve un identificador de la imagen
        internal int cargarImagen(string path){
            return graficas.MAP_Load(Juego.appPath() + path, 0);
        }
        
        //**
        private void cargarImagenesInterfaz(){ 
            idImagen_interfaz_CuadroRangoMover = cargarImagen("\\Imagenes\\Interfaz\\CuadroDeRango.png");
            idImagen_interfaz_CuadroRangoAtacar = cargarImagen("\\Imagenes\\Interfaz\\CuadroDeRangoAtaque.png");
            idImagen_Interfaz_CuadroSeleccion = cargarImagen("\\Imagenes\\Interfaz\\CuadroSeleccion.png");
            idImagen_Interfaz_FondoBatallaIzquierdo = cargarImagen("\\Imagenes\\Interfaz\\FondoBatallaIzquierdo.png");
            idImagen_Interfaz_FondoBatallaDerecho = cargarImagen("\\Imagenes\\Interfaz\\FondoBatallaDerecho.png");
            idImagen_Interfaz_FondoBatalla = cargarImagen("\\Imagenes\\Interfaz\\FondoBatalla.png");
        }

        //**
        private void cargarImagenesGuerreros(){
            idImagen_Arquero_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-ArqueroDer.png");
            idImagen_Arquero_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-ArqueroIzq.png");

            idImagen_Caballero_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-CaballeroDer.png");
            idImagen_Caballero_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-CaballeroIzq.png");

            idImagen_Mago_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-MagoDer.png");
            idImagen_Mago_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-MagoIzq.png");

            idImagen_Ninja_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-NinjaDer.png");
            idImagen_Ninja_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-NinjaIzq.png");

            idImagen_PaladinEspada_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinEspadaDer.png");
            idImagen_PaladinEspada_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinEspadaIzq.png");

            idImagen_PaladinLanza_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinLanzaDer.png");
            idImagen_PaladinLanza_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinLanzaIzq.png");

            idImagen_PaladinMazo_Derecha = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinMazoDer.png");
            idImagen_PaladinMazo_Izquierda = cargarImagen("\\Imagenes\\Personajes\\Pj-PaladinMazoIzq.png");
        }
        
        // Este metodo crea la lista de sprites que forman el tablero
        internal void crearTableroEnPantalla(){
            // Bucle que lee el tablero y crea los sprites para visualizar el tablero en pantalla
            for(int i = 0; i < ConstructorTablero.X; i++)
                for(int j = 0; j < ConstructorTablero.Y; j++)
                    spriteTablero.Add(new Sprite(tablero[i, j].TipoDelSuelo.IdImagenSuelo, bloque.Width * i, bloque.Height * j, 5, bloque.Height, bloque.Width)); // Lee la imagen de cada bloque y la añade a la lista de sprites a mostrar en pantalla

            mostrarElTablero = true;
        }

        // Metodo que carga imagen de gane o pierda
        internal void declaracion(bool gano){
            juego.EstadoGeneralDelJuego = Juego.EstadoDelJuego.JuegoTerminado;

            int idPantalla;
            if(gano)
                idPantalla = cargarImagen("\\Imagenes\\Interfaz\\Pantalla final_Victoria.png");
            else
                idPantalla = cargarImagen("\\Imagenes\\Interfaz\\Pantalla final_Derrota.png");

            mostrarElTablero = mostrarBatalla = false;

            hiloBucleRender.Abort();

            while(true){
                graficas.DRAW_Map(idPantalla, 0, 0, 0, 800, 600);
                graficas.Frame();
            }
        }
        
        internal void deseleccionarPersonaje(){
            spriteSeleccion = null;
        }

        // Este metodo hace que los dos personejes que lucharan se encuentren
        private void encontrarPersonajes(){
            int aceleracion = 1;

            while(spritesBatalla[1].X < 0 | spritesBatalla[2].X > 500){
                spritesBatalla[1].X += aceleracion;
                spritesBatalla[2].X -= aceleracion;

                aceleracion++;
                
                Thread.Sleep(40);
            }
        }

        // Metodo para detener el renderizado y terminar el sistema grafico
        internal void detenerGraficas(){
            hiloBucleRender.Abort(); // Termina el hilo del bucle de renderizado
            graficas.Terminate();
            graficas = null; // Tambien tiene que descargar de memoria todas las imagenes
        }

        // Este metodo provoca que el agresor ataque a su victima
        private void ejecutarAtaque(){
            // El personaje atacante se dirige a su victima para atacar
            int aceleracion = 4; 

            switch(orientacionAgresor){
                case ConstructorTablero.LadoTablero.derecha:
                    while(spritesBatalla[2].X > 400){
                        spritesBatalla[2].X -= aceleracion * aceleracion;

                        aceleracion++;

                        Thread.Sleep(40);
                    }
                break;
                case ConstructorTablero.LadoTablero.izquierda:
                    while(spritesBatalla[1].X < 100){
                        spritesBatalla[1].X += aceleracion * aceleracion;

                        aceleracion++;

                        Thread.Sleep(40);
                    }
                break;
            }

            Thread.Sleep(200);

            new Thread(new ThreadStart(victimaTemblar)).Start();

            agresor.atacar(victima); // Se reliza el ataque a la victima señalda

            if(victima.Salud == 0)
                juego.matarPersonaje(victima); // Mata a la victima si su hp llega a cero

            // El personaje atacante retrocede luego de atacar a su victima
            switch(orientacionAgresor){
                case ConstructorTablero.LadoTablero.derecha:
                    while(aceleracion > 0){
                        aceleracion--;

                        spritesBatalla[2].X += aceleracion * aceleracion;

                        Thread.Sleep(40);
                    }
                break;
                case ConstructorTablero.LadoTablero.izquierda:
                    while(aceleracion > 0){
                        aceleracion--;
                        
                        spritesBatalla[1].X -= aceleracion * aceleracion;
                        
                        Thread.Sleep(40);
                    }
                break;
            }
        }

        //Metodo para inicar el renderizado
        internal void iniciarGraficas(Suelo[,] tablero){
            this.tablero = tablero;

            // Instancia las listas de sprites a mostrar en pantalla
            spriteTablero = new List<Sprite>();
            spritePersonajes = new List<Sprite>();
            spriteRangos = new List<Sprite>();

            hiloBucleRender = new Thread(new ThreadStart(bucleRender)); // Crea e inicia el hilo que estara renderizando la imagen
            hiloBucleRender.Start();

        }

        // Metodo que crea las lista de sprites de los personajes que se mostraran en pantalla
        private void mostrarPersonajes(){
            spritePersonajes.Clear(); // Vacia la lista de sprites de personajes para refrescar todas las posiciones 

            // Bucle que lee el tablero y crea los sprites para visualizar el tablero en pantalla
            for(int i = 0; i < ConstructorTablero.X; i++)
                for(int j = 0; j < ConstructorTablero.Y; j++)
                    if(tablero[i, j].Personaje != null)
                        spritePersonajes.Add(new Sprite(tablero[i, j].Personaje.IdImagenDelPersonaje, bloque.Width * i, bloque.Height * j, 5, bloque.Height, bloque.Width));
        }

        // Este metodo ilustra en pantalla el rango de un personaje
        internal void mostrarRango(List<Coordenada> rango, int IdImagenBloqueIluminacion){
            foreach(Coordenada tmp in rango)
                spriteRangos.Add(new Sprite(IdImagenBloqueIluminacion, bloque.Width * tmp.X, bloque.Height * tmp.Y, 5, bloque.Height, bloque.Width));
        }

        // Este metodo deja de mostrar el rango de un personaje
        internal void ocultarRango(){
            spriteRangos.Clear();
        }
        
        // Este metodo selecciona uno de los personajes en pantalla
        internal void seleccionarPersonaje(Coordenada coor){
            spriteSeleccion = new Sprite(idImagen_Interfaz_CuadroSeleccion, bloque.Width * coor.X, bloque.Height * coor.Y, 5, bloque.Height, bloque.Width);
        }

        // En modo batalla este metodo hace temblar a la victima
        private void victimaTemblar(){
            int acelaracion = 15;

            switch(orientacionAgresor){
                case ConstructorTablero.LadoTablero.derecha:
                    while(acelaracion > 0){
                        while(spritesBatalla[1].X > 0){
                            spritesBatalla[1].X -= acelaracion;

                            Thread.Sleep(40);
                        }

                        while(spritesBatalla[1].X < 50){
                            spritesBatalla[1].X += acelaracion;

                            Thread.Sleep(40);
                        }

                        acelaracion -= 4;
                    }
                break;
                case ConstructorTablero.LadoTablero.izquierda:
                    while(acelaracion > 0){
                        while(spritesBatalla[2].X < 550){
                            spritesBatalla[2].X += acelaracion;

                            Thread.Sleep(40);
                        }

                        while(spritesBatalla[2].X > 500){
                            spritesBatalla[2].X -= acelaracion;

                            Thread.Sleep(40);
                        }

                        acelaracion -= 4;
                    }
                break;
            }
        }

        private delegate void TimerAtk(int duracion);
        private Personaje agresor; // Esta variable almacenan el personaje en el modo batalla
        private Bloque bloque;
        private Form1 form1;
        private dx_lib32.dx_GFX_Class graficas; // Instancia del objeto grafico del motor
        private Thread hiloBatalla; // Esta hebra es la que se encarga de manejar las animaciones en pantalla
        private Thread hiloBucleRender; // Esta es la hebra donde se va a estar renderizandose la pantalla
        private Juego juego;
        private bool mostrarBatalla; // Variable boolana que dice si se esta mostrando una batalla en pantalla
        private bool mostrarElTablero; // Variable booleana que determina si se muestra el tablero en pantalla
        private ConstructorTablero.LadoTablero orientacionAgresor;
        private volatile bool play = true;
        private readonly bool render; // Variable booleana que controla el bucle de renderizado
        private Sprite[] spritesBatalla; // Este arreglo almacena los sprites que se van a ver durante la batalla
        private List<Sprite> spritePersonajes; // Esta lista guarda los sprites de personajes a mostrar en pantalla
        private List<Sprite> spriteRangos; // Esta lista se encarga de mostrar los rangos de movimiento y de ataque
        private Sprite spriteSeleccion; // Este sprite almacena la imagen del cuadro seleccionado
        private List<Sprite> spriteTablero; // Esta lista guarda la lista de sprites que se mostraran en pantalla
        private Suelo[,] tablero;
        private Personaje victima; // Esta variable almacenan el personaje en el modo batalla
    }

    class Bloque{
        internal int Height{get; private set;}
        internal int Width{get; private set;}

        internal Bloque(int height, int width){
            Height = height;
            Width = width;
        }
    }

    class Sprite{
        internal int Height{get; private set;}
        internal int IdImagen{get; private set;}
        internal int Width{get; private set;}
        internal int X{get; set;}
        internal int Y{get; private set;}
        internal int Z{get; private set;}

        //Este construtor guarda un sprite que tiene las mismas dimensiones del archivo de imagen
        internal Sprite(int idImagen, int x, int y, int z) : this(idImagen, x, y, z, 0, 0){}

        //Este contructor crea un sprite que tiene Height y Width que no son los originales del archivo de imagen
        internal Sprite(int idImagen, int x, int y, int z, int height, int width){
            IdImagen = idImagen;
            X = x;
            Y = y;
            Z = z;
            Height = height;
            Width = width;
        }
    }
}
