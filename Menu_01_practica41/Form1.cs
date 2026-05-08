using System.Drawing.Imaging;
namespace Menu_01_practica41
{
    public partial class Form1 : Form
    {
        public Bitmap objeto_bitmap = null!;
        public Bitmap original = null!;
        public Bitmap resultante = null!;




        public Form1()
        {
            InitializeComponent();
            objeto_bitmap = new Bitmap(1, 1);
            original = objeto_bitmap;
            resultante = objeto_bitmap;
        }




        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void negativoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null || original.Width <= 1) return;

            resultante = new Bitmap(original.Width, original.Height);
            Color rColor;
            Color oColor;

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);
                    rColor = Color.FromArgb(255 - oColor.R, 255 - oColor.G, 255 - oColor.B);
                    resultante.SetPixel(x, y, rColor);
                }
            }

            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            original = resultante;
        }

        private void grisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int x, y;
            resultante = new Bitmap(original.Width, original.Height);

            Color oColor;
            Color rColor;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    int promedio = (oColor.R + oColor.G + oColor.B) / 3;

                    rColor = Color.FromArgb(promedio, promedio, promedio);
                    resultante.SetPixel(x, y, rColor);
                }
            }

            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            original = resultante;
        }

        private void filtroRojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int x, y;
            resultante = new Bitmap(original.Width, original.Height);

            Color oColor;
            Color rColor;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(oColor.R, 0, 0);
                    resultante.SetPixel(x, y, rColor);
                }
            }

            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            original = resultante;
        }

        private void guardarImagenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            objeto_bitmap.Save(saveFileDialog1.FileName);
        }

        private void guardarImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                original = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = original;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void filtroVerdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int x, y;
            resultante = new Bitmap(original.Width, original.Height);

            Color oColor;
            Color rColor;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(0, oColor.G, 0);
                    resultante.SetPixel(x, y, rColor);
                }
            }

            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            original = resultante;
        }

        private void filtroAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int x, y;
            resultante = new Bitmap(original.Width, original.Height);

            Color oColor;
            Color rColor;

            for (x = 0; x < original.Width; x++)
            {
                for (y = 0; y < original.Height; y++)
                {
                    oColor = original.GetPixel(x, y);

                    rColor = Color.FromArgb(0, 0, oColor.B);
                    resultante.SetPixel(x, y, rColor);
                }
            }

            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            original = resultante;
        }

        private void kmeansToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasoBajasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private unsafe void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int W = 5;
            double sigma = 1.0;
            double[,] kernel = new double[W, W];
            double mean = W / 2.0;
            double sum = 0.0;
            for (int kx = 0; kx < W; kx++)
            {
                for (int ky = 0; ky < W; ky++)
                {
                    kernel[kx, ky] = Math.Exp(-0.5 * (Math.Pow((kx - mean) / sigma, 2.0) + Math.Pow((ky - mean) / sigma, 2.0))) / (2 * Math.PI * sigma * sigma);
                    sum+=kernel[kx, ky];
                }
            }
            for (int kx = 0; kx < W; kx++)
                for (int ky = 0; ky < W; ky++)
                    kernel[kx, ky]/=sum;

            int width=original.Width;
            int height=original.Height;
            resultante=new Bitmap(width, height);
            int offset=W / 2;

            BitmapData dataOri=original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes=resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int kx = 0; kx < W; kx++)
                    {
                        for (int ky = 0; ky < W; ky++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, height - 1);

                            byte* pixelActual = ptrOri + (py * dataOri.Stride) + (px * 4);

                            b += pixelActual[0] * kernel[kx, ky];
                            g += pixelActual[1] * kernel[kx, ky];
                            r += pixelActual[2] * kernel[kx, ky];
                        }
                    }

                    byte* resPixel = ptrRes + (y * dataRes.Stride) + (x * 4);
                    resPixel[0]=(byte)Math.Clamp(b, 0, 255); 
                    resPixel[1]=(byte)Math.Clamp(g, 0, 255);
                    resPixel[2]=(byte)Math.Clamp(r, 0, 255);
                    resPixel[3]=255;// Alpha
                }
            }
            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            pictureBox1.Image=resultante;
        }
    }
}
