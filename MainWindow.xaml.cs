using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GrafikaZadanie3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Drawing.Color color = System.Drawing.Color.Black;
        public double R;
        public double G;
        public double B;
        public double C;
        public double M;
        public double Y;
        public double K;
        public double H;
        public double S;
        public double V;
        public MainWindow()
        {
            InitializeComponent();
            R = 0;
            G = 0;
            B = 0;
            C = 0;
            M = 0;
            Y = 0;
            K = 0;
            H = 0;
            S = 0;
            V = 0;
            this.DataContext = this;
            Bitmap bitmap = new Bitmap(1, 1);
            color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
            bitmap.SetPixel(0, 0, color);
            RgbSquare.Source = Convert(bitmap);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _3DCubeWindow window = new _3DCubeWindow();
            window.Show();
        }

        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            src.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        private void R_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                R = System.Convert.ToDouble(RRR.Text);
                if (R > 255.0)
                {
                    R = 255.0;
                }
                else if (R < 0.0 || R == null)
                {
                    R = 0.0;
                }
                double x1 = Math.Max(R / 255.0, G / 255.0);
                double x2 = Math.Min(R / 255.0, G / 255.0);
                K = 1 - Math.Max(x1, B / 255.0);
                C = (1 - (R / 255.0) - K) / (1 - K);
                M = (1 - (G / 255.0) - K) / (1 - K);
                Y = (1 - (B / 255.0) - K) / (1 - K);
                double cmax = Math.Max(x1, B / 255.0);
                double cmin = Math.Min(x2, B / 255.0);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255.0)
                {
                    H = 60.0 * (((G / 255.0) - (B / 255.0)) / delta) % 6;
                }
                else if (cmax == G / 255.0)
                {
                    H = 60.0 * ((((B / 255.0) - (R / 255.0)) / delta) + 2.0);
                }
                else if (cmax == B / 255.0)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4.0);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void G_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                G = System.Convert.ToDouble(GGG.Text);
                if (G > 255.0)
                {
                    G = 255.0;
                }
                else if (G < 0 || G == null)
                {
                    G = 0;
                }
                double x1 = Math.Max(R / 255.0, G / 255.0);
                double x2 = Math.Min(R / 255.0, G / 255.0);
                K = 1 - Math.Max(x1, B / 255.0);
                C = (1 - (R / 255.0) - K) / (1 - K);
                M = (1 - (G / 255.0) - K) / (1 - K);
                Y = (1 - (B / 255.0) - K) / (1 - K);
                double cmax = Math.Max(x1, B / 255.0);
                double cmin = Math.Min(x2, B / 255.0);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                RRR.Text = R.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                B = System.Convert.ToDouble(BBB.Text);
                if (B > 255)
                {
                    B = 255;
                }
                else if (B < 0 || B == null)
                {
                    B = 0;
                }
                double x1 = Math.Max(R / 255, G / 255);
                double x2 = Math.Min(R / 255, G / 255);
                K = 1 - Math.Max(x1, B / 255);
                C = (1 - (R / 255) - K) / (1 - K);
                M = (1 - (G / 255) - K) / (1 - K);
                Y = (1 - (B / 255) - K) / (1 - K);
                double cmax = Math.Max(x1, B / 255);
                double cmin = Math.Min(x2, B / 255);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                RRR.Text = R.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                C = System.Convert.ToDouble(CCC.Text);
                if (C > 1)
                {
                    C  = 1;
                }
                else if (C < 0 || C == null)
                {
                    C = 0;
                }
                R = 255 * (1 - C) * (1 - K);
                G = 255 * (1 - M) * (1 - K);
                B = 255 * (1 - Y) * (1 - K);
                double x1 = Math.Max(R / 255, G / 255);
                double x2 = Math.Min(R / 255, G / 255);
                double cmax = Math.Max(x1, B / 255);
                double cmin = Math.Min(x2, B / 255);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                RRR.Text = R.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void M_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                M = System.Convert.ToDouble(MMM.Text);
                if (M > 1)
                {
                    M = 1;
                }
                else if (M < 0 || M == null)
                {
                    M = 0;
                }
                R = 255 * (1 - C) * (1 - K);
                G = 255 * (1 - M) * (1 - K);
                B = 255 * (1 - Y) * (1 - K);
                double x1 = Math.Max(R / 255, G / 255);
                double x2 = Math.Min(R / 255, G / 255);
                double cmax = Math.Max(x1, B / 255);
                double cmin = Math.Min(x2, B / 255);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                RRR.Text = R.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void Y_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Y = System.Convert.ToDouble(YYY.Text);
                if (Y > 1)
                {
                    Y = 1;
                }
                else if (Y < 0 || Y == null)
                {
                    Y = 0;
                }
                R = 255 * (1 - C) * (1 - K);
                G = 255 * (1 - M) * (1 - K);
                B = 255 * (1 - Y) * (1 - K);
                double x1 = Math.Max(R / 255, G / 255);
                double x2 = Math.Min(R / 255, G / 255);
                double cmax = Math.Max(x1, B / 255);
                double cmin = Math.Min(x2, B / 255);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                RRR.Text = R.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void K_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                K = System.Convert.ToDouble(KKK.Text);
                if (K > 1)
                {
                    K = 1;
                }
                else if (K < 0 || K == null)
                {
                    K = 0;
                }
                R = 255 * (1 - C) * (1 - K);
                G = 255 * (1 - M) * (1 - K);
                B = 255 * (1 - Y) * (1 - K);
                double x1 = Math.Max(R / 255, G / 255);
                double x2 = Math.Min(R / 255, G / 255);
                double cmax = Math.Max(x1, B / 255);
                double cmin = Math.Min(x2, B / 255);
                double delta = cmax - cmin;
                if (delta == 0)
                {
                    H = 0;
                }
                else if (cmax == R / 255)
                {
                    H = 60 * (((G / 255) - (B / 255)) / delta) % 6;
                }
                else if (cmax == G / 255)
                {
                    H = 60 * ((((B / 255) - (R / 255)) / delta) + 2);
                }
                else if (cmax == B / 255)
                {
                    H = 60 * ((((R / 255) - (G / 255)) / delta) + 4);
                }

                if (cmax == 0)
                {
                    S = 0;
                }
                else
                {
                    S = delta / cmax;
                }

                V = cmax;
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                RRR.Text = R.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void H_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                H = System.Convert.ToDouble(HHH.Text);
                if (H > 360)
                {
                    H = 360;
                }
                else if (H < 0 || H == null)
                {
                    H = 0;
                }
                double cc = V * S;
                double xx = cc * (1 - Math.Abs((H / 60) % 2 - 1));
                double mm = V - cc;
                if (H >= 0 && H < 60)
                {
                    R = (cc + mm) * 255;
                    G = (xx + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 60 && H < 120)
                {
                    R = (xx + mm) * 255;
                    G = (cc + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 120 && H < 180)
                {
                    R = mm * 255;
                    G = (cc + mm) * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 180 && H < 240)
                {
                    R = mm * 255;
                    G = (xx + mm) * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 240 && H < 300)
                {
                    R = (xx + mm) * 255;
                    G = mm * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else
                {
                    R = (cc + mm) * 255;
                    G = mm * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                RRR.Text = R.ToString();
                SSS.Text = S.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void S_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                S = System.Convert.ToDouble(SSS.Text);
                if (S > 1)
                {
                    S = 1;
                }
                else if (S < 0 || S == null)
                {
                    S = 0;
                }
                double cc = V * S;
                double xx = cc * (1 - Math.Abs((H / 60) % 2 - 1));
                double mm = V - cc;
                if (H >= 0 && H < 60)
                {
                    R = (cc + mm) * 255;
                    G = (xx + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 60 && H < 120)
                {
                    R = (xx + mm) * 255;
                    G = (cc + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 120 && H < 180)
                {
                    R = mm * 255;
                    G = (cc + mm) * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 180 && H < 240)
                {
                    R = mm * 255;
                    G = (xx + mm) * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 240 && H < 300)
                {
                    R = (xx + mm) * 255;
                    G = mm * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else
                {
                    R = (cc + mm) * 255;
                    G = mm * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                RRR.Text = R.ToString();
                VVV.Text = V.ToString();
            }
        }

        private void V_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                V = System.Convert.ToDouble(VVV.Text);
                if (V > 1)
                {
                    V = 1;
                }
                else if (V < 0 || V == null)
                {
                    V = 0;
                }
                double cc = V * S;
                double xx = cc * (1 - Math.Abs((H / 60) % 2 - 1));
                double mm = V - cc;
                if (H >= 0 && H < 60)
                {
                    R = (cc + mm) * 255;
                    G = (xx + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 60 && H < 120)
                {
                    R = (xx + mm) * 255;
                    G = (cc + mm) * 255;
                    B = mm * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 120 && H < 180)
                {
                    R = mm * 255;
                    G = (cc + mm) * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 180 && H < 240)
                {
                    R = mm * 255;
                    G = (xx + mm) * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else if (H >= 240 && H < 300)
                {
                    R = (xx + mm) * 255;
                    G = mm * 255;
                    B = (cc + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                else
                {
                    R = (cc + mm) * 255;
                    G = mm * 255;
                    B = (xx + mm) * 255;
                    double x1 = Math.Max(R / 255, G / 255);
                    K = 1 - Math.Max(x1, B / 255);
                    C = (1 - (R / 255) - K) / (1 - K);
                    M = (1 - (G / 255) - K) / (1 - K);
                    Y = (1 - (B / 255) - K) / (1 - K);
                }
                Bitmap bitmap = new Bitmap(1, 1);
                color = System.Drawing.Color.FromArgb((int)R, (int)G, (int)B);
                bitmap.SetPixel(0, 0, color);
                RgbSquare.Source = Convert(bitmap);
                GGG.Text = G.ToString();
                BBB.Text = B.ToString();
                CCC.Text = C.ToString();
                MMM.Text = M.ToString();
                YYY.Text = Y.ToString();
                KKK.Text = K.ToString();
                HHH.Text = H.ToString();
                SSS.Text = S.ToString();
                RRR.Text = R.ToString();
            }
        }
    }
}
