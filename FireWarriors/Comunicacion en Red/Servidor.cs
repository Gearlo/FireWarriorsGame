using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FireWarriors.Comunicacion_en_Red{
    internal class Servidor{
        internal Servidor(Form1 form1, Switcher switcher, string nombreTablero){
            this.form1 = form1;
            this.switcher = switcher;

            esperarConexion();
            obtenerFlujos();

            receiveData = new Thread(new ThreadStart(recibeDatos));
            receiveData.Start();

            enviarDatos("1;" + nombreTablero);
        }

        internal void cerrarConexion(){
            try{
                receiveData.Abort();
                escritor.Close();
                lector.Close();
                cliente.Close();
                servidor.Stop();
            }catch(EncoderFallbackException){
            }catch(SocketException){
            }
        }

        internal void enviarDatos(string mensaje){
            escritor.WriteLine(mensaje);
            escritor.Flush();
        }

        private void esperarConexion(){
            servidor = new TcpListener(IPAddress.Any, 62525);

            servidor.Start();

            cliente = servidor.AcceptTcpClient();
        }

        private void form1Close(){
            if(form1.InvokeRequired){
                Form1Close f1c = new Form1Close(form1Close);
                form1.Invoke(f1c);
            }else{
                System.Windows.Forms.MessageBox.Show("El otro Jugador desaparecio :/", "Mensaje", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                form1.Close();
            }
        }

        private void obtenerFlujos(){
            escritor = new StreamWriter(cliente.GetStream());
            escritor.Flush();

            lector = new StreamReader(cliente.GetStream());
        }

        private void recibeDatos(){
            string mensaje;

            try{
                do{
                    mensaje = lector.ReadLine();

                    if(mensaje != null)
                        switcher.getMessage(mensaje);
                }while(mensaje != null);
            }catch(IOException){
            }

            form1Close();
        }

        private delegate void Form1Close();
        private TcpClient cliente;
        private StreamWriter escritor;
        private Form1 form1;
        private StreamReader lector;
        private Thread receiveData;
        private TcpListener servidor;
        private Switcher switcher;
    }
}
