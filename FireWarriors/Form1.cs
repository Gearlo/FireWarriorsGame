// 768, 417
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireWarriors.Personajes;
using FireWarriors.Tablero;
using FireWarriors.Comunicacion_en_Red;

namespace FireWarriors{
    internal partial class Form1 : Form{
        internal ConexionRed Conexion{get{return conexion;}}
        internal ConstructorTablero ConstructorTablero{get{return constructorTablero;}}
        internal Juego Juego{get{return juego;}}
        internal string NombreTablero{get; set;}
        internal string[] PersonajesLocales{get{return personajesLocales;}}
        internal string[] PersonajesRemotos{get{return personajesRemotos;}set{personajesRemotos = value;}}
        
        internal Form1(){
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e){
            if(juego != null)
                juego.formClick();
        }

        private void Form1_DoubleClick(object sender, EventArgs e){
            if(juego != null)
                juego.formDoubleClick();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e){
            if(juego != null)
                juego.close();

            if(conexion != null)
                conexion.cerrarConexion();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e){
            if(juego != null)
                juego.formKeyPress(e.KeyChar);
        }

        private void Form1_Load(object sender, EventArgs e){
			Size = new Size(768, 412);
            constructorTablero = new ConstructorTablero(); //Instanciar el creador de tableros
            string[] personajes = Enum.GetNames(typeof(Personaje.TipoPersonaje));
            NombreTablero = string.Empty;
            Random rnd = new Random();

            for(int i = 0; i < personajes.Length; i++)
                personajes[i] = personajes[i].Replace('_', ' ');

            lstListaTableros.Items.AddRange(constructorTablero.obtenerListaTableros()); //mostrar la lista de tableros
            cmbPersonaje_1.Items.AddRange(personajes);
            cmbPersonaje_2.Items.AddRange(personajes);
            cmbPersonaje_3.Items.AddRange(personajes);
            cmbPersonaje_4.Items.AddRange(personajes);
            cmbPersonaje_5.Items.AddRange(personajes);

            try{
                lstListaTableros.SelectedIndex = 1; //Seleccionar el primero de los tableros de la lista

                //seleccionar automaticamente los tipos de personajes
                cmbPersonaje_1.SelectedIndex = rnd.Next(personajes.Length - 1);
                cmbPersonaje_2.SelectedIndex = rnd.Next(personajes.Length - 1);
                cmbPersonaje_3.SelectedIndex = rnd.Next(personajes.Length - 1);
                cmbPersonaje_4.SelectedIndex = rnd.Next(personajes.Length - 1);
                cmbPersonaje_5.SelectedIndex = rnd.Next(personajes.Length - 1);

                lblIPPartida.Text = ConexionRed.obtenerIpLocal(); //Mostrar la IP de la nueva partida
            }catch(ArgumentOutOfRangeException){
                Close();
            }
        }

        private void btnIniciarPartida_Click(object sender, EventArgs e){
            try{
                string personaje;

                personaje = string.Empty;
                personajesLocales = new string[5];
                btnIniciarPartida.Text = "Esperando contrincante ...";
                btnIniciarPartida.Enabled = false;
                NombreTablero = lstListaTableros.SelectedItem.ToString();

                conexion = new ConexionRed(ConexionRed.ArquitecturaRed.servidor, this, NombreTablero); //esperar conexion del otro jugador
                
                tabIniciarJuego.Visible = boxPersonajes.Visible = false;

                personajesLocales[0] = cmbPersonaje_1.SelectedItem.ToString();
                personajesLocales[1] = cmbPersonaje_2.SelectedItem.ToString();
                personajesLocales[2] = cmbPersonaje_3.SelectedItem.ToString();
                personajesLocales[3] = cmbPersonaje_4.SelectedItem.ToString();
                personajesLocales[4] = cmbPersonaje_5.SelectedItem.ToString();

                for(int i = 0; i < personajesLocales.Length; i++){
                    personaje += personajesLocales[i];

                    if(i < personajesLocales.Length - 1)
                        personaje += ",";
                }

                conexion.enviarDatos("0;" + personaje);

                while(personajesRemotos == null); // Espera por los personajesRemotos

                juego = new Juego(this, true);
                
                timerPersonajeSeleccionado.Enabled = true;    
            }catch(Exception){
                MessageBox.Show("Ocurrio un problema!");
            }

        }

        private void btnUnirsePartida_Click(object sender, EventArgs e){
            if(!txtDireccionIP.Text.Trim().Equals(string.Empty)){
                try {
                    string personaje;

                    personaje = string.Empty;
                    personajesLocales = new string[5];
                    btnUnirsePartida.Enabled = false;

                    conexion = new ConexionRed(ConexionRed.ArquitecturaRed.cliente, this, txtDireccionIP.Text);
                    
                    while(NombreTablero.Equals(string.Empty)); // Espera a que el servidor mande el nombre del tablero.
                    while(personajesRemotos == null); // Espera por los personajes

                    tabIniciarJuego.Visible = boxPersonajes.Visible = false;

                    personajesLocales[0] = cmbPersonaje_1.SelectedItem.ToString();
                    personajesLocales[1] = cmbPersonaje_2.SelectedItem.ToString();
                    personajesLocales[2] = cmbPersonaje_3.SelectedItem.ToString();
                    personajesLocales[3] = cmbPersonaje_4.SelectedItem.ToString();
                    personajesLocales[4] = cmbPersonaje_5.SelectedItem.ToString();

                    for(int i = 0; i < personajesLocales.Length; i++){
                        personaje += personajesLocales[i];

                        if(i < personajesLocales.Length - 1)
                            personaje += ",";
                    }

                    conexion.enviarDatos("0;" + personaje);

                    juego = new Juego(this, false);
                    
                    timerPersonajeSeleccionado.Enabled = true;
                }catch{
                    MessageBox.Show("Ocurrio un problema!");
                }
            }else
                MessageBox.Show("Debe ingresar una ip no vacia");
        }

        internal void cambiarTurno(bool aLocal){
            if(lblTurno.InvokeRequired){
                LlamadoSeguro llamadoSeguro = new LlamadoSeguro(cambiarTurno);
                Invoke(llamadoSeguro, new object[]{ aLocal });
            }else{
                if(aLocal)
                    lblTurno.Text = "Es su turno, presione una tecla para terminarlo";
                else
                    lblTurno.Text = "Es turno de su contrincante";
            }
        }

        internal void iniciarTimer(int duracion, ConstructorTablero.LadoTablero ladoTablero){
            duracionTimer = (duracion / 1000);

            if(ladoTablero == ConstructorTablero.LadoTablero.izquierda){
                lblTiempoRestanteizq.Visible = true;
                lblTiempoRestanteDer.Visible = false;
            } else {
                lblTiempoRestanteDer.Visible = true;
                lblTiempoRestanteizq.Visible = false;
            }

            timerAtq.Enabled = true;
        }

        private void lstListaTableros_SelectedIndexChanged(object sender, EventArgs e){
            TableroDescripcion tmp = (TableroDescripcion)lstListaTableros.SelectedItem;

            picImagenTablero.ImageLocation = tmp.PathImagenTablero;
        }

        private void timerAtq_Tick(object sender, EventArgs e){
            if(duracionTimer > -1){
                duracionTimer = duracionTimer - 0.2;

                if(duracionTimer > 0){
                    lblTiempoRestanteDer.Text = Math.Round(duracionTimer, 2).ToString();
                    lblTiempoRestanteizq.Text = Math.Round(duracionTimer, 2).ToString();
                }else{
                    lblTiempoRestanteDer.Text = "0";
                    lblTiempoRestanteizq.Text = "0";
                }
            }else{
                timerAtq.Enabled = false;
                lblTiempoRestanteDer.Visible = false;
                lblTiempoRestanteizq.Visible = false;
            }
        }

        private void timerModoBatallaCompleto_Tick(object sender, EventArgs e){
            juego.personajeSeleccionadoDerecho();

            if(juego.EstadoGeneralDelJuego == Juego.EstadoDelJuego.JuegoTerminado){
                lblTurno.Visible = false;
                timerPersonajeSeleccionado.Enabled = false;
                timerModoBatallaCompleto.Enabled = false;
            }
        }

        private void timerPersonajeSeleccionado_Tick(object sender, EventArgs e){
            juego.personajeSeleccionadoIzquierdo();

            if(juego.EstadoGeneralDelJuego == Juego.EstadoDelJuego.JuegoTerminado){
                lblTurno.Visible = false;
                timerPersonajeSeleccionado.Enabled = false;
                timerModoBatallaCompleto.Enabled = false;
            }
        }

        private ConexionRed conexion;
        private ConstructorTablero constructorTablero;
        private double duracionTimer = 0;
        private Juego juego;
        private delegate void LlamadoSeguro(bool aLocal);
        private string[] personajesLocales;
        private string[] personajesRemotos;
    }
}
