namespace Ahorcado
{
    partial class MenuJugador
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuJugador));
            this.label1 = new System.Windows.Forms.Label();
            this.lbNombreUsuario = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelJugar = new System.Windows.Forms.Label();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPuntuacion = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FloralWhite;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 41);
            this.label1.TabIndex = 11;
            this.label1.Text = "Bienvenido/a";
            // 
            // lbNombreUsuario
            // 
            this.lbNombreUsuario.AutoSize = true;
            this.lbNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lbNombreUsuario.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbNombreUsuario.Location = new System.Drawing.Point(26, 77);
            this.lbNombreUsuario.Name = "lbNombreUsuario";
            this.lbNombreUsuario.Size = new System.Drawing.Size(107, 29);
            this.lbNombreUsuario.TabIndex = 10;
            this.lbNombreUsuario.Text = "Usuario";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(532, 629);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 56);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // labelJugar
            // 
            this.labelJugar.AutoSize = true;
            this.labelJugar.BackColor = System.Drawing.Color.Transparent;
            this.labelJugar.Font = new System.Drawing.Font("MV Boli", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJugar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelJugar.Location = new System.Drawing.Point(584, 629);
            this.labelJugar.Name = "labelJugar";
            this.labelJugar.Size = new System.Drawing.Size(113, 45);
            this.labelJugar.TabIndex = 14;
            this.labelJugar.Text = "Jugar";
            this.labelJugar.Click += new System.EventHandler(this.labelJugar_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(1148, 12);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(32, 35);
            this.pbExit.TabIndex = 28;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightBlue;
            this.label2.Location = new System.Drawing.Point(28, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 30;
            this.label2.Text = "Score";
            // 
            // lbPuntuacion
            // 
            this.lbPuntuacion.AutoSize = true;
            this.lbPuntuacion.BackColor = System.Drawing.Color.Transparent;
            this.lbPuntuacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuntuacion.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbPuntuacion.Location = new System.Drawing.Point(108, 117);
            this.lbPuntuacion.Name = "lbPuntuacion";
            this.lbPuntuacion.Size = new System.Drawing.Size(21, 24);
            this.lbPuntuacion.TabIndex = 37;
            this.lbPuntuacion.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("MV Boli", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(94, 629);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 45);
            this.label3.TabIndex = 38;
            this.label3.Text = "Puntuaciones";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(42, 618);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 56);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // MenuJugador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1188, 697);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbPuntuacion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.labelJugar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNombreUsuario);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuJugador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuJugador";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNombreUsuario;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelJugar;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPuntuacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}