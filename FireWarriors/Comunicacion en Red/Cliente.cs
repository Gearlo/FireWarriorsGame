using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace FireWarriors.Comunicacion_en_Red{
    internal class Cliente{
        internal Cliente(Form1 form1, Switcher switcher, string ipPartida){
            this.form1 = form1;
            this.switcher = switcher;

            conectarAServidor(ipPartida);
            obtenerFlujos();

            receiveData = new Thread(new ThreadStart(recibeDatos));
            receiveData.Start();
        }

        internal void cerrarConexion(){
            try{
                receiveData.Abort();
                escritor.Close();
                lector.Close();
                cliente.Close();
            }catch(EncoderFallbackException){
            }catch(SocketException){
            }
        }

        private void conectarAServidor(string ipPartida){
            DialogResult result = DialogResult.Yes;
            
            do{
                try{
                    cliente = new TcpClient(ipPartida, 62525);
                }catch(SocketException){
                    result = MessageBox.Show("Problemas para conectar con el contrincante\n Desea volver a conectar?", "Mensaje", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            } while(cliente == null & result == DialogResult.Yes);
        }

        internal void enviarDatos(string mensaje){
            escritor.WriteLine(mensaje);
            escritor.Flush();
        }

        private void form1Close(){
            if(form1.InvokeRequired){
                Form1Close f1c = new Form1Close(form1Close);
                form1.Invoke(f1c);
            }else{
                MessageBox.Show("El otro Jugador desaparecio :/", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        private Form1 form1;
        private StreamWriter escritor;
        private StreamReader lector;
        private Thread receiveData;
        private Switcher switcher;
    }
}
