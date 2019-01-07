using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireWarriors.Comunicacion_en_Red;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FireWarriors.Comunicacion_en_Red{
    internal class ConexionRed{
        internal ConexionRed(ArquitecturaRed arquitecturaRed, Form1 form1, string argumento){
            this.arquitecturaRed = arquitecturaRed;
            switcher = new Switcher(form1);

            switch(arquitecturaRed){
                case ArquitecturaRed.cliente:
                    Client(form1, argumento);
                break;
                case ArquitecturaRed.servidor:
                    Server(form1, argumento);
                break;
            }
        }

        private void Client(Form1 form1, string ipPartida){
            cliente = new Cliente(form1, switcher, ipPartida);
        }

        private void Server(Form1 form1, string nombreTablero){
            servidor = new Servidor(form1, switcher, nombreTablero);
        }

        internal void cerrarConexion(){
            switch(arquitecturaRed){
                case ArquitecturaRed.cliente:
                    cliente.cerrarConexion();
                break;
                case ArquitecturaRed.servidor:
                    servidor.cerrarConexion();
                break;
            }
        }

        internal void enviarDatos(string mensaje){
            switch(arquitecturaRed){
                case ArquitecturaRed.cliente:
                    cliente.enviarDatos(mensaje);
                break;
                case ArquitecturaRed.servidor:
                    servidor.enviarDatos(mensaje);
                break;
            }
        }

        internal static string obtenerIpLocal(){
            IPAddress[] direcciones = Dns.GetHostAddresses(Dns.GetHostName());
            string direccion = string.Empty;

            foreach(IPAddress dirs in direcciones)
                if(!dirs.IsIPv6LinkLocal || !dirs.IsIPv6SiteLocal || !dirs.IsIPv6Multicast || !dirs.IsIPv6Teredo)
                    direccion = dirs.ToString();

            return direccion;
        }

        internal enum ArquitecturaRed{
            cliente,
            servidor
        }

        private ArquitecturaRed arquitecturaRed;
        private Cliente cliente;
        private Switcher switcher;
        private Servidor servidor;
    }
}
