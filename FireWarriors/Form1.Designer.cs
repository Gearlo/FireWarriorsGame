namespace FireWarriors
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabIniciarJuego = new System.Windows.Forms.TabControl();
            this.tabPageCrearPartida = new System.Windows.Forms.TabPage();
            this.lblIPPartida = new System.Windows.Forms.Label();
            this.btnIniciarPartida = new System.Windows.Forms.Button();
            this.lblPartidaIP = new System.Windows.Forms.Label();
            this.boxTablero = new System.Windows.Forms.GroupBox();
            this.picImagenTablero = new System.Windows.Forms.PictureBox();
            this.lstListaTableros = new System.Windows.Forms.ListBox();
            this.tabPageUnirsePartida = new System.Windows.Forms.TabPage();
            this.boxUnirsePartida = new System.Windows.Forms.GroupBox();
            this.txtDireccionIP = new System.Windows.Forms.TextBox();
            this.btnUnirsePartida = new System.Windows.Forms.Button();
            this.lblDireccionIP = new System.Windows.Forms.Label();
            this.boxPersonajes = new System.Windows.Forms.GroupBox();
            this.lblPersonajes = new System.Windows.Forms.Label();
            this.lblPersonaje_5 = new System.Windows.Forms.Label();
            this.lblPersonaje_4 = new System.Windows.Forms.Label();
            this.lblPersonaje_3 = new System.Windows.Forms.Label();
            this.lblPersonaje_2 = new System.Windows.Forms.Label();
            this.lblPersonaje_1 = new System.Windows.Forms.Label();
            this.cmbPersonaje_5 = new System.Windows.Forms.ComboBox();
            this.cmbPersonaje_4 = new System.Windows.Forms.ComboBox();
            this.cmbPersonaje_3 = new System.Windows.Forms.ComboBox();
            this.cmbPersonaje_2 = new System.Windows.Forms.ComboBox();
            this.cmbPersonaje_1 = new System.Windows.Forms.ComboBox();
            this.lblTurno = new System.Windows.Forms.GroupBox();
            this.groupPersonajeSeleccionadoInfoDerecho = new System.Windows.Forms.GroupBox();
            this.BarraSaludPersonajeDerecho = new System.Windows.Forms.ProgressBar();
            this.lblVelocidadPersonajeDerecho = new System.Windows.Forms.Label();
            this.lblDefensaPersonajeDerecho = new System.Windows.Forms.Label();
            this.lblAtaquePersonajeDerecho = new System.Windows.Forms.Label();
            this.lblSaludPersonajeDerecho = new System.Windows.Forms.Label();
            this.lblNombrePersonjeDerecho = new System.Windows.Forms.Label();
            this.picPersonajeDerecho = new System.Windows.Forms.PictureBox();
            this.groupPersonajeSeleccionadoInfoIzquierdo = new System.Windows.Forms.GroupBox();
            this.BarraSaludPersonajeIzquierdo = new System.Windows.Forms.ProgressBar();
            this.lblVelocidadPersonajeIzquierdo = new System.Windows.Forms.Label();
            this.lblDefensaPersonajeIzquierdo = new System.Windows.Forms.Label();
            this.lblAtaquePersonajeIzquierdo = new System.Windows.Forms.Label();
            this.lblSaludPersonajeIzquierdo = new System.Windows.Forms.Label();
            this.lblNombrePersonjeIzquierdo = new System.Windows.Forms.Label();
            this.picPersonajeIzquierdo = new System.Windows.Forms.PictureBox();
            this.timerPersonajeSeleccionado = new System.Windows.Forms.Timer(this.components);
            this.lblTiempoRestanteizq = new System.Windows.Forms.Label();
            this.lblTiempoRestanteDer = new System.Windows.Forms.Label();
            this.lblDañoIzq = new System.Windows.Forms.Label();
            this.lblDañoDer = new System.Windows.Forms.Label();
            this.timerModoBatallaCompleto = new System.Windows.Forms.Timer(this.components);
            this.timerAtq = new System.Windows.Forms.Timer(this.components);
            this.tabIniciarJuego.SuspendLayout();
            this.tabPageCrearPartida.SuspendLayout();
            this.boxTablero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImagenTablero)).BeginInit();
            this.tabPageUnirsePartida.SuspendLayout();
            this.boxUnirsePartida.SuspendLayout();
            this.boxPersonajes.SuspendLayout();
            this.lblTurno.SuspendLayout();
            this.groupPersonajeSeleccionadoInfoDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonajeDerecho)).BeginInit();
            this.groupPersonajeSeleccionadoInfoIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonajeIzquierdo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabIniciarJuego
            // 
            this.tabIniciarJuego.Controls.Add(this.tabPageCrearPartida);
            this.tabIniciarJuego.Controls.Add(this.tabPageUnirsePartida);
            this.tabIniciarJuego.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabIniciarJuego.Location = new System.Drawing.Point(222, 26);
            this.tabIniciarJuego.Name = "tabIniciarJuego";
            this.tabIniciarJuego.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabIniciarJuego.SelectedIndex = 0;
            this.tabIniciarJuego.Size = new System.Drawing.Size(521, 339);
            this.tabIniciarJuego.TabIndex = 0;
            // 
            // tabPageCrearPartida
            // 
            this.tabPageCrearPartida.Controls.Add(this.lblIPPartida);
            this.tabPageCrearPartida.Controls.Add(this.btnIniciarPartida);
            this.tabPageCrearPartida.Controls.Add(this.lblPartidaIP);
            this.tabPageCrearPartida.Controls.Add(this.boxTablero);
            this.tabPageCrearPartida.Location = new System.Drawing.Point(4, 22);
            this.tabPageCrearPartida.Name = "tabPageCrearPartida";
            this.tabPageCrearPartida.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCrearPartida.Size = new System.Drawing.Size(513, 313);
            this.tabPageCrearPartida.TabIndex = 0;
            this.tabPageCrearPartida.Text = "Crear Partida";
            this.tabPageCrearPartida.UseVisualStyleBackColor = true;
            // 
            // lblIPPartida
            // 
            this.lblIPPartida.AutoSize = true;
            this.lblIPPartida.Location = new System.Drawing.Point(251, 269);
            this.lblIPPartida.Name = "lblIPPartida";
            this.lblIPPartida.Size = new System.Drawing.Size(17, 13);
            this.lblIPPartida.TabIndex = 5;
            this.lblIPPartida.Text = "IP";
            // 
            // btnIniciarPartida
            // 
            this.btnIniciarPartida.Location = new System.Drawing.Point(347, 269);
            this.btnIniciarPartida.Name = "btnIniciarPartida";
            this.btnIniciarPartida.Size = new System.Drawing.Size(154, 24);
            this.btnIniciarPartida.TabIndex = 2;
            this.btnIniciarPartida.Text = "Iniciar partida";
            this.btnIniciarPartida.UseVisualStyleBackColor = true;
            this.btnIniciarPartida.Click += new System.EventHandler(this.btnIniciarPartida_Click);
            // 
            // lblPartidaIP
            // 
            this.lblPartidaIP.AutoSize = true;
            this.lblPartidaIP.Location = new System.Drawing.Point(164, 269);
            this.lblPartidaIP.Name = "lblPartidaIP";
            this.lblPartidaIP.Size = new System.Drawing.Size(81, 13);
            this.lblPartidaIP.TabIndex = 4;
            this.lblPartidaIP.Text = "IP de la partida:";
            // 
            // boxTablero
            // 
            this.boxTablero.Controls.Add(this.picImagenTablero);
            this.boxTablero.Controls.Add(this.lstListaTableros);
            this.boxTablero.Location = new System.Drawing.Point(9, 23);
            this.boxTablero.Name = "boxTablero";
            this.boxTablero.Size = new System.Drawing.Size(492, 243);
            this.boxTablero.TabIndex = 1;
            this.boxTablero.TabStop = false;
            this.boxTablero.Text = "Escoja el tablero";
            // 
            // picImagenTablero
            // 
            this.picImagenTablero.Location = new System.Drawing.Point(149, 19);
            this.picImagenTablero.Name = "picImagenTablero";
            this.picImagenTablero.Size = new System.Drawing.Size(326, 201);
            this.picImagenTablero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagenTablero.TabIndex = 1;
            this.picImagenTablero.TabStop = false;
            // 
            // lstListaTableros
            // 
            this.lstListaTableros.FormattingEnabled = true;
            this.lstListaTableros.Location = new System.Drawing.Point(15, 19);
            this.lstListaTableros.Name = "lstListaTableros";
            this.lstListaTableros.Size = new System.Drawing.Size(128, 199);
            this.lstListaTableros.TabIndex = 0;
            this.lstListaTableros.SelectedIndexChanged += new System.EventHandler(this.lstListaTableros_SelectedIndexChanged);
            // 
            // tabPageUnirsePartida
            // 
            this.tabPageUnirsePartida.Controls.Add(this.boxUnirsePartida);
            this.tabPageUnirsePartida.Location = new System.Drawing.Point(4, 22);
            this.tabPageUnirsePartida.Name = "tabPageUnirsePartida";
            this.tabPageUnirsePartida.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUnirsePartida.Size = new System.Drawing.Size(513, 313);
            this.tabPageUnirsePartida.TabIndex = 1;
            this.tabPageUnirsePartida.Text = "Unirse a partida";
            this.tabPageUnirsePartida.UseVisualStyleBackColor = true;
            // 
            // boxUnirsePartida
            // 
            this.boxUnirsePartida.Controls.Add(this.txtDireccionIP);
            this.boxUnirsePartida.Controls.Add(this.btnUnirsePartida);
            this.boxUnirsePartida.Controls.Add(this.lblDireccionIP);
            this.boxUnirsePartida.Location = new System.Drawing.Point(118, 93);
            this.boxUnirsePartida.Name = "boxUnirsePartida";
            this.boxUnirsePartida.Size = new System.Drawing.Size(287, 83);
            this.boxUnirsePartida.TabIndex = 2;
            this.boxUnirsePartida.TabStop = false;
            this.boxUnirsePartida.Text = "Unirse a partida";
            // 
            // txtDireccionIP
            // 
            this.txtDireccionIP.Location = new System.Drawing.Point(9, 32);
            this.txtDireccionIP.Name = "txtDireccionIP";
            this.txtDireccionIP.Size = new System.Drawing.Size(150, 20);
            this.txtDireccionIP.TabIndex = 0;
            this.txtDireccionIP.Text = "localhost";
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.Location = new System.Drawing.Point(165, 29);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(104, 24);
            this.btnUnirsePartida.TabIndex = 1;
            this.btnUnirsePartida.Text = "Unirse a la partida";
            this.btnUnirsePartida.UseVisualStyleBackColor = true;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // lblDireccionIP
            // 
            this.lblDireccionIP.AutoSize = true;
            this.lblDireccionIP.Location = new System.Drawing.Point(6, 16);
            this.lblDireccionIP.Name = "lblDireccionIP";
            this.lblDireccionIP.Size = new System.Drawing.Size(126, 13);
            this.lblDireccionIP.TabIndex = 3;
            this.lblDireccionIP.Text = "Direccion IP de la partida";
            // 
            // boxPersonajes
            // 
            this.boxPersonajes.BackColor = System.Drawing.Color.White;
            this.boxPersonajes.Controls.Add(this.lblPersonajes);
            this.boxPersonajes.Controls.Add(this.lblPersonaje_5);
            this.boxPersonajes.Controls.Add(this.lblPersonaje_4);
            this.boxPersonajes.Controls.Add(this.lblPersonaje_3);
            this.boxPersonajes.Controls.Add(this.lblPersonaje_2);
            this.boxPersonajes.Controls.Add(this.lblPersonaje_1);
            this.boxPersonajes.Controls.Add(this.cmbPersonaje_5);
            this.boxPersonajes.Controls.Add(this.cmbPersonaje_4);
            this.boxPersonajes.Controls.Add(this.cmbPersonaje_3);
            this.boxPersonajes.Controls.Add(this.cmbPersonaje_2);
            this.boxPersonajes.Controls.Add(this.cmbPersonaje_1);
            this.boxPersonajes.Location = new System.Drawing.Point(12, 26);
            this.boxPersonajes.Name = "boxPersonajes";
            this.boxPersonajes.Size = new System.Drawing.Size(204, 339);
            this.boxPersonajes.TabIndex = 0;
            this.boxPersonajes.TabStop = false;
            this.boxPersonajes.Text = "Escoja los Personajes";
            // 
            // lblPersonajes
            // 
            this.lblPersonajes.AutoSize = true;
            this.lblPersonajes.Location = new System.Drawing.Point(12, 23);
            this.lblPersonajes.Name = "lblPersonajes";
            this.lblPersonajes.Size = new System.Drawing.Size(189, 39);
            this.lblPersonajes.TabIndex = 10;
            this.lblPersonajes.Text = "Escoja un tipo de personaje para cada\r\nuno de los 5 guerreros con los que\r\nva a j" +
    "ugar.";
            // 
            // lblPersonaje_5
            // 
            this.lblPersonaje_5.AutoSize = true;
            this.lblPersonaje_5.Location = new System.Drawing.Point(8, 185);
            this.lblPersonaje_5.Name = "lblPersonaje_5";
            this.lblPersonaje_5.Size = new System.Drawing.Size(13, 13);
            this.lblPersonaje_5.TabIndex = 9;
            this.lblPersonaje_5.Text = "5";
            // 
            // lblPersonaje_4
            // 
            this.lblPersonaje_4.AutoSize = true;
            this.lblPersonaje_4.Location = new System.Drawing.Point(8, 158);
            this.lblPersonaje_4.Name = "lblPersonaje_4";
            this.lblPersonaje_4.Size = new System.Drawing.Size(13, 13);
            this.lblPersonaje_4.TabIndex = 8;
            this.lblPersonaje_4.Text = "4";
            // 
            // lblPersonaje_3
            // 
            this.lblPersonaje_3.AutoSize = true;
            this.lblPersonaje_3.Location = new System.Drawing.Point(8, 131);
            this.lblPersonaje_3.Name = "lblPersonaje_3";
            this.lblPersonaje_3.Size = new System.Drawing.Size(13, 13);
            this.lblPersonaje_3.TabIndex = 7;
            this.lblPersonaje_3.Text = "3";
            // 
            // lblPersonaje_2
            // 
            this.lblPersonaje_2.AutoSize = true;
            this.lblPersonaje_2.Location = new System.Drawing.Point(8, 104);
            this.lblPersonaje_2.Name = "lblPersonaje_2";
            this.lblPersonaje_2.Size = new System.Drawing.Size(13, 13);
            this.lblPersonaje_2.TabIndex = 6;
            this.lblPersonaje_2.Text = "2";
            // 
            // lblPersonaje_1
            // 
            this.lblPersonaje_1.AutoSize = true;
            this.lblPersonaje_1.Location = new System.Drawing.Point(8, 77);
            this.lblPersonaje_1.Name = "lblPersonaje_1";
            this.lblPersonaje_1.Size = new System.Drawing.Size(13, 13);
            this.lblPersonaje_1.TabIndex = 5;
            this.lblPersonaje_1.Text = "1";
            // 
            // cmbPersonaje_5
            // 
            this.cmbPersonaje_5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje_5.FormattingEnabled = true;
            this.cmbPersonaje_5.Location = new System.Drawing.Point(27, 182);
            this.cmbPersonaje_5.Name = "cmbPersonaje_5";
            this.cmbPersonaje_5.Size = new System.Drawing.Size(138, 21);
            this.cmbPersonaje_5.TabIndex = 4;
            // 
            // cmbPersonaje_4
            // 
            this.cmbPersonaje_4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje_4.FormattingEnabled = true;
            this.cmbPersonaje_4.Location = new System.Drawing.Point(27, 155);
            this.cmbPersonaje_4.Name = "cmbPersonaje_4";
            this.cmbPersonaje_4.Size = new System.Drawing.Size(138, 21);
            this.cmbPersonaje_4.TabIndex = 3;
            // 
            // cmbPersonaje_3
            // 
            this.cmbPersonaje_3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje_3.FormattingEnabled = true;
            this.cmbPersonaje_3.Location = new System.Drawing.Point(27, 128);
            this.cmbPersonaje_3.Name = "cmbPersonaje_3";
            this.cmbPersonaje_3.Size = new System.Drawing.Size(138, 21);
            this.cmbPersonaje_3.TabIndex = 2;
            // 
            // cmbPersonaje_2
            // 
            this.cmbPersonaje_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje_2.FormattingEnabled = true;
            this.cmbPersonaje_2.Location = new System.Drawing.Point(27, 101);
            this.cmbPersonaje_2.Name = "cmbPersonaje_2";
            this.cmbPersonaje_2.Size = new System.Drawing.Size(138, 21);
            this.cmbPersonaje_2.TabIndex = 1;
            // 
            // cmbPersonaje_1
            // 
            this.cmbPersonaje_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonaje_1.FormattingEnabled = true;
            this.cmbPersonaje_1.Location = new System.Drawing.Point(27, 74);
            this.cmbPersonaje_1.Name = "cmbPersonaje_1";
            this.cmbPersonaje_1.Size = new System.Drawing.Size(138, 21);
            this.cmbPersonaje_1.TabIndex = 0;
            // 
            // lblTurno
            // 
            this.lblTurno.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblTurno.BackgroundImage")));
            this.lblTurno.Controls.Add(this.groupPersonajeSeleccionadoInfoDerecho);
            this.lblTurno.Controls.Add(this.groupPersonajeSeleccionadoInfoIzquierdo);
            this.lblTurno.Location = new System.Drawing.Point(1, 490);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(800, 100);
            this.lblTurno.TabIndex = 0;
            this.lblTurno.TabStop = false;
            // 
            // groupPersonajeSeleccionadoInfoDerecho
            // 
            this.groupPersonajeSeleccionadoInfoDerecho.BackColor = System.Drawing.Color.Transparent;
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.BarraSaludPersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.lblVelocidadPersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.lblDefensaPersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.lblAtaquePersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.lblSaludPersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.lblNombrePersonjeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Controls.Add(this.picPersonajeDerecho);
            this.groupPersonajeSeleccionadoInfoDerecho.Location = new System.Drawing.Point(406, 22);
            this.groupPersonajeSeleccionadoInfoDerecho.Name = "groupPersonajeSeleccionadoInfoDerecho";
            this.groupPersonajeSeleccionadoInfoDerecho.Size = new System.Drawing.Size(336, 72);
            this.groupPersonajeSeleccionadoInfoDerecho.TabIndex = 6;
            this.groupPersonajeSeleccionadoInfoDerecho.TabStop = false;
            this.groupPersonajeSeleccionadoInfoDerecho.Text = "Personaje Info";
            this.groupPersonajeSeleccionadoInfoDerecho.Visible = false;
            // 
            // BarraSaludPersonajeDerecho
            // 
            this.BarraSaludPersonajeDerecho.BackColor = System.Drawing.Color.Black;
            this.BarraSaludPersonajeDerecho.ForeColor = System.Drawing.Color.Green;
            this.BarraSaludPersonajeDerecho.Location = new System.Drawing.Point(74, 56);
            this.BarraSaludPersonajeDerecho.Name = "BarraSaludPersonajeDerecho";
            this.BarraSaludPersonajeDerecho.Size = new System.Drawing.Size(81, 10);
            this.BarraSaludPersonajeDerecho.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BarraSaludPersonajeDerecho.TabIndex = 1;
            this.BarraSaludPersonajeDerecho.Value = 50;
            // 
            // lblVelocidadPersonajeDerecho
            // 
            this.lblVelocidadPersonajeDerecho.AutoSize = true;
            this.lblVelocidadPersonajeDerecho.Location = new System.Drawing.Point(191, 42);
            this.lblVelocidadPersonajeDerecho.Name = "lblVelocidadPersonajeDerecho";
            this.lblVelocidadPersonajeDerecho.Size = new System.Drawing.Size(69, 13);
            this.lblVelocidadPersonajeDerecho.TabIndex = 5;
            this.lblVelocidadPersonajeDerecho.Text = "Velocidad: ...";
            // 
            // lblDefensaPersonajeDerecho
            // 
            this.lblDefensaPersonajeDerecho.AutoSize = true;
            this.lblDefensaPersonajeDerecho.Location = new System.Drawing.Point(191, 25);
            this.lblDefensaPersonajeDerecho.Name = "lblDefensaPersonajeDerecho";
            this.lblDefensaPersonajeDerecho.Size = new System.Drawing.Size(62, 13);
            this.lblDefensaPersonajeDerecho.TabIndex = 4;
            this.lblDefensaPersonajeDerecho.Text = "Defensa: ...";
            // 
            // lblAtaquePersonajeDerecho
            // 
            this.lblAtaquePersonajeDerecho.AutoSize = true;
            this.lblAtaquePersonajeDerecho.Location = new System.Drawing.Point(191, 9);
            this.lblAtaquePersonajeDerecho.Name = "lblAtaquePersonajeDerecho";
            this.lblAtaquePersonajeDerecho.Size = new System.Drawing.Size(56, 13);
            this.lblAtaquePersonajeDerecho.TabIndex = 3;
            this.lblAtaquePersonajeDerecho.Text = "Ataque: ...";
            // 
            // lblSaludPersonajeDerecho
            // 
            this.lblSaludPersonajeDerecho.AutoSize = true;
            this.lblSaludPersonajeDerecho.Location = new System.Drawing.Point(71, 42);
            this.lblSaludPersonajeDerecho.Name = "lblSaludPersonajeDerecho";
            this.lblSaludPersonajeDerecho.Size = new System.Drawing.Size(63, 13);
            this.lblSaludPersonajeDerecho.TabIndex = 2;
            this.lblSaludPersonajeDerecho.Text = "Salud: .../...";
            // 
            // lblNombrePersonjeDerecho
            // 
            this.lblNombrePersonjeDerecho.AutoSize = true;
            this.lblNombrePersonjeDerecho.Location = new System.Drawing.Point(71, 16);
            this.lblNombrePersonjeDerecho.Name = "lblNombrePersonjeDerecho";
            this.lblNombrePersonjeDerecho.Size = new System.Drawing.Size(59, 13);
            this.lblNombrePersonjeDerecho.TabIndex = 1;
            this.lblNombrePersonjeDerecho.Text = "Nombre: ...";
            // 
            // picPersonajeDerecho
            // 
            this.picPersonajeDerecho.Location = new System.Drawing.Point(6, 16);
            this.picPersonajeDerecho.Name = "picPersonajeDerecho";
            this.picPersonajeDerecho.Size = new System.Drawing.Size(59, 52);
            this.picPersonajeDerecho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPersonajeDerecho.TabIndex = 0;
            this.picPersonajeDerecho.TabStop = false;
            // 
            // groupPersonajeSeleccionadoInfoIzquierdo
            // 
            this.groupPersonajeSeleccionadoInfoIzquierdo.BackColor = System.Drawing.Color.Transparent;
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.BarraSaludPersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.lblVelocidadPersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.lblDefensaPersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.lblAtaquePersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.lblSaludPersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.lblNombrePersonjeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Controls.Add(this.picPersonajeIzquierdo);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Location = new System.Drawing.Point(6, 22);
            this.groupPersonajeSeleccionadoInfoIzquierdo.Name = "groupPersonajeSeleccionadoInfoIzquierdo";
            this.groupPersonajeSeleccionadoInfoIzquierdo.Size = new System.Drawing.Size(336, 72);
            this.groupPersonajeSeleccionadoInfoIzquierdo.TabIndex = 1;
            this.groupPersonajeSeleccionadoInfoIzquierdo.TabStop = false;
            this.groupPersonajeSeleccionadoInfoIzquierdo.Text = "Personaje Info";
            this.groupPersonajeSeleccionadoInfoIzquierdo.Visible = false;
            // 
            // BarraSaludPersonajeIzquierdo
            // 
            this.BarraSaludPersonajeIzquierdo.BackColor = System.Drawing.Color.Black;
            this.BarraSaludPersonajeIzquierdo.ForeColor = System.Drawing.Color.Green;
            this.BarraSaludPersonajeIzquierdo.Location = new System.Drawing.Point(74, 56);
            this.BarraSaludPersonajeIzquierdo.Name = "BarraSaludPersonajeIzquierdo";
            this.BarraSaludPersonajeIzquierdo.Size = new System.Drawing.Size(81, 10);
            this.BarraSaludPersonajeIzquierdo.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BarraSaludPersonajeIzquierdo.TabIndex = 1;
            this.BarraSaludPersonajeIzquierdo.Value = 50;
            // 
            // lblVelocidadPersonajeIzquierdo
            // 
            this.lblVelocidadPersonajeIzquierdo.AutoSize = true;
            this.lblVelocidadPersonajeIzquierdo.Location = new System.Drawing.Point(191, 42);
            this.lblVelocidadPersonajeIzquierdo.Name = "lblVelocidadPersonajeIzquierdo";
            this.lblVelocidadPersonajeIzquierdo.Size = new System.Drawing.Size(69, 13);
            this.lblVelocidadPersonajeIzquierdo.TabIndex = 5;
            this.lblVelocidadPersonajeIzquierdo.Text = "Velocidad: ...";
            // 
            // lblDefensaPersonajeIzquierdo
            // 
            this.lblDefensaPersonajeIzquierdo.AutoSize = true;
            this.lblDefensaPersonajeIzquierdo.Location = new System.Drawing.Point(191, 25);
            this.lblDefensaPersonajeIzquierdo.Name = "lblDefensaPersonajeIzquierdo";
            this.lblDefensaPersonajeIzquierdo.Size = new System.Drawing.Size(62, 13);
            this.lblDefensaPersonajeIzquierdo.TabIndex = 4;
            this.lblDefensaPersonajeIzquierdo.Text = "Defensa: ...";
            // 
            // lblAtaquePersonajeIzquierdo
            // 
            this.lblAtaquePersonajeIzquierdo.AutoSize = true;
            this.lblAtaquePersonajeIzquierdo.Location = new System.Drawing.Point(191, 9);
            this.lblAtaquePersonajeIzquierdo.Name = "lblAtaquePersonajeIzquierdo";
            this.lblAtaquePersonajeIzquierdo.Size = new System.Drawing.Size(56, 13);
            this.lblAtaquePersonajeIzquierdo.TabIndex = 3;
            this.lblAtaquePersonajeIzquierdo.Text = "Ataque: ...";
            // 
            // lblSaludPersonajeIzquierdo
            // 
            this.lblSaludPersonajeIzquierdo.AutoSize = true;
            this.lblSaludPersonajeIzquierdo.Location = new System.Drawing.Point(71, 42);
            this.lblSaludPersonajeIzquierdo.Name = "lblSaludPersonajeIzquierdo";
            this.lblSaludPersonajeIzquierdo.Size = new System.Drawing.Size(63, 13);
            this.lblSaludPersonajeIzquierdo.TabIndex = 2;
            this.lblSaludPersonajeIzquierdo.Text = "Salud: .../...";
            // 
            // lblNombrePersonjeIzquierdo
            // 
            this.lblNombrePersonjeIzquierdo.AutoSize = true;
            this.lblNombrePersonjeIzquierdo.Location = new System.Drawing.Point(71, 16);
            this.lblNombrePersonjeIzquierdo.Name = "lblNombrePersonjeIzquierdo";
            this.lblNombrePersonjeIzquierdo.Size = new System.Drawing.Size(59, 13);
            this.lblNombrePersonjeIzquierdo.TabIndex = 1;
            this.lblNombrePersonjeIzquierdo.Text = "Nombre: ...";
            // 
            // picPersonajeIzquierdo
            // 
            this.picPersonajeIzquierdo.Location = new System.Drawing.Point(6, 16);
            this.picPersonajeIzquierdo.Name = "picPersonajeIzquierdo";
            this.picPersonajeIzquierdo.Size = new System.Drawing.Size(59, 52);
            this.picPersonajeIzquierdo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPersonajeIzquierdo.TabIndex = 0;
            this.picPersonajeIzquierdo.TabStop = false;
            // 
            // timerPersonajeSeleccionado
            // 
            this.timerPersonajeSeleccionado.Interval = 500;
            this.timerPersonajeSeleccionado.Tick += new System.EventHandler(this.timerPersonajeSeleccionado_Tick);
            // 
            // lblTiempoRestanteizq
            // 
            this.lblTiempoRestanteizq.AutoSize = true;
            this.lblTiempoRestanteizq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTiempoRestanteizq.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoRestanteizq.Location = new System.Drawing.Point(48, 408);
            this.lblTiempoRestanteizq.Name = "lblTiempoRestanteizq";
            this.lblTiempoRestanteizq.Size = new System.Drawing.Size(189, 30);
            this.lblTiempoRestanteizq.TabIndex = 1;
            this.lblTiempoRestanteizq.Text = "Tiempo restante:";
            this.lblTiempoRestanteizq.Visible = false;
            // 
            // lblTiempoRestanteDer
            // 
            this.lblTiempoRestanteDer.AutoSize = true;
            this.lblTiempoRestanteDer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTiempoRestanteDer.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempoRestanteDer.Location = new System.Drawing.Point(478, 408);
            this.lblTiempoRestanteDer.Name = "lblTiempoRestanteDer";
            this.lblTiempoRestanteDer.Size = new System.Drawing.Size(189, 30);
            this.lblTiempoRestanteDer.TabIndex = 2;
            this.lblTiempoRestanteDer.Text = "Tiempo restante:";
            this.lblTiempoRestanteDer.Visible = false;
            // 
            // lblDañoIzq
            // 
            this.lblDañoIzq.AutoSize = true;
            this.lblDañoIzq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDañoIzq.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDañoIzq.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDañoIzq.Location = new System.Drawing.Point(10, 368);
            this.lblDañoIzq.Name = "lblDañoIzq";
            this.lblDañoIzq.Size = new System.Drawing.Size(62, 38);
            this.lblDañoIzq.TabIndex = 3;
            this.lblDañoIzq.Text = "+00";
            this.lblDañoIzq.Visible = false;
            // 
            // lblDañoDer
            // 
            this.lblDañoDer.AutoSize = true;
            this.lblDañoDer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblDañoDer.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDañoDer.ForeColor = System.Drawing.Color.DarkRed;
            this.lblDañoDer.Location = new System.Drawing.Point(677, 368);
            this.lblDañoDer.Name = "lblDañoDer";
            this.lblDañoDer.Size = new System.Drawing.Size(62, 38);
            this.lblDañoDer.TabIndex = 4;
            this.lblDañoDer.Text = "+00";
            this.lblDañoDer.Visible = false;
            // 
            // timerModoBatallaCompleto
            // 
            this.timerModoBatallaCompleto.Interval = 50;
            this.timerModoBatallaCompleto.Tick += new System.EventHandler(this.timerModoBatallaCompleto_Tick);
            // 
            // timerAtq
            // 
            this.timerAtq.Interval = 200;
            this.timerAtq.Tick += new System.EventHandler(this.timerAtq_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(752, 591);
            this.Controls.Add(this.lblDañoDer);
            this.Controls.Add(this.lblDañoIzq);
            this.Controls.Add(this.lblTiempoRestanteDer);
            this.Controls.Add(this.lblTiempoRestanteizq);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.tabIniciarJuego);
            this.Controls.Add(this.boxPersonajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Fire Warriors";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.tabIniciarJuego.ResumeLayout(false);
            this.tabPageCrearPartida.ResumeLayout(false);
            this.tabPageCrearPartida.PerformLayout();
            this.boxTablero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImagenTablero)).EndInit();
            this.tabPageUnirsePartida.ResumeLayout(false);
            this.boxUnirsePartida.ResumeLayout(false);
            this.boxUnirsePartida.PerformLayout();
            this.boxPersonajes.ResumeLayout(false);
            this.boxPersonajes.PerformLayout();
            this.lblTurno.ResumeLayout(false);
            this.groupPersonajeSeleccionadoInfoDerecho.ResumeLayout(false);
            this.groupPersonajeSeleccionadoInfoDerecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonajeDerecho)).EndInit();
            this.groupPersonajeSeleccionadoInfoIzquierdo.ResumeLayout(false);
            this.groupPersonajeSeleccionadoInfoIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPersonajeIzquierdo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabIniciarJuego;
        private System.Windows.Forms.TabPage tabPageCrearPartida;
        private System.Windows.Forms.TabPage tabPageUnirsePartida;
        private System.Windows.Forms.GroupBox boxPersonajes;
        private System.Windows.Forms.GroupBox boxTablero;
        private System.Windows.Forms.ComboBox cmbPersonaje_1;
        private System.Windows.Forms.ComboBox cmbPersonaje_2;
        private System.Windows.Forms.ComboBox cmbPersonaje_5;
        private System.Windows.Forms.ComboBox cmbPersonaje_4;
        private System.Windows.Forms.ComboBox cmbPersonaje_3;
        private System.Windows.Forms.Label lblPersonaje_3;
        private System.Windows.Forms.Label lblPersonaje_2;
        private System.Windows.Forms.Label lblPersonaje_1;
        private System.Windows.Forms.Label lblPersonaje_5;
        private System.Windows.Forms.Label lblPersonaje_4;
        private System.Windows.Forms.ListBox lstListaTableros;
        private System.Windows.Forms.PictureBox picImagenTablero;
        private System.Windows.Forms.Button btnUnirsePartida;
        private System.Windows.Forms.GroupBox boxUnirsePartida;
        private System.Windows.Forms.TextBox txtDireccionIP;
        private System.Windows.Forms.Label lblDireccionIP;
        private System.Windows.Forms.Label lblPartidaIP;
        private System.Windows.Forms.Label lblIPPartida;
        private System.Windows.Forms.GroupBox lblTurno;
        private System.Windows.Forms.Timer timerPersonajeSeleccionado;
        private System.Windows.Forms.Label lblTiempoRestanteizq;
        private System.Windows.Forms.Label lblTiempoRestanteDer;
        private System.Windows.Forms.Label lblDañoIzq;
        private System.Windows.Forms.Label lblDañoDer;
        internal System.Windows.Forms.GroupBox groupPersonajeSeleccionadoInfoIzquierdo;
        internal System.Windows.Forms.PictureBox picPersonajeIzquierdo;
        internal System.Windows.Forms.Label lblNombrePersonjeIzquierdo;
        internal System.Windows.Forms.Label lblSaludPersonajeIzquierdo;
        internal System.Windows.Forms.Label lblAtaquePersonajeIzquierdo;
        internal System.Windows.Forms.Label lblVelocidadPersonajeIzquierdo;
        internal System.Windows.Forms.Label lblDefensaPersonajeIzquierdo;
        internal System.Windows.Forms.ProgressBar BarraSaludPersonajeIzquierdo;
        internal System.Windows.Forms.GroupBox groupPersonajeSeleccionadoInfoDerecho;
        internal System.Windows.Forms.ProgressBar BarraSaludPersonajeDerecho;
        internal System.Windows.Forms.Label lblVelocidadPersonajeDerecho;
        internal System.Windows.Forms.Label lblDefensaPersonajeDerecho;
        internal System.Windows.Forms.Label lblAtaquePersonajeDerecho;
        internal System.Windows.Forms.Label lblSaludPersonajeDerecho;
        internal System.Windows.Forms.Label lblNombrePersonjeDerecho;
        internal System.Windows.Forms.PictureBox picPersonajeDerecho;
        internal System.Windows.Forms.Timer timerModoBatallaCompleto;
        private System.Windows.Forms.Timer timerAtq;
        internal System.Windows.Forms.Button btnIniciarPartida;
        private System.Windows.Forms.Label lblPersonajes;
    }
}

