namespace Menu_01_practica41
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            cargarImagenToolStripMenuItem = new ToolStripMenuItem();
            guardarImagenToolStripMenuItem = new ToolStripMenuItem();
            guardarImagenToolStripMenuItem1 = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            preprocesamientoToolStripMenuItem = new ToolStripMenuItem();
            negativoToolStripMenuItem = new ToolStripMenuItem();
            grisesToolStripMenuItem = new ToolStripMenuItem();
            filtrosColoresToolStripMenuItem = new ToolStripMenuItem();
            filtroRojoToolStripMenuItem = new ToolStripMenuItem();
            filtroVerdeToolStripMenuItem = new ToolStripMenuItem();
            filtroAzulToolStripMenuItem = new ToolStripMenuItem();
            colorearImagenToolStripMenuItem = new ToolStripMenuItem();
            filtrosToolStripMenuItem = new ToolStripMenuItem();
            pasoBajasToolStripMenuItem = new ToolStripMenuItem();
            gaussToolStripMenuItem = new ToolStripMenuItem();
            kmeansToolStripMenuItem = new ToolStripMenuItem();
            mediaPonderadaToolStripMenuItem = new ToolStripMenuItem();
            pasoMediasToolStripMenuItem = new ToolStripMenuItem();
            pasoAltasToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(140, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(524, 311);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cargarImagenToolStripMenuItem, preprocesamientoToolStripMenuItem, filtrosColoresToolStripMenuItem, filtrosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cargarImagenToolStripMenuItem
            // 
            cargarImagenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { guardarImagenToolStripMenuItem, guardarImagenToolStripMenuItem1, salirToolStripMenuItem });
            cargarImagenToolStripMenuItem.Name = "cargarImagenToolStripMenuItem";
            cargarImagenToolStripMenuItem.Size = new Size(73, 24);
            cargarImagenToolStripMenuItem.Text = "Archivo";
            // 
            // guardarImagenToolStripMenuItem
            // 
            guardarImagenToolStripMenuItem.Name = "guardarImagenToolStripMenuItem";
            guardarImagenToolStripMenuItem.Size = new Size(199, 26);
            guardarImagenToolStripMenuItem.Text = "Cargar Imagen";
            guardarImagenToolStripMenuItem.Click += guardarImagenToolStripMenuItem_Click;
            // 
            // guardarImagenToolStripMenuItem1
            // 
            guardarImagenToolStripMenuItem1.Name = "guardarImagenToolStripMenuItem1";
            guardarImagenToolStripMenuItem1.Size = new Size(199, 26);
            guardarImagenToolStripMenuItem1.Text = "Guardar imagen";
            guardarImagenToolStripMenuItem1.Click += guardarImagenToolStripMenuItem1_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(199, 26);
            salirToolStripMenuItem.Text = "Salir";
            // 
            // preprocesamientoToolStripMenuItem
            // 
            preprocesamientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { negativoToolStripMenuItem, grisesToolStripMenuItem });
            preprocesamientoToolStripMenuItem.Name = "preprocesamientoToolStripMenuItem";
            preprocesamientoToolStripMenuItem.Size = new Size(143, 24);
            preprocesamientoToolStripMenuItem.Text = "Preprocesamiento";
            // 
            // negativoToolStripMenuItem
            // 
            negativoToolStripMenuItem.Name = "negativoToolStripMenuItem";
            negativoToolStripMenuItem.Size = new Size(153, 26);
            negativoToolStripMenuItem.Text = "Negativo";
            negativoToolStripMenuItem.Click += negativoToolStripMenuItem_Click;
            // 
            // grisesToolStripMenuItem
            // 
            grisesToolStripMenuItem.Name = "grisesToolStripMenuItem";
            grisesToolStripMenuItem.Size = new Size(153, 26);
            grisesToolStripMenuItem.Text = "Grises";
            grisesToolStripMenuItem.Click += grisesToolStripMenuItem_Click;
            // 
            // filtrosColoresToolStripMenuItem
            // 
            filtrosColoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filtroRojoToolStripMenuItem, filtroVerdeToolStripMenuItem, filtroAzulToolStripMenuItem, colorearImagenToolStripMenuItem });
            filtrosColoresToolStripMenuItem.Name = "filtrosColoresToolStripMenuItem";
            filtrosColoresToolStripMenuItem.Size = new Size(117, 24);
            filtrosColoresToolStripMenuItem.Text = "Filtros Colores";
            // 
            // filtroRojoToolStripMenuItem
            // 
            filtroRojoToolStripMenuItem.Name = "filtroRojoToolStripMenuItem";
            filtroRojoToolStripMenuItem.Size = new Size(203, 26);
            filtroRojoToolStripMenuItem.Text = "Filtro Rojo";
            filtroRojoToolStripMenuItem.Click += filtroRojoToolStripMenuItem_Click;
            // 
            // filtroVerdeToolStripMenuItem
            // 
            filtroVerdeToolStripMenuItem.Name = "filtroVerdeToolStripMenuItem";
            filtroVerdeToolStripMenuItem.Size = new Size(203, 26);
            filtroVerdeToolStripMenuItem.Text = "Filtro Verde";
            filtroVerdeToolStripMenuItem.Click += filtroVerdeToolStripMenuItem_Click;
            // 
            // filtroAzulToolStripMenuItem
            // 
            filtroAzulToolStripMenuItem.Name = "filtroAzulToolStripMenuItem";
            filtroAzulToolStripMenuItem.Size = new Size(203, 26);
            filtroAzulToolStripMenuItem.Text = "Filtro Azul";
            filtroAzulToolStripMenuItem.Click += filtroAzulToolStripMenuItem_Click;
            // 
            // colorearImagenToolStripMenuItem
            // 
            colorearImagenToolStripMenuItem.Name = "colorearImagenToolStripMenuItem";
            colorearImagenToolStripMenuItem.Size = new Size(203, 26);
            colorearImagenToolStripMenuItem.Text = "Colorear imagen";
            // 
            // filtrosToolStripMenuItem
            // 
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pasoBajasToolStripMenuItem, pasoMediasToolStripMenuItem, pasoAltasToolStripMenuItem });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(63, 24);
            filtrosToolStripMenuItem.Text = "Filtros";
            // 
            // pasoBajasToolStripMenuItem
            // 
            pasoBajasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gaussToolStripMenuItem, kmeansToolStripMenuItem, mediaPonderadaToolStripMenuItem });
            pasoBajasToolStripMenuItem.Name = "pasoBajasToolStripMenuItem";
            pasoBajasToolStripMenuItem.Size = new Size(224, 26);
            pasoBajasToolStripMenuItem.Text = "Paso Bajas";
            pasoBajasToolStripMenuItem.Click += pasoBajasToolStripMenuItem_Click;
            // 
            // gaussToolStripMenuItem
            // 
            gaussToolStripMenuItem.Name = "gaussToolStripMenuItem";
            gaussToolStripMenuItem.Size = new Size(224, 26);
            gaussToolStripMenuItem.Text = "Gauss";
            gaussToolStripMenuItem.Click += gaussToolStripMenuItem_Click;
            // 
            // kmeansToolStripMenuItem
            // 
            kmeansToolStripMenuItem.Name = "kmeansToolStripMenuItem";
            kmeansToolStripMenuItem.Size = new Size(224, 26);
            kmeansToolStripMenuItem.Text = "K vecino";
            kmeansToolStripMenuItem.Click += kmeansToolStripMenuItem_Click;
            // 
            // mediaPonderadaToolStripMenuItem
            // 
            mediaPonderadaToolStripMenuItem.Name = "mediaPonderadaToolStripMenuItem";
            mediaPonderadaToolStripMenuItem.Size = new Size(224, 26);
            mediaPonderadaToolStripMenuItem.Text = "Media Ponderada";
            // 
            // pasoMediasToolStripMenuItem
            // 
            pasoMediasToolStripMenuItem.Name = "pasoMediasToolStripMenuItem";
            pasoMediasToolStripMenuItem.Size = new Size(224, 26);
            pasoMediasToolStripMenuItem.Text = "Paso Medias";
            // 
            // pasoAltasToolStripMenuItem
            // 
            pasoAltasToolStripMenuItem.Name = "pasoAltasToolStripMenuItem";
            pasoAltasToolStripMenuItem.Size = new Size(224, 26);
            pasoAltasToolStripMenuItem.Text = "Paso Altas";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Menu01-practica41";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cargarImagenToolStripMenuItem;
        private ToolStripMenuItem guardarImagenToolStripMenuItem;
        private ToolStripMenuItem guardarImagenToolStripMenuItem1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem preprocesamientoToolStripMenuItem;
        private ToolStripMenuItem negativoToolStripMenuItem;
        private ToolStripMenuItem grisesToolStripMenuItem;
        private ToolStripMenuItem filtrosColoresToolStripMenuItem;
        private ToolStripMenuItem filtroRojoToolStripMenuItem;
        private ToolStripMenuItem filtroVerdeToolStripMenuItem;
        private ToolStripMenuItem filtroAzulToolStripMenuItem;
        private ToolStripMenuItem colorearImagenToolStripMenuItem;
        private ToolStripMenuItem filtrosToolStripMenuItem;
        private ToolStripMenuItem pasoBajasToolStripMenuItem;
        private ToolStripMenuItem pasoMediasToolStripMenuItem;
        private ToolStripMenuItem pasoAltasToolStripMenuItem;
        private ToolStripMenuItem gaussToolStripMenuItem;
        private ToolStripMenuItem kmeansToolStripMenuItem;
        private ToolStripMenuItem mediaPonderadaToolStripMenuItem;
    }
}
