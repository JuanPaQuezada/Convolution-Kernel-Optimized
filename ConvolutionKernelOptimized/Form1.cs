using System.Data;
using System.Drawing.Imaging;
using System.Runtime.Intrinsics.X86;
namespace ConvolutionKernelOptimized
{
    public partial class Form1 : Form
    {
        public Bitmap objeto_bitmap = null!;
        public Bitmap? original = null!;
        public Bitmap? resultante = null!;




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
            ActualizarInterfaz();
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
            ActualizarInterfaz();
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
            ActualizarInterfaz();
        }

        private void guardarImagenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (resultante == null) return;
            saveFileDialog1.Title = "Guardar imagen";
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog1.DefaultExt = "png";
            saveFileDialog1.AddExtension = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                resultante.Save(saveFileDialog1.FileName);
            }
        }

        private void abrirImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resultante = original;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != null)
                {
                    original = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = original;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
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
            ActualizarInterfaz();
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
            ActualizarInterfaz();
        }

        private unsafe void kvecinosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int W = 11;
            int K = 40;
            int offset = W / 2;
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);

            BitmapData dataOriginal = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataResultado = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* ptrOri = (byte*)dataOriginal.Scan0;
            byte* ptrRes = (byte*)dataResultado.Scan0;

            var vecinos = new (double dist, byte b, byte g, byte r)[W * W];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    byte* centerPixel = ptrOri + (y * dataOriginal.Stride) + (x * 4);
                    int count = 0;

                    for (int kx = 0; kx < W; kx++)
                    {
                        for (int ky = 0; ky < W; ky++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, height - 1);
                            byte* nPixel = ptrOri + (py * dataOriginal.Stride) + (px * 4);

                            double d = Math.Pow(centerPixel[0] - nPixel[0], 2) +
                                       Math.Pow(centerPixel[1] - nPixel[1], 2) +
                                       Math.Pow(centerPixel[2] - nPixel[2], 2);

                            vecinos[count] = (d, nPixel[0], nPixel[1], nPixel[2]);
                            count++;
                        }
                    }

                    QuickSort(vecinos, 0, (W * W) - 1);

                    double sumB = 0, sumG = 0, sumR = 0;
                    for (int i = 0; i < K; i++)
                    {
                        sumB += vecinos[i].b;
                        sumG += vecinos[i].g;
                        sumR += vecinos[i].r;
                    }

                    byte* resPixel = ptrRes + (y * dataResultado.Stride) + (x * 4);
                    resPixel[0] = (byte)(sumB / K);
                    resPixel[1] = (byte)(sumG / K);
                    resPixel[2] = (byte)(sumR / K);
                    resPixel[3] = 255;
                }
            }
            original.UnlockBits(dataOriginal);
            resultante.UnlockBits(dataResultado);
            ActualizarInterfaz();
        }

        private static void QuickSort((double dist, byte b, byte g, byte r)[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PartitionVecinos(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }
        private static int PartitionVecinos((double dist, byte b, byte g, byte r)[] arr, int left, int right)
        {
            double pivotValue = arr[right].dist;
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j].dist <= pivotValue)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[right]) = (arr[right], arr[i + 1]);
            return i + 1;
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
                    sum += kernel[kx, ky];
                }
            }
            for (int kx = 0; kx < W; kx++)
                for (int ky = 0; ky < W; ky++)
                    kernel[kx, ky] /= sum;

            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            int offset = W / 2;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

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
                    resPixel[0] = (byte)Math.Clamp(b, 0, 255);
                    resPixel[1] = (byte)Math.Clamp(g, 0, 255);
                    resPixel[2] = (byte)Math.Clamp(r, 0, 255);
                    resPixel[3] = 255;// Alpha
                }
            }
            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private void filtrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private unsafe void mediaPonderadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int W = 3;
            int offset = W / 2;
            int[,] kernel = new int[,]
            {
                {1,2,1 },
                {2,4,2 },
                {1,2,1 }
            };
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    double b = 0, g = 0, r = 0;
                    for (int kx = 0; kx < W; kx++)
                    {

                        for (int ky = 0; ky < W; ky++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, original.Width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, original.Height - 1);
                            byte* pixelActual = ptrOri + (py * dataOri.Stride) + (px * 4);

                            b += pixelActual[0] * kernel[kx, ky];
                            g += pixelActual[1] * kernel[kx, ky];
                            r += pixelActual[2] * kernel[kx, ky];

                        }

                    }
                    byte* resPixel = ptrRes + (y * dataRes.Stride) + (x * 4);
                    resPixel[0] = (byte)Math.Clamp(b / 16, 0, 255);
                    resPixel[1] = (byte)Math.Clamp(g / 16, 0, 255);
                    resPixel[2] = (byte)Math.Clamp(r / 16, 0, 255);
                    resPixel[3] = 255;// Alpha
                }
            }
            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private unsafe void histogramaDeColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int[] conteoRojo = new int[256];
            int width = original.Width;
            int height = original.Height;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pixelActual = ptrOri + (y * dataOri.Stride) + (x * 4);

                    byte rojo = pixelActual[2];
                    conteoRojo[rojo]++;
                }
            }
            original.UnlockBits(dataOri);

            int maxValor = 0;
            for (int i = 0; i < 256; i++)
            {
                if (conteoRojo[i] > maxValor)
                {
                    maxValor = conteoRojo[i];
                }
            }
            if (maxValor == 0) maxValor = 1;

            Bitmap bmpHistograma = new Bitmap(256, 200);
            using (Graphics g = Graphics.FromImage(bmpHistograma))
            {
                g.Clear(Color.White); // Fondo blanco

                for (int i = 0; i < 256; i++)
                {
                    int altura = (int)((double)conteoRojo[i] / maxValor * 200);

                    g.DrawLine(Pens.Red, i, 200, i, 200 - altura);
                }
            }

            Form ventanaHist = new Form();
            ventanaHist.Text = "Histograma de Color Rojo";
            ventanaHist.ClientSize = new Size(276, 220);
            ventanaHist.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ventanaHist.StartPosition = FormStartPosition.CenterParent;

            PictureBox pbHist = new PictureBox();
            pbHist.Image = bmpHistograma;
            pbHist.Dock = DockStyle.Fill;
            pbHist.SizeMode = PictureBoxSizeMode.CenterImage;

            ventanaHist.Controls.Add(pbHist);
            ventanaHist.Show();
        }

        private unsafe void histogramaDeColorAzulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int[] conteoAzul = new int[256];
            int width = original.Width;
            int height = original.Height;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pixelActual = ptrOri + (y * dataOri.Stride) + (x * 4);
                    conteoAzul[pixelActual[0]]++;
                }
            }
            original.UnlockBits(dataOri);

            int maxValor = 0;
            for (int i = 0; i < 256; i++)
            {
                if (conteoAzul[i] > maxValor) maxValor = conteoAzul[i];
            }
            if (maxValor == 0) maxValor = 1;

            Bitmap bmpHistograma = new Bitmap(256, 200);
            using (Graphics g = Graphics.FromImage(bmpHistograma))
            {
                g.Clear(Color.White);
                for (int i = 0; i < 256; i++)
                {
                    int altura = (int)((double)conteoAzul[i] / maxValor * 200);
                    g.DrawLine(Pens.Blue, i, 200, i, 200 - altura);
                }
            }

            Form ventanaHist = new Form();
            ventanaHist.Text = "Histograma de Color Azul";
            ventanaHist.ClientSize = new Size(276, 220);
            ventanaHist.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ventanaHist.StartPosition = FormStartPosition.CenterParent;

            PictureBox pbHist = new PictureBox();
            pbHist.Image = bmpHistograma;
            pbHist.Dock = DockStyle.Fill;
            pbHist.SizeMode = PictureBoxSizeMode.CenterImage;

            ventanaHist.Controls.Add(pbHist);
            ventanaHist.Show();
        }

        private unsafe void histogramaDeColorVerdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int[] conteoVerde = new int[256];
            int width = original.Width;
            int height = original.Height;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pixelActual = ptrOri + (y * dataOri.Stride) + (x * 4);
                    conteoVerde[pixelActual[1]]++;
                }
            }
            original.UnlockBits(dataOri);

            int maxValor = 0;
            for (int i = 0; i < 256; i++)
            {
                if (conteoVerde[i] > maxValor) maxValor = conteoVerde[i];
            }
            if (maxValor == 0) maxValor = 1;

            Bitmap bmpHistograma = new Bitmap(256, 200);
            using (Graphics g = Graphics.FromImage(bmpHistograma))
            {
                g.Clear(Color.White);
                for (int i = 0; i < 256; i++)
                {
                    int altura = (int)((double)conteoVerde[i] / maxValor * 200);
                    g.DrawLine(Pens.Green, i, 200, i, 200 - altura);
                }
            }

            Form ventanaHist = new Form();
            ventanaHist.Text = "Histograma de Color Verde";
            ventanaHist.ClientSize = new Size(276, 220);
            ventanaHist.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ventanaHist.StartPosition = FormStartPosition.CenterParent;

            PictureBox pbHist = new PictureBox();
            pbHist.Image = bmpHistograma;
            pbHist.Dock = DockStyle.Fill;
            pbHist.SizeMode = PictureBoxSizeMode.CenterImage;

            ventanaHist.Controls.Add(pbHist);
            ventanaHist.Show();
        }

        private unsafe void histogramaRGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int[] conteoR = new int[256];
            int[] conteoG = new int[256];
            int[] conteoB = new int[256];
            int width = original.Width;
            int height = original.Height;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pixelActual = ptrOri + (y * dataOri.Stride) + (x * 4);
                    conteoB[pixelActual[0]]++;
                    conteoG[pixelActual[1]]++;
                    conteoR[pixelActual[2]]++;
                }
            }
            original.UnlockBits(dataOri);

            int maxValor = 0;
            for (int i = 0; i < 256; i++)
            {
                if (conteoR[i] > maxValor) maxValor = conteoR[i];
                if (conteoG[i] > maxValor) maxValor = conteoG[i];
                if (conteoB[i] > maxValor) maxValor = conteoB[i];
            }
            if (maxValor == 0) maxValor = 1;

            Bitmap bmpHistograma = new Bitmap(256, 200);
            using (Graphics g = Graphics.FromImage(bmpHistograma))
            {
                g.Clear(Color.White);

                for (int i = 0; i < 256; i++)
                {
                    int altR = (int)((double)conteoR[i] / maxValor * 200);
                    int altG = (int)((double)conteoG[i] / maxValor * 200);
                    int altB = (int)((double)conteoB[i] / maxValor * 200);

                    g.DrawLine(new Pen(Color.FromArgb(150, Color.Red)), i, 200, i, 200 - altR);
                    g.DrawLine(new Pen(Color.FromArgb(150, Color.Green)), i, 200, i, 200 - altG);
                    g.DrawLine(new Pen(Color.FromArgb(150, Color.Blue)), i, 200, i, 200 - altB);
                }
            }

            Form ventanaHist = new Form();
            ventanaHist.Text = "Histograma RGB Combinado";
            ventanaHist.ClientSize = new Size(276, 220);
            ventanaHist.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ventanaHist.StartPosition = FormStartPosition.CenterParent;

            PictureBox pbHist = new PictureBox();
            pbHist.Image = bmpHistograma;
            pbHist.Dock = DockStyle.Fill;
            pbHist.SizeMode = PictureBoxSizeMode.CenterImage;

            ventanaHist.Controls.Add(pbHist);
            ventanaHist.Show();
        }

        private unsafe void binarizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            int umbral = 128;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pOri = ptrOri + (y * dataOri.Stride) + (x * 4);
                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    int promedio = (pOri[0] + pOri[1] + pOri[2]) / 3;
                    byte binario = (byte)(promedio > umbral ? 255 : 0);

                    pRes[0] = binario;
                    pRes[1] = binario;
                    pRes[2] = binario;
                    pRes[3] = 255;
                }
            }

            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);

            ActualizarInterfaz();
        }

        private unsafe void abrillantarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;
            int brillo = 30;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pOri = ptrOri + (y * dataOri.Stride) + (x * 4);
                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    pRes[0] = (byte)Math.Clamp(pOri[0] + brillo, 0, 255);
                    pRes[1] = (byte)Math.Clamp(pOri[1] + brillo, 0, 255);
                    pRes[2] = (byte)Math.Clamp(pOri[2] + brillo, 0, 255);
                    pRes[3] = pOri[3];
                }
            }
            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private unsafe void oscurecerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;
            int oscuridad = 30;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    byte* pOri = ptrOri + (y * dataOri.Stride) + (x * 4);
                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    pRes[0] = (byte)Math.Clamp(pOri[0] - oscuridad, 0, 255);
                    pRes[1] = (byte)Math.Clamp(pOri[1] - oscuridad, 0, 255);
                    pRes[2] = (byte)Math.Clamp(pOri[2] - oscuridad, 0, 255);
                    pRes[3] = pOri[3];
                }
            }
            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            Image imagenAnterior = pictureBox1.Image;
            pictureBox1.Image = resultante;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            original = resultante;
            imagenAnterior?.Dispose();
        }

        private unsafe void colorearImagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;

            ColorDialog selectorColor = new ColorDialog();
            selectorColor.AllowFullOpen = true;

            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                Color colorFiltro = selectorColor.Color;

                int width = original.Width;
                int height = original.Height;
                resultante = new Bitmap(width, height);

                BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

                byte* ptrOri = (byte*)dataOri.Scan0;
                byte* ptrRes = (byte*)dataRes.Scan0;

                double factorR = colorFiltro.R / 255.0;
                double factorG = colorFiltro.G / 255.0;
                double factorB = colorFiltro.B / 255.0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte* pOri = ptrOri + (y * dataOri.Stride) + (x * 4);
                        byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);

                        double gris = (pOri[2] * 0.299) + (pOri[1] * 0.587) + (pOri[0] * 0.114);

                        pRes[0] = (byte)Math.Clamp(gris * factorB, 0, 255);
                        pRes[1] = (byte)Math.Clamp(gris * factorG, 0, 255);
                        pRes[2] = (byte)Math.Clamp(gris * factorR, 0, 255);
                        pRes[3] = pOri[3];
                    }
                }

                original.UnlockBits(dataOri);
                resultante.UnlockBits(dataRes);

                ActualizarInterfaz();
            }
        }
        private unsafe void AplicarFiltroMedia(int W)
        {
            if (original == null) return;
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            int offset = W / 2;
            int size = W * W;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int b = 0, g = 0, r = 0;

                    for (int ky = 0; ky < W; ky++)
                    {
                        for (int kx = 0; kx < W; kx++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, height - 1);
                            byte* pOri = ptrOri + (py * dataOri.Stride) + (px * 4);

                            b += pOri[0];
                            g += pOri[1];
                            r += pOri[2];
                        }
                    }

                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    pRes[0] = (byte)(b / size);
                    pRes[1] = (byte)(g / size);
                    pRes[2] = (byte)(r / size);
                    pRes[3] = 255;
                }
            }

            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarFiltroMedia(3);
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarFiltroMedia(5);
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarFiltroMedia(7);
        }

        private unsafe void aplicarPasoAltas(int[,] kernel)
        {
            if (original == null) return;
            int W = 3;
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            int offset = 1;
            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double b = 0, g = 0, r = 0;
                    for (int ky = 0; ky < W; ky++)
                    {
                        for (int kx = 0; kx < W; kx++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, height - 1);
                            byte* pOri = ptrOri + (py * dataOri.Stride) + (px * 4);

                            b += pOri[0] * kernel[ky, kx];
                            g += pOri[1] * kernel[ky, kx];
                            r += pOri[2] * kernel[ky, kx];
                        }
                    }

                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);

                    pRes[0] = (byte)Math.Clamp(b, 0, 255);
                    pRes[1] = (byte)Math.Clamp(g, 0, 255);
                    pRes[2] = (byte)Math.Clamp(r, 0, 255);
                    pRes[3] = 255; // Opacidad total
                }
            }

            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private unsafe void aplicarFiltroBordes(int[,] gx, int[,] gy)
        {
            if (original == null) return;
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);
            int offset = 1;

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double bx = 0, gx_val = 0, rx = 0;
                    double by = 0, gy_val = 0, ry = 0;

                    for (int ky = 0; ky < 3; ky++)
                    {
                        for (int kx = 0; kx < 3; kx++)
                        {
                            int px = Math.Clamp(x + (kx - offset), 0, width - 1);
                            int py = Math.Clamp(y + (ky - offset), 0, height - 1);
                            byte* pOri = ptrOri + (py * dataOri.Stride) + (px * 4);

                            bx += pOri[0] * gx[ky, kx];
                            gx_val += pOri[1] * gx[ky, kx];
                            rx += pOri[2] * gx[ky, kx];

                            by += pOri[0] * gy[ky, kx];
                            gy_val += pOri[1] * gy[ky, kx];
                            ry += pOri[2] * gy[ky, kx];
                        }
                    }

                    double b = Math.Sqrt((bx * bx) + (by * by));
                    double g = Math.Sqrt((gx_val * gx_val) + (gy_val * gy_val));
                    double r = Math.Sqrt((rx * rx) + (ry * ry));

                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    pRes[0] = (byte)Math.Clamp(b, 0, 255);
                    pRes[1] = (byte)Math.Clamp(g, 0, 255);
                    pRes[2] = (byte)Math.Clamp(r, 0, 255);
                    pRes[3] = 255;
                }
            }

            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private unsafe void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] gx = new int[,] {
                { -1,  0,  1 },
                { -2,  0,  2 },
                { -1,  0,  1 }
            };
            int[,] gy = new int[,] {
                { -1, -2, -1 },
                {  0,  0,  0 },
                {  1,  2,  1 }
            };
            aplicarFiltroBordes(gx, gy);
        }

        private void bordesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] kernel = new int[,] {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };
            aplicarPasoAltas(kernel);
        }

        private void intensoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] kernel = new int[,] {
                { -1, -1, -1 },
                { -1,  9, -1 },
                { -1, -1, -1 }
            };
            aplicarPasoAltas(kernel);
        }

        private void sobelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            sobelToolStripMenuItem_Click(sender, e);
        }

        private void laplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] kernel = new int[,]
            {
                { -1, -1, -1  },
                { -1, 8, -1 },
                { -1, -1, -1 },
            };
            aplicarPasoAltas(kernel);
        }

        private unsafe void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (original == null) return;
            int width = original.Width;
            int height = original.Height;
            resultante = new Bitmap(width, height);

            BitmapData dataOri = original.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataRes = resultante.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            byte* ptrOri = (byte*)dataOri.Scan0;
            byte* ptrRes = (byte*)dataRes.Scan0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int px1 = Math.Clamp(x + 1, 0, width - 1);
                    int py1 = Math.Clamp(y + 1, 0, height - 1);

                    byte* p00 = ptrOri + (y * dataOri.Stride) + (x * 4);
                    byte* p10 = ptrOri + (y * dataOri.Stride) + (px1 * 4);
                    byte* p01 = ptrOri + (py1 * dataOri.Stride) + (x * 4);
                    byte* p11 = ptrOri + (py1 * dataOri.Stride) + (px1 * 4);

                    double bx = p00[0] - p11[0];
                    double gx_val = p00[1] - p11[1];
                    double rx = p00[2] - p11[2];

                    double by = p10[0] - p01[0];
                    double gy_val = p10[1] - p01[1];
                    double ry = p10[2] - p01[2];

                    double b = Math.Sqrt((bx * bx) + (by * by));
                    double g = Math.Sqrt((gx_val * gx_val) + (gy_val * gy_val));
                    double r = Math.Sqrt((rx * rx) + (ry * ry));

                    byte* pRes = ptrRes + (y * dataRes.Stride) + (x * 4);
                    pRes[0] = (byte)Math.Clamp(b, 0, 255);
                    pRes[1] = (byte)Math.Clamp(g, 0, 255);
                    pRes[2] = (byte)Math.Clamp(r, 0, 255);
                    pRes[3] = 255;
                }
            }

            original.UnlockBits(dataOri);
            resultante.UnlockBits(dataRes);
            ActualizarInterfaz();
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[,] gx = new int[,]
            {
                {-1,0,1 },
                {-1,0,1 },
                {-1,0,1 }
            };
            int[,] gy = new int[,]
            {
                {-1,-1,-1 },
                {0,0,0  },
                {1,1,1 }
            };
            aplicarFiltroBordes(gx, gy);
        }
    }
}

