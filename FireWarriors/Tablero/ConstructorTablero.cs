using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Multimedia;
using System.IO;
using System.Xml;

namespace FireWarriors.Tablero{
    internal class ConstructorTablero{
        internal static int X{get{return 25;}}
        internal static int Y{get{return 15;}}
        
        internal ConstructorTablero(){
            tableros = new List<TableroDescripcion>();
            img = new Dictionary<string, int>();

            try{
                foreach(string s in Directory.GetDirectories(Juego.appPath() + "\\Imagenes\\Tableros")){
                    string nombre = s.Substring(s.LastIndexOf('\\') + 1);

                    tableros.Add(new TableroDescripcion(nombre, nombre + "\\" + nombre + ".jpg"));
                }
            }catch(DirectoryNotFoundException){
                System.Windows.Forms.MessageBox.Show("No se pudo encontrar el directorio de los tableros", "Error de Directorio", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        internal Coordenada[] obtenerCoordenadasPersonajes(string nombreTablero, LadoTablero ladoDelTablero) { //MetodoQueRetorna las posiciones de los personajes dentro del tablero
            XmlDocument xml = new XmlDocument();
            Coordenada[] tmp = new Coordenada[5];
            int i = 0;

            xml.Load(Juego.appPath() + "\\Imagenes\\Tableros\\" + nombreTablero + "\\" + nombreTablero + ".xml");
            XmlNodeList board, coordenadas;

            board = xml.GetElementsByTagName("board");

            if(ladoDelTablero == LadoTablero.derecha) {
                coordenadas = ((XmlElement)board[0]).GetElementsByTagName("coorder");
            } else {
                coordenadas = ((XmlElement)board[0]).GetElementsByTagName("coorizq");
            }

            foreach(XmlElement coor in coordenadas) {
                int x = int.Parse(coor.GetAttribute("x"));
                int y = int.Parse(coor.GetAttribute("y"));

                tmp[i++] = new Coordenada(x, y);
            }

            return tmp;
        }

        internal TableroDescripcion[] obtenerListaTableros(){ //este metodo devuelve un arreglo de descripciones de tableros
            return tableros.ToArray();
        }

        internal Suelo[,] obtenerTablero(String nombreTablero, Grafico grafico) { //Metodo que genera los tableros
            Suelo[,] tmp = new Suelo[X, Y];
            XmlDocument xml = new XmlDocument();
            XmlNodeList tablero, pieza, casilla;
            string piezaPrincipal = string.Empty;

            xml.Load(Juego.appPath() + "\\Imagenes\\Tableros\\" + nombreTablero + "\\" + nombreTablero + ".xml");

            tablero = xml.GetElementsByTagName("board");
            pieza = ((XmlElement)tablero[0]).GetElementsByTagName("piece");
            casilla = ((XmlElement)tablero[0]).GetElementsByTagName("box");

            foreach(XmlElement p in pieza) {
                if(!p.GetAttribute("default").Equals(string.Empty))
                    piezaPrincipal = p.InnerText;

                img[p.GetAttribute("id")] = grafico.cargarImagen("\\Imagenes\\Tableros\\" + nombreTablero + "\\" + p.InnerText);
            }

            for(int i = 0; i < ConstructorTablero.X; i++)
                for(int j = 0; j < ConstructorTablero.Y; j++){
                    string idPiezaPrincipal = piezaPrincipal.Substring(0, piezaPrincipal.LastIndexOf('.'));
                    tmp[i, j] = new Suelo(idPiezaPrincipal, false, img[idPiezaPrincipal]);
                }

            foreach(XmlElement c in casilla) {
                int x = int.Parse(c.GetAttribute("x"));
                int y = int.Parse(c.GetAttribute("y"));
                string id = c.GetAttribute("id");

                tmp[x, y] = new Suelo(id, true, img[id]);
            }

            return tmp;
        }

        internal enum LadoTablero{
            izquierda,
            derecha
        }

        private readonly Dictionary<string, int> img;
        private readonly List<TableroDescripcion> tableros;
    }

    class TableroDescripcion{
        internal string NombreTablero{get; private set;}
        internal string PathImagenTablero{get; private set;}

        internal TableroDescripcion(string nombre, string pathImagen){
            this.NombreTablero = nombre;
            this.PathImagenTablero = Juego.appPath() + "\\Imagenes\\Tableros\\" + pathImagen;
        }

        public override string ToString(){
            return NombreTablero;
        }
    }
}
