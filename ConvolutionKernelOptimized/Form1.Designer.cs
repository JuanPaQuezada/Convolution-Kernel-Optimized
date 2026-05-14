namespace ConvolutionKernelOptimized
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
            abrirImagenToolStripMenuItem = new ToolStripMenuItem();
            guardarImagenToolStripMenuItem1 = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            preprocesamientoToolStripMenuItem = new ToolStripMenuItem();
            negativoToolStripMenuItem = new ToolStripMenuItem();
            grisesToolStripMenuItem = new ToolStripMenuItem();
            potenciaToolStripMenuItem = new ToolStripMenuItem();
            abrillantarToolStripMenuItem = new ToolStripMenuItem();
            oscurecerToolStripMenuItem = new ToolStripMenuItem();
            binarizacionToolStripMenuItem = new ToolStripMenuItem();
            filtrosColoresToolStripMenuItem = new ToolStripMenuItem();
            filtroRojoToolStripMenuItem = new ToolStripMenuItem();
            filtroVerdeToolStripMenuItem = new ToolStripMenuItem();
            filtroAzulToolStripMenuItem = new ToolStripMenuItem();
            colorearImagenToolStripMenuItem = new ToolStripMenuItem();
            filtrosToolStripMenuItem = new ToolStripMenuItem();
            pasoBajasToolStripMenuItem = new ToolStripMenuItem();
            gaussToolStripMenuItem = new ToolStripMenuItem();
            kvecinosToolStripMenuItem = new ToolStripMenuItem();
            mediaPonderadaToolStripMenuItem = new ToolStripMenuItem();
            pasoMediasToolStripMenuItem = new ToolStripMenuItem();
            x3ToolStripMenuItem = new ToolStripMenuItem();
            x5ToolStripMenuItem = new ToolStripMenuItem();
            x7ToolStripMenuItem = new ToolStripMenuItem();
            pasoAltasToolStripMenuItem = new ToolStripMenuItem();
            sobelToolStripMenuItem = new ToolStripMenuItem();
            bordesToolStripMenuItem = new ToolStripMenuItem();
            intensoToolStripMenuItem = new ToolStripMenuItem();
            histogramaToolStripMenuItem = new ToolStripMenuItem();
            histogramaDeColorToolStripMenuItem = new ToolStripMenuItem();
            histogramaDeColorAzulToolStripMenuItem = new ToolStripMenuItem();
            histogramaDeColorVerdeToolStripMenuItem = new ToolStripMenuItem();
            histogramaRGBToolStripMenuItem = new ToolStripMenuItem();
            bordesToolStripMenuItem1 = new ToolStripMenuItem();
            laplaceToolStripMenuItem = new ToolStripMenuItem();
            robertsToolStripMenuItem = new ToolStripMenuItem();
            prewittToolStripMenuItem = new ToolStripMenuItem();
            sobelToolStripMenuItem1 = new ToolStripMenuItem();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { cargarImagenToolStripMenuItem, preprocesamientoToolStripMenuItem, filtrosColoresToolStripMenuItem, filtrosToolStripMenuItem, histogramaToolStripMenuItem, bordesToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // cargarImagenToolStripMenuItem
            // 
            cargarImagenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirImagenToolStripMenuItem, guardarImagenToolStripMenuItem1, salirToolStripMenuItem });
            cargarImagenToolStripMenuItem.Name = "cargarImagenToolStripMenuItem";
            cargarImagenToolStripMenuItem.Size = new Size(73, 24);
            cargarImagenToolStripMenuItem.Text = "Archivo";
            // 
            // abrirImagenToolStripMenuItem
            // 
            abrirImagenToolStripMenuItem.Name = "abrirImagenToolStripMenuItem";
            abrirImagenToolStripMenuItem.Size = new Size(199, 26);
            abrirImagenToolStripMenuItem.Text = "Cargar Imagen";
            abrirImagenToolStripMenuItem.Click += abrirImagenToolStripMenuItem_Click;
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
            preprocesamientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { negativoToolStripMenuItem, grisesToolStripMenuItem, potenciaToolStripMenuItem, binarizacionToolStripMenuItem });
            preprocesamientoToolStripMenuItem.Name = "preprocesamientoToolStripMenuItem";
            preprocesamientoToolStripMenuItem.Size = new Size(143, 24);
            preprocesamientoToolStripMenuItem.Text = "Preprocesamiento";
            // 
            // negativoToolStripMenuItem
            // 
            negativoToolStripMenuItem.Name = "negativoToolStripMenuItem";
            negativoToolStripMenuItem.Size = new Size(173, 26);
            negativoToolStripMenuItem.Text = "Negativo";
            negativoToolStripMenuItem.Click += negativoToolStripMenuItem_Click;
            // 
            // grisesToolStripMenuItem
            // 
            grisesToolStripMenuItem.Name = "grisesToolStripMenuItem";
            grisesToolStripMenuItem.Size = new Size(173, 26);
            grisesToolStripMenuItem.Text = "Grises";
            grisesToolStripMenuItem.Click += grisesToolStripMenuItem_Click;
            // 
            // potenciaToolStripMenuItem
            // 
            potenciaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrillantarToolStripMenuItem, oscurecerToolStripMenuItem });
            potenciaToolStripMenuItem.Name = "potenciaToolStripMenuItem";
            potenciaToolStripMenuItem.Size = new Size(173, 26);
            potenciaToolStripMenuItem.Text = "Potencia";
            // 
            // abrillantarToolStripMenuItem
            // 
            abrillantarToolStripMenuItem.Name = "abrillantarToolStripMenuItem";
            abrillantarToolStripMenuItem.Size = new Size(162, 26);
            abrillantarToolStripMenuItem.Text = "Abrillantar";
            // 
            // oscurecerToolStripMenuItem
            // 
            oscurecerToolStripMenuItem.Name = "oscurecerToolStripMenuItem";
            oscurecerToolStripMenuItem.Size = new Size(162, 26);
            oscurecerToolStripMenuItem.Text = "Oscurecer";
            oscurecerToolStripMenuItem.Click += oscurecerToolStripMenuItem_Click;
            // 
            // binarizacionToolStripMenuItem
            // 
            binarizacionToolStripMenuItem.Name = "binarizacionToolStripMenuItem";
            binarizacionToolStripMenuItem.Size = new Size(173, 26);
            binarizacionToolStripMenuItem.Text = "Binarizacion";
            binarizacionToolStripMenuItem.Click += binarizacionToolStripMenuItem_Click;
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
            colorearImagenToolStripMenuItem.Click += colorearImagenToolStripMenuItem_Click;
            // 
            // filtrosToolStripMenuItem
            // 
            filtrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pasoBajasToolStripMenuItem, pasoMediasToolStripMenuItem, pasoAltasToolStripMenuItem });
            filtrosToolStripMenuItem.Name = "filtrosToolStripMenuItem";
            filtrosToolStripMenuItem.Size = new Size(63, 24);
            filtrosToolStripMenuItem.Text = "Filtros";
            filtrosToolStripMenuItem.Click += filtrosToolStripMenuItem_Click;
            // 
            // pasoBajasToolStripMenuItem
            // 
            pasoBajasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gaussToolStripMenuItem, kvecinosToolStripMenuItem, mediaPonderadaToolStripMenuItem });
            pasoBajasToolStripMenuItem.Name = "pasoBajasToolStripMenuItem";
            pasoBajasToolStripMenuItem.Size = new Size(174, 26);
            pasoBajasToolStripMenuItem.Text = "Paso Bajas";
            pasoBajasToolStripMenuItem.Click += pasoBajasToolStripMenuItem_Click;
            // 
            // gaussToolStripMenuItem
            // 
            gaussToolStripMenuItem.Name = "gaussToolStripMenuItem";
            gaussToolStripMenuItem.Size = new Size(209, 26);
            gaussToolStripMenuItem.Text = "Gauss";
            gaussToolStripMenuItem.Click += gaussToolStripMenuItem_Click;
            // 
            // kvecinosToolStripMenuItem
            // 
            kvecinosToolStripMenuItem.Name = "kvecinosToolStripMenuItem";
            kvecinosToolStripMenuItem.Size = new Size(209, 26);
            kvecinosToolStripMenuItem.Text = "K vecino";
            kvecinosToolStripMenuItem.Click += kvecinosToolStripMenuItem_Click;
            // 
            // mediaPonderadaToolStripMenuItem
            // 
            mediaPonderadaToolStripMenuItem.Name = "mediaPonderadaToolStripMenuItem";
            mediaPonderadaToolStripMenuItem.Size = new Size(209, 26);
            mediaPonderadaToolStripMenuItem.Text = "Media Ponderada";
            mediaPonderadaToolStripMenuItem.Click += mediaPonderadaToolStripMenuItem_Click;
            // 
            // pasoMediasToolStripMenuItem
            // 
            pasoMediasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { x3ToolStripMenuItem, x5ToolStripMenuItem, x7ToolStripMenuItem });
            pasoMediasToolStripMenuItem.Name = "pasoMediasToolStripMenuItem";
            pasoMediasToolStripMenuItem.Size = new Size(174, 26);
            pasoMediasToolStripMenuItem.Text = "Paso Medias";
            // 
            // x3ToolStripMenuItem
            // 
            x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            x3ToolStripMenuItem.Size = new Size(115, 26);
            x3ToolStripMenuItem.Text = "3x3";
            x3ToolStripMenuItem.Click += x3ToolStripMenuItem_Click;
            // 
            // x5ToolStripMenuItem
            // 
            x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            x5ToolStripMenuItem.Size = new Size(115, 26);
            x5ToolStripMenuItem.Text = "5x5";
            x5ToolStripMenuItem.Click += x5ToolStripMenuItem_Click;
            // 
            // x7ToolStripMenuItem
            // 
            x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            x7ToolStripMenuItem.Size = new Size(115, 26);
            x7ToolStripMenuItem.Text = "7x7";
            x7ToolStripMenuItem.Click += x7ToolStripMenuItem_Click;
            // 
            // pasoAltasToolStripMenuItem
            // 
            pasoAltasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sobelToolStripMenuItem, bordesToolStripMenuItem, intensoToolStripMenuItem });
            pasoAltasToolStripMenuItem.Name = "pasoAltasToolStripMenuItem";
            pasoAltasToolStripMenuItem.Size = new Size(174, 26);
            pasoAltasToolStripMenuItem.Text = "Paso Altas";
            // 
            // sobelToolStripMenuItem
            // 
            sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            sobelToolStripMenuItem.Size = new Size(140, 26);
            sobelToolStripMenuItem.Text = "Sobel";
            sobelToolStripMenuItem.Click += sobelToolStripMenuItem_Click;
            // 
            // bordesToolStripMenuItem
            // 
            bordesToolStripMenuItem.Name = "bordesToolStripMenuItem";
            bordesToolStripMenuItem.Size = new Size(140, 26);
            bordesToolStripMenuItem.Text = "Bordes";
            bordesToolStripMenuItem.Click += bordesToolStripMenuItem_Click;
            // 
            // intensoToolStripMenuItem
            // 
            intensoToolStripMenuItem.Name = "intensoToolStripMenuItem";
            intensoToolStripMenuItem.Size = new Size(140, 26);
            intensoToolStripMenuItem.Text = "Intenso";
            intensoToolStripMenuItem.Click += intensoToolStripMenuItem_Click;
            // 
            // histogramaToolStripMenuItem
            // 
            histogramaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { histogramaDeColorToolStripMenuItem, histogramaDeColorAzulToolStripMenuItem, histogramaDeColorVerdeToolStripMenuItem, histogramaRGBToolStripMenuItem });
            histogramaToolStripMenuItem.Name = "histogramaToolStripMenuItem";
            histogramaToolStripMenuItem.Size = new Size(101, 24);
            histogramaToolStripMenuItem.Text = "Histograma";
            // 
            // histogramaDeColorToolStripMenuItem
            // 
            histogramaDeColorToolStripMenuItem.Name = "histogramaDeColorToolStripMenuItem";
            histogramaDeColorToolStripMenuItem.Size = new Size(273, 26);
            histogramaDeColorToolStripMenuItem.Text = "Histograma de Color Rojo";
            histogramaDeColorToolStripMenuItem.Click += histogramaDeColorToolStripMenuItem_Click;
            // 
            // histogramaDeColorAzulToolStripMenuItem
            // 
            histogramaDeColorAzulToolStripMenuItem.Name = "histogramaDeColorAzulToolStripMenuItem";
            histogramaDeColorAzulToolStripMenuItem.Size = new Size(273, 26);
            histogramaDeColorAzulToolStripMenuItem.Text = "Histograma de Color Azul";
            histogramaDeColorAzulToolStripMenuItem.Click += histogramaDeColorAzulToolStripMenuItem_Click;
            // 
            // histogramaDeColorVerdeToolStripMenuItem
            // 
            histogramaDeColorVerdeToolStripMenuItem.Name = "histogramaDeColorVerdeToolStripMenuItem";
            histogramaDeColorVerdeToolStripMenuItem.Size = new Size(273, 26);
            histogramaDeColorVerdeToolStripMenuItem.Text = "Histograma de Color Verde";
            histogramaDeColorVerdeToolStripMenuItem.Click += histogramaDeColorVerdeToolStripMenuItem_Click;
            // 
            // histogramaRGBToolStripMenuItem
            // 
            histogramaRGBToolStripMenuItem.Name = "histogramaRGBToolStripMenuItem";
            histogramaRGBToolStripMenuItem.Size = new Size(273, 26);
            histogramaRGBToolStripMenuItem.Text = "Histograma RGB";
            histogramaRGBToolStripMenuItem.Click += histogramaRGBToolStripMenuItem_Click;
            // 
            // bordesToolStripMenuItem1
            // 
            bordesToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { laplaceToolStripMenuItem, robertsToolStripMenuItem, prewittToolStripMenuItem, sobelToolStripMenuItem1 });
            bordesToolStripMenuItem1.Name = "bordesToolStripMenuItem1";
            bordesToolStripMenuItem1.Size = new Size(69, 24);
            bordesToolStripMenuItem1.Text = "Bordes";
            // 
            // laplaceToolStripMenuItem
            // 
            laplaceToolStripMenuItem.Name = "laplaceToolStripMenuItem";
            laplaceToolStripMenuItem.Size = new Size(224, 26);
            laplaceToolStripMenuItem.Text = "Laplace";
            laplaceToolStripMenuItem.Click += laplaceToolStripMenuItem_Click;
            // 
            // robertsToolStripMenuItem
            // 
            robertsToolStripMenuItem.Name = "robertsToolStripMenuItem";
            robertsToolStripMenuItem.Size = new Size(224, 26);
            robertsToolStripMenuItem.Text = "Roberts";
            robertsToolStripMenuItem.Click += robertsToolStripMenuItem_Click;
            // 
            // prewittToolStripMenuItem
            // 
            prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            prewittToolStripMenuItem.Size = new Size(224, 26);
            prewittToolStripMenuItem.Text = "Prewitt";
            prewittToolStripMenuItem.Click += prewittToolStripMenuItem_Click;
            // 
            // sobelToolStripMenuItem1
            // 
            sobelToolStripMenuItem1.Name = "sobelToolStripMenuItem1";
            sobelToolStripMenuItem1.Size = new Size(224, 26);
            sobelToolStripMenuItem1.Text = "Sobel";
            sobelToolStripMenuItem1.Click += sobelToolStripMenuItem1_Click;
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
        private ToolStripMenuItem abrirImagenToolStripMenuItem;
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
        private ToolStripMenuItem kvecinosToolStripMenuItem;
        private ToolStripMenuItem mediaPonderadaToolStripMenuItem;
        private ToolStripMenuItem histogramaToolStripMenuItem;
        private ToolStripMenuItem histogramaDeColorToolStripMenuItem;
        private ToolStripMenuItem histogramaDeColorAzulToolStripMenuItem;
        private ToolStripMenuItem histogramaDeColorVerdeToolStripMenuItem;
        private ToolStripMenuItem histogramaRGBToolStripMenuItem;
        private ToolStripMenuItem potenciaToolStripMenuItem;
        private ToolStripMenuItem abrillantarToolStripMenuItem;
        private ToolStripMenuItem oscurecerToolStripMenuItem;
        private ToolStripMenuItem binarizacionToolStripMenuItem;
        private ToolStripMenuItem x3ToolStripMenuItem;
        private ToolStripMenuItem x5ToolStripMenuItem;
        private ToolStripMenuItem x7ToolStripMenuItem;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem bordesToolStripMenuItem;
        private ToolStripMenuItem intensoToolStripMenuItem;
        private ToolStripMenuItem bordesToolStripMenuItem1;
        private ToolStripMenuItem laplaceToolStripMenuItem;
        private ToolStripMenuItem robertsToolStripMenuItem;
        private ToolStripMenuItem prewittToolStripMenuItem;
        private ToolStripMenuItem sobelToolStripMenuItem1;
    }
}
